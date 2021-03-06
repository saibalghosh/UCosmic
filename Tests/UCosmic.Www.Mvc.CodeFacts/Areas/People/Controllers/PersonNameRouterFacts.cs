﻿using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Should;

namespace UCosmic.Www.Mvc.Areas.People.Controllers
{
    public static class PersonNameRouterFacts
    {
        private static readonly string AreaName = MVC.People.Name;

        [TestClass]
        public class TheGenerateDisplayNameRoute
        {
            [TestMethod]
            public void Inbound_WithPost_MapsToPostAction()
            {
                Expression<Func<PersonNameController, ActionResult>> action =
                    controller => controller.GenerateDisplayName(null);
                var url = new PersonNameRouter.GenerateDisplayNameRoute().Url.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Post).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonPost_MapsToNothing()
            {
                var url = new PersonNameRouter.GenerateDisplayNameRoute().Url.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Post).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForPostAction_MapsToUrl()
            {
                Expression<Func<PersonNameController, ActionResult>> action =
                    controller => controller.GenerateDisplayName(null);
                var url = new PersonNameRouter.GenerateDisplayNameRoute().Url.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(AreaName).WithMethod(HttpVerbs.Post)
                    .AppRelativeUrl().ShouldEqual(url);
            }
        }

        [TestClass]
        public class TheAutoCompleteSalutationsRoute
        {
            [TestMethod]
            public void Inbound_WithGet_MapsToAction()
            {
                Expression<Func<PersonNameController, ActionResult>> action =
                    controller => controller.AutoCompleteSalutations(null);
                var url = new PersonNameRouter.AutoCompleteSalutationsRoute().Url.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Get).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonGet_MapsToNothing()
            {
                var url = new PersonNameRouter.AutoCompleteSalutationsRoute().Url.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Get).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForGetAction_MapsToUrl()
            {
                Expression<Func<PersonNameController, ActionResult>> action =
                    controller => controller.AutoCompleteSalutations(null);
                var url = new PersonNameRouter.AutoCompleteSalutationsRoute().Url.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(AreaName).WithMethod(HttpVerbs.Get)
                    .AppRelativeUrl().ShouldEqual(url);
            }
        }

        [TestClass]
        public class TheAutoCompleteSuffixesRoute
        {
            [TestMethod]
            public void Inbound_WithGet_MapsToAction()
            {
                Expression<Func<PersonNameController, ActionResult>> action =
                    controller => controller.AutoCompleteSuffixes(null);
                var url = new PersonNameRouter.AutoCompleteSuffixesRoute().Url.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Get).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonGet_MapsToNothing()
            {
                var url = new PersonNameRouter.AutoCompleteSuffixesRoute().Url.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Get).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForGetAction_MapsToUrl()
            {
                Expression<Func<PersonNameController, ActionResult>> action =
                    controller => controller.AutoCompleteSuffixes(null);
                var url = new PersonNameRouter.AutoCompleteSuffixesRoute().Url.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(AreaName).WithMethod(HttpVerbs.Get)
                    .AppRelativeUrl().ShouldEqual(url);
            }
        }
    }
}
