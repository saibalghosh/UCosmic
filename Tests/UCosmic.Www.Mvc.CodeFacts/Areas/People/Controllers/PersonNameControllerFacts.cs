﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;
using UCosmic.Domain.People;
using UCosmic.Www.Mvc.Areas.People.Models;
using UCosmic.Www.Mvc.Controllers;

namespace UCosmic.Www.Mvc.Areas.People.Controllers
{
    public static class PersonNameControllerFacts
    {
        [TestClass]
        public class TheClass
        {
            [TestMethod]
            public void IsDecoratedWith_Authenticate()
            {
                var attribute = Attribute.GetCustomAttribute(typeof(PersonNameController), typeof(AuthenticateAttribute));

                attribute.ShouldNotBeNull();
                attribute.ShouldBeType<AuthenticateAttribute>();
            }
        }

        [TestClass]
        public class TheGenerateDisplayNameMethod
        {
            [TestMethod]
            public void IsDecoratedWith_HttpPost()
            {
                Expression<Func<PersonNameController, ActionResult>> method = m => m.GenerateDisplayName(null);

                var attributes = method.GetAttributes<PersonNameController, ActionResult, HttpPostAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void IsDecoratedWith_OutputCache_UsingAllParams()
            {
                Expression<Func<PersonNameController, ActionResult>> method = m => m.GenerateDisplayName(null);

                var attributes = method.GetAttributes<PersonNameController, ActionResult, OutputCacheAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].VaryByParam.ShouldEqual("*");
            }

            //[TestMethod]
            //public void IsDecoratedWith_OutputCache_UsingServerLocation()
            //{
            //    Expression<Func<PersonNameController, ActionResult>> method = m => m.GenerateDisplayName(null);

            //    var attributes = method.GetAttributes<PersonNameController, ActionResult, OutputCacheAttribute>();
            //    attributes.ShouldNotBeNull();
            //    attributes.Length.ShouldEqual(1);
            //    attributes[0].ShouldNotBeNull();
            //    attributes[0].Location.ShouldEqual(OutputCacheLocation.Server);
            //}

            [TestMethod]
            public void ExecutesQuery_ToGenerateDisplayName()
            {
                var model = new GenerateDisplayNameForm
                {
                    Salutation = "Mr",
                    FirstName = "Adam",
                    MiddleName = "B",
                    LastName = "West",
                    Suffix = "Sr.",
                };
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(
                    It.Is(GenerateDisplayNameQueryBasedOn(model))))
                    .Returns("derived display name");

                controller.GenerateDisplayName(model);

                scenarioOptions.MockQueryProcessor.Verify(m => m.Execute(
                    It.Is(GenerateDisplayNameQueryBasedOn(model))),
                        Times.Once());
            }

            [TestMethod]
            public void ReturnsJson_WithGeneratedDisplayName()
            {
                const string generatedDisplayName = "generated display name";
                var model = new GenerateDisplayNameForm
                {
                    Salutation = "Mr",
                    FirstName = "Adam",
                    MiddleName = "B",
                    LastName = "West",
                    Suffix = "Sr.",
                };
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(
                    It.Is(GenerateDisplayNameQueryBasedOn(model))))
                    .Returns(generatedDisplayName);

                var result = controller.GenerateDisplayName(model);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldEqual(generatedDisplayName);
            }

