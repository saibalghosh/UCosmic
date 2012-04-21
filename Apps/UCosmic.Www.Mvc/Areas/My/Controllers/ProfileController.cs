﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using AutoMapper;
using UCosmic.Domain.Identity;
using UCosmic.Www.Mvc.Areas.My.Models;
using UCosmic.Www.Mvc.Controllers;

namespace UCosmic.Www.Mvc.Areas.My.Controllers
{
    [Authorize]
    public partial class ProfileController : BaseController
    {
        private readonly ProfileServices _services;

        public ProfileController(ProfileServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ActionName("profile")]
        [OpenTopTab(TopTabName.Home)]
        public virtual ActionResult Get()
        {
            var user = _services.QueryProcessor.Execute(
                new GetUserByNameQuery
                {
                    Name = User.Identity.Name,
                    EagerLoad = new Expression<Func<User, object>>[]
                    {
                        u => u.Person.Emails,
                        u => u.Person.Affiliations.Select(a => a.Establishment),
                    }
                }
            );

            if (user == null) return HttpNotFound();
            return PartialView(Mapper.Map<ProfileInfo>(user.Person));
        }

    }
}
