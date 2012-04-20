// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace UCosmic.Www.Mvc.Areas.My.Controllers {
    public partial class AffiliationController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AffiliationController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Get() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Get);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Put() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Put);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AffiliationController Actions { get { return MVC.My.Affiliation; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "My";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Affiliation";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Affiliation";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Get = "affiliation";
            public readonly string Put = "affiliation";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Get = "affiliation";
            public const string Put = "affiliation";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string _scripts = "~/Areas/My/Views/Affiliation/_scripts.cshtml";
            public readonly string _styles = "~/Areas/My/Views/Affiliation/_styles.cshtml";
            public readonly string affiliation = "~/Areas/My/Views/Affiliation/affiliation.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_AffiliationController: UCosmic.Www.Mvc.Areas.My.Controllers.AffiliationController {
        public T4MVC_AffiliationController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Get(int establishmentId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Get);
            callInfo.RouteValueDictionary.Add("establishmentId", establishmentId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Put(UCosmic.Www.Mvc.Areas.My.Models.AffiliationForm model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Put);
            callInfo.RouteValueDictionary.Add("model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
