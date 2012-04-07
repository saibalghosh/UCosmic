﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.261
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UCosmic.Www.Mvc.Areas.Identity
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SignUpFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SignUp.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Sign Up", "     In order to sign into UCosmic.com\r\n     As a consortium member\r\n     I want " +
                    "to sign up and create a password", ProgrammingLanguage.CSharp, new string[] {
                        "Identity",
                        "SignUp"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Sign Up")))
            {
                UCosmic.Www.Mvc.Areas.Identity.SignUpFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line 8
    testRunner.Given("I browsed to the Sign Up page");
#line hidden
        }
        
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress(string invalidEmail, string buttonLabel, string errorMessage, string eligibleEmail, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SignUpHappy",
                    "SignUpSad",
                    "SignUp01"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Qualify for sign up successfully with an eligible email address after entering an" +
                    " invalid email address", @__tags);
#line 11
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 13
    testRunner.When(string.Format("I type \"{0}\" into the Email Address text box", invalidEmail));
#line 14
    testRunner.And(string.Format("I double click the \"{0}\" button", buttonLabel));
#line 15
    testRunner.Then("I should still see the Sign Up page");
#line 16
    testRunner.And(string.Format("I should see an error message \"{0}\" under the Email Address text box", errorMessage));
#line 17
    testRunner.And("I should not see a \"Congratulations, your email address is eligible!\" message");
#line 18
    testRunner.And("I should not see [green checkmark icon] content");
#line 20
    testRunner.When(string.Format("I type \"{0}\" into the Email Address text box", eligibleEmail));
#line 21
    testRunner.And("I double click the \"Check Eligibility\" button");
#line 22
    testRunner.Then("I should still see the Sign Up page");
#line 23
    testRunner.But(string.Format("I should not see an error message \"{0}\" under the Email Address text box", errorMessage));
#line 24
    testRunner.And("I should see a \"Congratulations, your email address is eligible!\" message");
#line 25
    testRunner.And("I should see [green checkmark icon] content");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Check Eligibility")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "Email Address is required.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@uc.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant0()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("", "Check Eligibility", "Email Address is required.", "new@uc.edu", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "invalid email")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Check Eligibility")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "Please enter a valid email address.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@ucmail.uc.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant1()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("invalid email", "Check Eligibility", "Please enter a valid email address.", "new@ucmail.uc.edu", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "any1@ineligible1.edu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Check Eligibility")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "Sorry, emails ending in \'@ineligible1.edu\' are not eligible at this time.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@suny.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant2()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("any1@ineligible1.edu", "Check Eligibility", "Sorry, emails ending in \'@ineligible1.edu\' are not eligible at this time.", "new@suny.edu", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "any1@uc.edu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Check Eligibility")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "The email \'any1@uc.edu\' has already been signed up.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@umn.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant3()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("any1@uc.edu", "Check Eligibility", "The email \'any1@uc.edu\' has already been signed up.", "new@umn.edu", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Send Confirmation Email")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "Email Address is required.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@uc.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant4()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("", "Send Confirmation Email", "Email Address is required.", "new@uc.edu", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "invalid mail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Send Confirmation Email")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "Please enter a valid email address.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@ucmail.uc.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant5()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("invalid mail", "Send Confirmation Email", "Please enter a valid email address.", "new@ucmail.uc.edu", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 6")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "any1@ineligible2.edu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Send Confirmation Email")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "Sorry, emails ending in \'@ineligible2.edu\' are not eligible at this time.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@suny.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant6()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("any1@ineligible2.edu", "Send Confirmation Email", "Sorry, emails ending in \'@ineligible2.edu\' are not eligible at this time.", "new@suny.edu", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Qualify for sign up successfully with an eligible email address after entering an" +
            " invalid email address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 7")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "any1@umn.edu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ButtonLabel", "Send Confirmation Email")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "The email \'any1@umn.edu\' has already been signed up.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@umn.edu")]
        public virtual void QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress_Variant7()
        {
            this.QualifyForSignUpSuccessfullyWithAnEligibleEmailAddressAfterEnteringAnInvalidEmailAddress("any1@umn.edu", "Send Confirmation Email", "The email \'any1@umn.edu\' has already been signed up.", "new@umn.edu", ((string[])(null)));
        }
        
        public virtual void ReceiveSignUpEmailConfirmationMessageSuccessfullyForEligibleEmailUsingBrowserName(string browserName, string eligibleEmail, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SignUpHappy",
                    "SignUpSad",
                    "SignUp02",
                    "GeneratesEmail",
                    "SignUpResetNewUsers"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Receive sign up email confirmation message successfully for <EligibleEmail> using" +
                    " <BrowserName>", @__tags);
#line 39
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 41
    testRunner.Given(string.Format("I am using the {0} browser", browserName));
#line 43
    testRunner.When(string.Format("I type \"{0}\" into the Email Address text box", eligibleEmail));
#line 44
    testRunner.And("I click the \"Send Confirmation Email\" button");
#line 45
    testRunner.Then("I should see the Sign Up Confirm Email page");
#line 46
    testRunner.And(string.Format("I should see a temporary \"A confirmation email has been sent to {0}\" feedback mes" +
                        "sage", eligibleEmail));
#line 48
    testRunner.When("I click the \"Confirm Email Address\" button");
