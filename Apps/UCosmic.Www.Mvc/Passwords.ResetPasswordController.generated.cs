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
namespace UCosmic.Www.Mvc.Areas.Passwords.Controllers {
    public partial class ResetPasswordController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ResetPasswordController(Dummy d) { }

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
        public System.Web.Mvc.ActionResult Post() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Post);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult ValidatePasswordConfirmation() {
            return new T4MVC_JsonResult(Area, Name, ActionNames.ValidatePasswordConfirmation);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ResetPasswordController Actions { get { return MVC.Passwords.ResetPassword; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Passwords";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "ResetPassword";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "ResetPassword";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Get = "reset-password";
            public readonly string Post = "reset-password";
            public readonly string ValidatePasswordConfirmation = "ValidatePasswordConfirmation";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Get = "reset-password";
            public const string Post = "reset-password";
            public const string ValidatePasswordConfirmation = "ValidatePasswordConfirmation";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string _denied_crash = "~/Areas/Passwords/Views/ResetPassword/_denied-crash.cshtml";
            public readonly string _denied_expired = "~/Areas/Passwords/Views/ResetPassword/_denied-expired.cshtml";
            public readonly string _denied_retired = "~/Areas/Passwords/Views/ResetPassword/_denied-retired.cshtml";
            public readonly string reset_password = "~/Areas/Passwords/Views/ResetPassword/reset-password.cshtml";
            static readonly _EditorTemplates s_EditorTemplates = new _EditorTemplates();
            public _EditorTemplates EditorTemplates { get { return s_EditorTemplates; } }
            public partial class _EditorTemplates{
                public readonly string ResetPasswordForm = "ResetPasswordForm";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ResetPasswordController: UCosmic.Www.Mvc.Areas.Passwords.Controllers.ResetPasswordController {
        public T4MVC_ResetPasswordController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Get(UCosmic.Www.Mvc.Areas.Passwords.Models.ResetPasswordQuery query) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Get);
            callInfo.RouteValueDictionary.Add("query", query);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Post(UCosmic.Www.Mvc.Areas.Passwords.Models.ResetPasswordForm model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Post);
            callInfo.RouteValueDictionary.Add("model", model);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult ValidatePasswordConfirmation(UCosmic.Www.Mvc.Areas.Passwords.Models.ResetPasswordForm model) {
            var callInfo = new T4MVC_JsonResult(Area, Name, ActionNames.ValidatePasswordConfirmation);
            callInfo.RouteValueDictionary.Add("model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
