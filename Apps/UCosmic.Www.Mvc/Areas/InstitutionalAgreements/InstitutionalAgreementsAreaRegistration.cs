﻿using System.Web.Mvc;
using UCosmic.Www.Mvc.Areas.InstitutionalAgreements.Mappers;
using UCosmic.Www.Mvc.Areas.InstitutionalAgreements.Models.ManagementForms;

namespace UCosmic.Www.Mvc.Areas.InstitutionalAgreements
{
    public class InstitutionalAgreementsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "InstitutionalAgreements"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            ManagementFormsRouteMapper.RegisterRoutes(context);

            //ManagementFormsModelMapper.RegisterProfiles();
            InstitutionalAgreementProfiler.RegisterProfiles();
            InstitutionalAgreementContactProfiler.RegisterProfiles();
            InstitutionalAgreementFileProfiler.RegisterProfiles();
            InstitutionalAgreementDeriveTitleProfiler.RegisterProfiles();
            InstitutionalAgreementSearchResultProfiler.RegisterProfiles();
            InstitutionalAgreementMapSearchResultProfiler.RegisterProfiles();
            InstitutionalAgreementParticipantMarkerProfiler.RegisterProfiles();
            InstitutionalAgreementUmbrellaOptionProfiler.RegisterProfiles();
            InstitutionalAgreementParticipantFormProfiler.RegisterProfiles();
            InstitutionalAgreementFileFormProfiler.RegisterProfiles();

            ConfigurationFormsRouteMapper.RegisterRoutes(context);
            ConfigurationFormsModelMapper.RegisterProfiles();

            PublicSearchRouteMapper.RegisterRoutes(context);
            PublicSearchModelMapper.RegisterProfiles();

            //context.MapRoute(
            //    "InstitutionalAgreements_default",
            //    "InstitutionalAgreements/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
