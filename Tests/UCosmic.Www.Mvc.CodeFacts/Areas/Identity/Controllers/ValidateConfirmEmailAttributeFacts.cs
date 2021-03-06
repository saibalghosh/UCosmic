﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;
using UCosmic.Domain;
using UCosmic.Domain.People;
using UCosmic.Www.Mvc.Areas.Identity.Models;

namespace UCosmic.Www.Mvc.Areas.Identity.Controllers
{
    public static class ValidateConfirmEmailAttributeFacts
    {
        [TestClass]
        public class TheConstructor
        {
            [TestMethod]
            public void ThrowsArgumentNullException_WhenArgIsNull()
            {
                ArgumentNullException exception = null;

                try
                {
                    new ValidateConfirmEmailAttribute(null);
                }
                catch (ArgumentNullException ex)
                {
                    exception = ex;
                }

                exception.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                exception.ParamName.ShouldEqual("paramName");
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void SetsParamNameProperty_ToArgValue()
            {
                const string paramName = "test";

                var attribute = new ValidateConfirmEmailAttribute(paramName);

                attribute.ParamName.ShouldEqual(paramName);
            }
        }

        [TestClass]
        public class TheEntitiesProperty
        {
            [TestMethod]
            public void CanBeSet_ByIocContainer()
            {
                const string paramName = "test";
                var attribute = new ValidateConfirmEmailAttribute(paramName)
                {
                    Entities = null
                };
                attribute.Entities.ShouldBeNull();
            }
        }

