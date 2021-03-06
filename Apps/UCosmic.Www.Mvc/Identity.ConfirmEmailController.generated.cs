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
    public partial class ConfirmEmailController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ConfirmEmailController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Get() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Get);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult ValidateSecretCode() {
            return new T4MVC_JsonResult(Area, Name, ActionNames.ValidateSecretCode);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Post() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Post);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ConfirmEmailController Actions { get { return MVC.Identity.ConfirmEmail; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Identity";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "ConfirmEmail";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "ConfirmEmail";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Get = "confirm-email";
            public readonly string ValidateSecretCode = "ValidateSecretCode";
            public readonly string Post = "confirm-email";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Get = "confirm-email";
            public const string ValidateSecretCode = "ValidateSecretCode";
            public const string Post = "confirm-email";
        }


        static readonly ActionParamsClass_Get s_params_Get = new ActionParamsClass_Get();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Get GetParams { get { return s_params_Get; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Get {
            public readonly string token = "token";
            public readonly string secretCode = "secretCode";
        }
        static readonly ActionParamsClass_ValidateSecretCode s_params_ValidateSecretCode = new ActionParamsClass_ValidateSecretCode();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ValidateSecretCode ValidateSecretCodeParams { get { return s_params_ValidateSecretCode; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ValidateSecretCode {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Post s_params_Post = new ActionParamsClass_Post();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Post PostParams { get { return s_params_Post; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Post {
            public readonly string model = "model";
        }
        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string _denied_all = "~/Areas/Identity/Views/ConfirmEmail/_denied-all.cshtml";
            public readonly string _denied_crash = "~/Areas/Identity/Views/ConfirmEmail/_denied-crash.cshtml";
            public readonly string _form_instructions = "~/Areas/Identity/Views/ConfirmEmail/_form-instructions.cshtml";
            public readonly string _form_legend_text = "~/Areas/Identity/Views/ConfirmEmail/_form-legend-text.cshtml";
            public readonly string _right = "~/Areas/Identity/Views/ConfirmEmail/_right.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ConfirmEmailController: UCosmic.Www.Mvc.Areas.Identity.Controllers.ConfirmEmailController {
        public T4MVC_ConfirmEmailController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Get(System.Guid token, string secretCode) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Get);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "token", token);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "secretCode", secretCode);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult ValidateSecretCode(UCosmic.Www.Mvc.Areas.Identity.Models.ConfirmEmailForm model) {
            var callInfo = new T4MVC_JsonResult(Area, Name, ActionNames.ValidateSecretCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Post(UCosmic.Www.Mvc.Areas.Identity.Models.ConfirmEmailForm model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Post);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