            private static Expression<Func<GenerateDisplayNameQuery, bool>> GenerateDisplayNameQueryBasedOn(GenerateDisplayNameForm model)
            {
                Expression<Func<GenerateDisplayNameQuery, bool>> generateDisplayNameQueryBasedOn = q =>
                    q.Salutation == model.Salutation &&
                    q.FirstName == model.FirstName &&
                    q.MiddleName == model.MiddleName &&
                    q.LastName == model.LastName &&
                    q.Suffix == model.Suffix
                ;
                return generateDisplayNameQueryBasedOn;
            }
        }

        [TestClass]
        public class TheAutoCompleteSalutationsMethod
        {
            [TestMethod]
            public void IsDecoratedWith_HttpGet()
            {
                Expression<Func<PersonNameController, ActionResult>> method = m => m.AutoCompleteSalutations(null);

                var attributes = method.GetAttributes<PersonNameController, ActionResult, HttpGetAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void IsDecoratedWith_OutputCache_UsingAllParams()
            {
                Expression<Func<PersonNameController, ActionResult>> method = m => m.AutoCompleteSalutations(null);

                var attributes = method.GetAttributes<PersonNameController, ActionResult, OutputCacheAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].VaryByParam.ShouldEqual("*");
            }

            //[TestMethod]
            //public void IsDecoratedWith_OutputCache_UsingServerLocation()
            //{
            //    Expression<Func<PersonNameController, ActionResult>> method = m => m.AutoCompleteSalutations(null);

            //    var attributes = method.GetAttributes<PersonNameController, ActionResult, OutputCacheAttribute>();
            //    attributes.ShouldNotBeNull();
            //    attributes.Length.ShouldEqual(1);
            //    attributes[0].ShouldNotBeNull();
            //    attributes[0].Location.ShouldEqual(OutputCacheLocation.Server);
            //}

            [TestMethod]
            public void ExecutesQuery_ToFindDistinctSalutations()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSalutationsQuery)))
                    .Returns(null as string[]);

                controller.AutoCompleteSalutations(null);

                scenarioOptions.MockQueryProcessor.Verify(m => m.Execute(
                    It.Is(FindDistinctSalutationsQuery)),
                        Times.Once());
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerableData_AllowingGet()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSalutationsQuery)))
                    .Returns(null as string[]);

                var result = controller.AutoCompleteSalutations(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                result.JsonRequestBehavior.ShouldEqual(JsonRequestBehavior.AllowGet);
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerable_IncludingNullValueLabel_AsTopResult()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSalutationsQuery)))
                    .Returns(null as string[]);

                var result = controller.AutoCompleteSalutations(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                var enumerable = (IEnumerable<object>)result.Data;
                dynamic item = enumerable.First();
                string value = item.value;
                string label = item.label;
                value.ShouldEqual(string.Empty);
                label.ShouldEqual(PersonNameController.SalutationAndSuffixNullValueLabel);
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerable_IncludingAllDefaultValues()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSalutationsQuery)))
                    .Returns(null as string[]);

                var result = controller.AutoCompleteSalutations(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                var enumerable = (IEnumerable<object>)result.Data;
                foreach (var anonymous in enumerable)
                {
                    dynamic item = anonymous;
                    string value = item.value;
                    string label = item.label;
                    if (label == PersonNameController.SalutationAndSuffixNullValueLabel) continue;
                    PersonNameController.DefaultSalutationValues.ShouldContain(value);
                    PersonNameController.DefaultSalutationValues.ShouldContain(label);
                }
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerable_IncludingNonDefaultValues()
            {
                var databaseValues = new[] { "S1", "S2" };
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSalutationsQuery)))
                    .Returns(databaseValues);

                var result = controller.AutoCompleteSalutations(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                var enumerable = (IEnumerable<object>)result.Data;
                foreach (var anonymous in enumerable)
                {
                    dynamic item = anonymous;
                    string value = item.value;
                    string label = item.label;
                    if (label == PersonNameController.SalutationAndSuffixNullValueLabel) continue;
                    if (PersonNameController.DefaultSalutationValues.Contains(value)) continue;
                    databaseValues.ShouldContain(value);
                    databaseValues.ShouldContain(label);
                }
            }

            private static Expression<Func<FindDistinctSalutationsQuery, bool>> FindDistinctSalutationsQuery
            {
                get
                {
                    Expression<Func<FindDistinctSalutationsQuery, bool>> findDistinctSalutationsQuery =
                        q => q.Exclude == PersonNameController.DefaultSalutationValues;
                    return findDistinctSalutationsQuery;
                }
            }
        }

        [TestClass]
        public class TheAutoCompleteSuffixesMethod
        {
            [TestMethod]
            public void IsDecoratedWith_HttpGet()
            {
                Expression<Func<PersonNameController, ActionResult>> method = m => m.AutoCompleteSuffixes(null);

                var attributes = method.GetAttributes<PersonNameController, ActionResult, HttpGetAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void IsDecoratedWith_OutputCache_UsingAllParams()
            {
                Expression<Func<PersonNameController, ActionResult>> method = m => m.AutoCompleteSuffixes(null);

                var attributes = method.GetAttributes<PersonNameController, ActionResult, OutputCacheAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].VaryByParam.ShouldEqual("*");
            }

            //[TestMethod]
            //public void IsDecoratedWith_OutputCache_UsingServerLocation()
            //{
            //    Expression<Func<PersonNameController, ActionResult>> method = m => m.AutoCompleteSuffixes(null);

            //    var attributes = method.GetAttributes<PersonNameController, ActionResult, OutputCacheAttribute>();
            //    attributes.ShouldNotBeNull();
            //    attributes.Length.ShouldEqual(1);
            //    attributes[0].ShouldNotBeNull();
            //    attributes[0].Location.ShouldEqual(OutputCacheLocation.Server);
            //}

            [TestMethod]
            public void ExecutesQuery_ToFindDistinctSuffixes()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSuffixesQuery)))
                    .Returns(null as string[]);

                controller.AutoCompleteSuffixes(null);

                scenarioOptions.MockQueryProcessor.Verify(m => m.Execute(
                    It.Is(FindDistinctSuffixesQuery)),
                        Times.Once());
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerableData_AllowingGet()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSuffixesQuery)))
                    .Returns(null as string[]);

                var result = controller.AutoCompleteSuffixes(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                result.JsonRequestBehavior.ShouldEqual(JsonRequestBehavior.AllowGet);
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerable_IncludingNullValueLabel_AsTopResult()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSuffixesQuery)))
                    .Returns(null as string[]);

                var result = controller.AutoCompleteSuffixes(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                var enumerable = (IEnumerable<object>)result.Data;
                dynamic item = enumerable.First();
                string value = item.value;
                string label = item.label;
                value.ShouldEqual(string.Empty);
                label.ShouldEqual(PersonNameController.SalutationAndSuffixNullValueLabel);
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerable_IncludingAllDefaultValues()
            {
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSuffixesQuery)))
                    .Returns(null as string[]);

                var result = controller.AutoCompleteSuffixes(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                var enumerable = (IEnumerable<object>)result.Data;
                foreach (var anonymous in enumerable)
                {
                    dynamic item = anonymous;
                    string value = item.value;
                    string label = item.label;
                    if (label == PersonNameController.SalutationAndSuffixNullValueLabel) continue;
                    PersonNameController.DefaultSuffixValues.ShouldContain(value);
                    PersonNameController.DefaultSuffixValues.ShouldContain(label);
                }
            }

            [TestMethod]
            public void ReturnsJson_WithIEnumerable_IncludingNonDefaultValues()
            {
                var databaseValues = new[] { "S1", "S2" };
                var scenarioOptions = new ScenarioOptions();
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(FindDistinctSuffixesQuery)))
                    .Returns(databaseValues);

                var result = controller.AutoCompleteSuffixes(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.Data.ShouldImplement<IEnumerable<object>>();
                var enumerable = (IEnumerable<object>)result.Data;
                foreach (var anonymous in enumerable)
                {
                    dynamic item = anonymous;
                    string value = item.value;
                    string label = item.label;
                    if (label == PersonNameController.SalutationAndSuffixNullValueLabel) continue;
                    if (PersonNameController.DefaultSuffixValues.Contains(value)) continue;
                    databaseValues.ShouldContain(value);
                    databaseValues.ShouldContain(label);
                }
            }

            private static Expression<Func<FindDistinctSuffixesQuery, bool>> FindDistinctSuffixesQuery
            {
                get
                {
                    Expression<Func<FindDistinctSuffixesQuery, bool>> findDistinctSuffixesQuery =
                        q => q.Exclude == PersonNameController.DefaultSuffixValues;
                    return findDistinctSuffixesQuery;
                }
            }
        }

        private class ScenarioOptions
        {
            internal Mock<IProcessQueries> MockQueryProcessor { get; set; }
        }

        private static PersonNameController CreateController(ScenarioOptions scenarioOptions = null)
        {
            scenarioOptions = scenarioOptions ?? new ScenarioOptions();

            scenarioOptions.MockQueryProcessor = new Mock<IProcessQueries>(MockBehavior.Strict);

            var services = new PersonNameServices(scenarioOptions.MockQueryProcessor.Object);

            var controller = new PersonNameController(services);

            return controller;
        }
    }
}