        [TestClass]
        public class TheGetTokenMethod
        {
            [TestMethod]
            public void ThrowsInvalidOperationException_WhenParamName_IsNotFound()
            {
                const string paramName = "some value";
                var attribute = new ValidateConfirmEmailAttribute(paramName);
                var filterContext = CreateFilterContext(null, null);
                InvalidOperationException exception = null;

                try
                {
                    attribute.GetToken(filterContext);
                }
                catch (InvalidOperationException ex)
                {
                    exception = ex;
                }

                exception.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                exception.Message.ShouldContain(paramName);
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void ThrowsInvalidOperationException_WhenTokenParamValue_IsNotFound()
            {
                const string paramName = "some value";
                var attribute = new ValidateConfirmEmailAttribute(paramName);
                var filterContext = CreateFilterContext(paramName, "not a guid or interface");
                InvalidOperationException exception = null;

                try
                {
                    attribute.GetToken(filterContext);
                }
                catch (InvalidOperationException ex)
                {
                    exception = ex;
                }

                exception.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                exception.Message.ShouldContain(paramName);
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void ReturnsToken_FromScalarParameter()
            {
                const string paramName = "some value";
                var tokenValue = Guid.NewGuid();
                var attribute = new ValidateConfirmEmailAttribute(paramName);
                var filterContext = CreateFilterContext(paramName, tokenValue, false);

                var value = attribute.GetToken(filterContext);

                value.ShouldEqual(tokenValue);
            }

            [TestMethod]
            public void ReturnsToken_FromModeledParameter()
            {
                var tokenValue = Guid.NewGuid();
                const string paramName = "some value";
                var attribute = new ValidateConfirmEmailAttribute(paramName);
                var modeled = new Mock<IModelConfirmAndRedeem>(MockBehavior.Strict);
                modeled.Setup(p => p.Token).Returns(tokenValue);
                var filterContext = CreateFilterContext(paramName, tokenValue, true);

                var value = attribute.GetToken(filterContext);

                value.ShouldEqual(tokenValue);
            }
        }

        [TestClass]
        public class TheOnActionExecutingMethod
        {
            [TestMethod]
            public void SetsResult_To404_WhenToken_IsEmptyGuid()
            {
                const string paramName = "some value";
                var entities = new Mock<IQueryEntities>(MockBehavior.Strict).Initialize();
                entities.Setup(m => m.Query<EmailConfirmation>())
                    .Returns(new[] { new EmailConfirmation(EmailConfirmationIntent.ResetPassword) }.AsQueryable);
                var attribute = new ValidateConfirmEmailAttribute(paramName)
                {
                    Entities = entities.Object,
                };
                var filterContext = CreateFilterContext(paramName, Guid.Empty);

                attribute.OnActionExecuting(filterContext);

                filterContext.Result.ShouldNotBeNull();
                filterContext.Result.ShouldBeType<HttpNotFoundResult>();
            }

            [TestMethod]
            public void SetsResult_To404_WhenToken_MatchesNoEntity()
            {
                const string paramName = "some value";
                var tokenValue = Guid.NewGuid();
                var entities = new Mock<IQueryEntities>(MockBehavior.Strict).Initialize();
                entities.Setup(m => m.Query<EmailConfirmation>())
                    .Returns(new EmailConfirmation[] { }.AsQueryable);
                var attribute = new ValidateConfirmEmailAttribute(paramName)
                {
                    Entities = entities.Object,
                };
                var filterContext = CreateFilterContext(paramName, tokenValue);

                attribute.OnActionExecuting(filterContext);

                filterContext.Result.ShouldNotBeNull();
                filterContext.Result.ShouldBeType<HttpNotFoundResult>();
                entities.Verify(m => m.Query<EmailConfirmation>(), Times.Once());
            }

            [TestMethod]
            public void SetsResult_ToPartialExpiredDenial_WhenToken_MatchesExpiredEntity()
            {
                const string paramName = "some value";
                var confirmation = new EmailConfirmation(EmailConfirmationIntent.ResetPassword)
                {
                    ExpiresOnUtc = DateTime.UtcNow.AddSeconds(-5),
                };
                var entities = new Mock<IQueryEntities>(MockBehavior.Strict).Initialize();
                entities.Setup(m => m.Query<EmailConfirmation>())
                    .Returns(new[] { confirmation }.AsQueryable);
                var attribute = new ValidateConfirmEmailAttribute(paramName)
                {
                    Entities = entities.Object,
                };
                var filterContext = CreateFilterContext(paramName, confirmation.Token);

                attribute.OnActionExecuting(filterContext);

                filterContext.Result.ShouldNotBeNull();
                filterContext.Result.ShouldBeType<PartialViewResult>();
                var partialView = (PartialViewResult)filterContext.Result;
                partialView.ViewName.ShouldEqual(MVC.Identity.ConfirmEmail.Views._denied_all);
                partialView.Model.ShouldNotBeNull();
                partialView.Model.ShouldBeType<ConfirmDeniedModel>();
                var model = (ConfirmDeniedModel)partialView.Model;
                model.Reason.ShouldEqual(ConfirmDeniedBecause.IsExpired);
                model.Intent.ShouldEqual(confirmation.Intent);
            }

            [TestMethod]
            public void SetsResult_ToPartialRetiredDenial_WhenToken_MatchesExpiredEntity()
            {
                const string paramName = "some value";
                var confirmation = new EmailConfirmation(EmailConfirmationIntent.CreatePassword)
                {
                    ExpiresOnUtc = DateTime.UtcNow.AddHours(1),
                    RetiredOnUtc = DateTime.UtcNow.AddSeconds(-5),
                };
                var entities = new Mock<IQueryEntities>(MockBehavior.Strict).Initialize();
                entities.Setup(m => m.Query<EmailConfirmation>())
                    .Returns(new[] { confirmation }.AsQueryable);
                var attribute = new ValidateConfirmEmailAttribute(paramName)
                {
                    Entities = entities.Object,
                };
                var filterContext = CreateFilterContext(paramName, confirmation.Token);

                attribute.OnActionExecuting(filterContext);

                filterContext.Result.ShouldNotBeNull();
                filterContext.Result.ShouldBeType<PartialViewResult>();
                var partialView = (PartialViewResult)filterContext.Result;
                partialView.ViewName.ShouldEqual(MVC.Identity.ConfirmEmail.Views._denied_all);
                partialView.Model.ShouldNotBeNull();
                partialView.Model.ShouldBeType<ConfirmDeniedModel>();
                var model = (ConfirmDeniedModel)partialView.Model;
                model.Reason.ShouldEqual(ConfirmDeniedBecause.IsRetired);
                model.Intent.ShouldEqual(confirmation.Intent);
            }

            [TestMethod]
            public void SetsNoResult_WhenTokenMatchesEntity_Unexpired_Unredeemed_Unretired()
            {
                const string paramName = "some value";
                var confirmation = new EmailConfirmation(EmailConfirmationIntent.ResetPassword)
                {
                    ExpiresOnUtc = DateTime.UtcNow.AddHours(1),
                };
                var entities = new Mock<IQueryEntities>(MockBehavior.Strict).Initialize();
                entities.Setup(m => m.Query<EmailConfirmation>())
                    .Returns(new[] { confirmation }.AsQueryable);
                var attribute = new ValidateConfirmEmailAttribute(paramName)
                {
                    Entities = entities.Object,
                };
                var filterContext = CreateFilterContext(paramName, confirmation.Token);

                attribute.OnActionExecuting(filterContext);

                filterContext.Result.ShouldBeNull();
            }
        }

        private static ActionExecutingContext CreateFilterContext(string tokenKey, object tokenValue, bool? isModeled = null)
        {
            var parameters = new Dictionary<string, object>();
            if (!isModeled.HasValue) isModeled = new Random().Next(0, 1) == 1;
            Debug.Assert(isModeled.HasValue);

            if (tokenKey != null)
            {
                if (isModeled.Value && tokenValue is Guid)
                {
                    var model = new Mock<IModelConfirmAndRedeem>(MockBehavior.Strict);
                    model.Setup(p => p.Token).Returns((Guid)tokenValue);
                    tokenValue = model.Object;
                }
                parameters.Add(tokenKey, tokenValue);
            }

            var filterContext = new Mock<ActionExecutingContext>(MockBehavior.Strict);
            filterContext.Setup(p => p.ActionParameters).Returns(parameters);
            return filterContext.Object;
        }
    }
}
