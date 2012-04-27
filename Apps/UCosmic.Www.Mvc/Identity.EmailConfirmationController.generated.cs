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
namespace UCosmic.Www.Mvc.Areas.Identity.Controllers {
    public partial class EmailConfirmationController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected EmailConfirmationController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ConfirmForPasswordReset() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ConfirmForPasswordReset);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public EmailConfirmationController Actions { get { return MVC.Identity.EmailConfirmation; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Identity";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "EmailConfirmation";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "EmailConfirmation";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string ConfirmForPasswordReset = "confirm-password-reset";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string ConfirmForPasswordReset = "confirm-password-reset";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string confirm_password_reset = "~/Areas/Identity/Views/EmailConfirmation/confirm-password-reset.cshtml";
            static readonly _EditorTemplates s_EditorTemplates = new _EditorTemplates();
            public _EditorTemplates EditorTemplates { get { return s_EditorTemplates; } }
            public partial class _EditorTemplates{
                public readonly string ConfirmEmailForgotPasswordForm = "ConfirmEmailForgotPasswordForm";
                public readonly string ConfirmEmailForm = "ConfirmEmailForm";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_EmailConfirmationController: UCosmic.Www.Mvc.Areas.Identity.Controllers.EmailConfirmationController {
        public T4MVC_EmailConfirmationController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult ConfirmForPasswordReset(System.Guid? token, string secretCode) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ConfirmForPasswordReset);
            callInfo.RouteValueDictionary.Add("token", token);
            callInfo.RouteValueDictionary.Add("secretCode", secretCode);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ConfirmForPasswordReset(UCosmic.Www.Mvc.Areas.Identity.Models.Deprecated.ConfirmEmailForgotPasswordForm model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ConfirmForPasswordReset);
            callInfo.RouteValueDictionary.Add("model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