#line 49
    testRunner.Then("I should still see the Sign Up Confirm Email page");
#line 50
    testRunner.And("I should see an error message \"Please enter a confirmation code.\" under the Confi" +
                    "rmation Code text box");
#line 52
    testRunner.When("I type \"test\" into the Confirmation Code text box");
#line 53
    testRunner.And("I click the \"Confirm Email Address\" button");
#line 54
    testRunner.Then("I should still see the Sign Up Confirm Email page");
#line 55
    testRunner.But("I should see an error message \"Invalid confirmation code, please try again.\" unde" +
                    "r the Confirmation Code text box");
#line 57
    testRunner.When("I receive an email with subject \"Confirm your email address for UCosmic.com\"");
#line 58
    testRunner.And("I type the emailed code into the Confirmation Code text box");
#line 59
    testRunner.And("I click the \"Confirm Email Address\" button");
#line 60
    testRunner.Then("I should see the Sign Up Create Password page");
#line 61
    testRunner.And("I should see a temporary \"Your email address was successfully confirmed\" feedback" +
                    " message");
#line 63
    testRunner.When("I click the \"Create Password\" button");
#line 64
    testRunner.Then("I should still see the Sign Up Create Password page");
#line 65
    testRunner.And("I should see an error message \"Password is required.\" under the Password text box" +
                    "");
#line 66
    testRunner.And("I should see an error message \"Password confirmation is required.\" under the Conf" +
                    "irmation text box");
#line 68
    testRunner.When("I type \"pass\" into the Password text box");
#line 69
    testRunner.And("I click the \"Create Password\" button");
#line 70
    testRunner.Then("I should still see the Sign Up Create Password page");
#line 71
    testRunner.But("I should see an error message \"Your password must be at least 6 characters long (" +
                    "but no more than 100).\" under the Password text box");
#line 72
    testRunner.And("I should see an error message \"Password confirmation is required.\" under the Conf" +
                    "irmation text box");
#line 74
    testRunner.When("I type \"password\" into the Password text box");
#line 75
    testRunner.And("I click the \"Create Password\" button");
#line 76
    testRunner.Then("I should still see the Sign Up Create Password page");
#line 77
    testRunner.But("I should not see any error messages under the Password text box");
#line 78
    testRunner.And("I should see an error message \"Password confirmation is required.\" under the Conf" +
                    "irmation text box");
#line 80
    testRunner.When("I type \"pass\" into the Confirmation text box");
#line 81
    testRunner.And("I click the \"Create Password\" button");
#line 82
    testRunner.Then("I should still see the Sign Up Create Password page");
#line 83
    testRunner.But("I should not see any error messages under the Password text box");
#line 84
    testRunner.And("I should see an error message \"The password and confirmation password do not matc" +
                    "h.\" under the Confirmation text box");
#line 86
    testRunner.When("I type \"password\" into the Confirmation text box");
#line 87
    testRunner.And("I click the \"Create Password\" button");
#line 88
    testRunner.Then("I should see the Sign Up Completed page");
#line 89
    testRunner.And("I should see a temporary \"Your password was created successfully\" feedback messag" +
                    "e");
#line 91
    testRunner.When("I click the \"Sign In\" button");
#line 92
    testRunner.Then("I should still see the Sign Up Completed page");
#line 93
    testRunner.And("I should see an error message \"Password is required.\" under the Password text box" +
                    "");
#line 95
    testRunner.When("I type \"password\" into the Password text box");
#line 96
    testRunner.And("I click the \"Sign In\" button");
#line 97
    testRunner.Then("I should see a page at the \"my/profile\" url");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Receive sign up email confirmation message successfully for <EligibleEmail> using" +
            " <BrowserName>")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp02")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GeneratesEmail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpResetNewUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Chrome")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:BrowserName", "Chrome")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@bjtu.edu.cn")]
        public virtual void ReceiveSignUpEmailConfirmationMessageSuccessfullyForEligibleEmailUsingBrowserName_Chrome()
        {
            this.ReceiveSignUpEmailConfirmationMessageSuccessfullyForEligibleEmailUsingBrowserName("Chrome", "new@bjtu.edu.cn", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Receive sign up email confirmation message successfully for <EligibleEmail> using" +
            " <BrowserName>")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp02")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GeneratesEmail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpResetNewUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Firefox")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:BrowserName", "Firefox")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@usil.edu.pe")]
        public virtual void ReceiveSignUpEmailConfirmationMessageSuccessfullyForEligibleEmailUsingBrowserName_Firefox()
        {
            this.ReceiveSignUpEmailConfirmationMessageSuccessfullyForEligibleEmailUsingBrowserName("Firefox", "new@usil.edu.pe", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Receive sign up email confirmation message successfully for <EligibleEmail> using" +
            " <BrowserName>")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sign Up")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Identity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpHappy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpSad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUp02")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GeneratesEmail")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SignUpResetNewUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Internet Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:BrowserName", "Internet Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EligibleEmail", "new@griffith.edu.au")]
        public virtual void ReceiveSignUpEmailConfirmationMessageSuccessfullyForEligibleEmailUsingBrowserName_InternetExplorer()
        {
            this.ReceiveSignUpEmailConfirmationMessageSuccessfullyForEligibleEmailUsingBrowserName("Internet Explorer", "new@griffith.edu.au", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion