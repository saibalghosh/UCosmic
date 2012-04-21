﻿using System.Linq;
using System.Web;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace UCosmic.Www.Mvc.Areas.My.Models
{
    // ReSharper disable UnusedMember.Global
    public class AffiliationValidatorFacts
    // ReSharper restore UnusedMember.Global
    {
        [TestClass]
        public class TheClass
        {
            [TestMethod]
            public void Validates_AffiliationForm()
            {
                var request = new HttpRequest(null, "http://www.site.com", null);
                HttpContext.Current = new HttpContext(request, new HttpResponse(null));
                var container = SimpleDependencyInjector.Bootstrap();

                var validator = container.GetInstance<IValidator<AffiliationForm>>();

                validator.ShouldNotBeNull();
                validator.ShouldBeType<AffiliationValidator>();
            }
        }

        [TestClass]
        public class TheEmployeeOrStudentProperty
        {
            [TestMethod]
            public void IsInvalidWhen_EmployeeOrStudentAffiliation_IsNull()
            {
                var validator = new AffiliationValidator();
                var model = new AffiliationForm { EmployeeOrStudentAffiliation = null };
                var results = validator.Validate(model);
                results.IsValid.ShouldBeFalse();
                results.Errors.Count.ShouldBeInRange(1, int.MaxValue);
                var error = results.Errors.SingleOrDefault(e =>
                    e.PropertyName == AffiliationForm.EmployeeOrStudentAffiliationPropertyName);
                error.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                error.ErrorMessage.ShouldEqual(
                    AffiliationValidator.FailedBecauseEmployeeOrStudentAffiliationWasEmpty);
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void IsValidWhen_EmployeeOrStudentAffiliation_IsNotEmpty()
            {
                var validator = new AffiliationValidator();
                var model = new AffiliationForm
                {
                    EmployeeOrStudentAffiliation = EmployeeOrStudentAffiliate.Neither
                };
                var results = validator.Validate(model);
                var error = results.Errors.SingleOrDefault(e =>
                    e.PropertyName == AffiliationForm.EmployeeOrStudentAffiliationPropertyName);
                error.ShouldBeNull();
            }
        }
    }
}
