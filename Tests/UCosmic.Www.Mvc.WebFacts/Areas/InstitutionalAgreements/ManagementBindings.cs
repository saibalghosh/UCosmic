﻿using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UCosmic.Www.Mvc.SpecFlow;
using UCosmic.Www.Mvc.WebDriver;

namespace UCosmic.Www.Mvc.Areas.InstitutionalAgreements
{
    [Binding]
    public class ManagementBindings : BaseStepDefinition
    {
        [Given(@"I did(.*) see  a modal dialog with an Add Institutional Agreement Contact form")]
        [Given(@"I saw(.*) a modal dialog with an Add Institutional Agreement Contact form")]
        [Then(@"I should(.*) see a modal dialog with an Add Institutional Agreement Contact form")]
        public void SeeAddContactFormInModalDialog(string not)
        {
            const string cssSelector = "#simplemodal-container";
            var shouldSee = string.IsNullOrWhiteSpace(not);

            Browsers.ForEach(browser =>
            {
                if (shouldSee)
                {
                    browser.WaitUntil(b => b.TryFindElement(By.CssSelector(cssSelector)) != null,
                        "The Add Institutional Agreement Contact modal dialog was not found by @Browser.");
                    var element = browser.WaitUntil(b => b.FindElement(By.CssSelector(cssSelector)),
                        "The Add Institutional Agreement Contact modal dialog was not found by @Browser.");

                    browser.WaitUntil(b => element.Displayed,
                        "The Add Institutional Agreement Contact modal dialog was not displayed in @Browser.");
                }
                else
                {
                    browser.WaitUntil(b => b.TryFindElement(By.CssSelector(cssSelector)) == null,
                        "The Add Institutional Agreement Contact modal dialog was unexpectedly displayed in @Browser.");
                }
            });
        }

        [When(@"I click the Add Institutional Agreement Contact modal dialog close icon")]
        public void ClickTheModalDialogCloseIcon()
        {
            const string cssSelector = "#simplemodal-container a.modalCloseImg";
            Browsers.ForEach(browser =>
            {
                var link = browser.WaitUntil(b => b.FindElement(By.CssSelector(cssSelector)),
                    "The Add Institutional Agreement Contact modal dialog close icon could not be found using @Browser.");

                browser.WaitUntil(b => link.Displayed,
                    "The Add Institutional Agreement Contact modal dialog close icon was not displayed using @Browser.");

                link.Click();
            });
        }

        [Given(@"I (.*) a help bubble dialog")]
        [When(@"I (.*) a help bubble dialog")]
        [Then(@"I should (.*) a help bubble dialog")]
        public void SeeHelpDialogBubble(string seeOrNot)
        {
            var shouldSee = (seeOrNot.Trim() == "see" || seeOrNot.Trim() == "saw");
            const string cssSelector = ".jquerybubblepopup .help-bubblepop";

            Browsers.ForEach(browser =>
            {
                if (shouldSee)
                {
                    var bubblePopup = browser.WaitUntil(b => b.FindElement(By.CssSelector(cssSelector)),
                        "A help bubble dialog form was not found in @Browser.");

                    browser.WaitUntil(b => bubblePopup.Displayed,
                        "A help bubble dialog form was not displayed in @Browser.");
                }
                else
                {
                    var bubblePopup = browser.WaitUntil(b => b.TryFindElement(By.CssSelector(cssSelector)),
                        "An error occurred while looking for a help bubble dialog in @Browser.");

                    browser.WaitUntil(b => bubblePopup == null || !bubblePopup.Displayed,
                        "A help bubble dialog form was unexpectedly displayed in @Browser.");
                }
            });
        }
    }
}
