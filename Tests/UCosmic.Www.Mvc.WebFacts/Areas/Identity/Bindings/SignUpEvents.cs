﻿using System;
using System.Linq;
using System.Web.Security;
using TechTalk.SpecFlow;
using UCosmic.Impl.Orm;

namespace UCosmic.Www.Mvc.Areas.Identity
{
    [Binding]
    public class SignUpEvents : TestRunEvents
    {
        [BeforeScenario("UsingFreshExampleUnregisteredEmailAddresses")]
        [AfterScenario("UsingFreshExampleUnregisteredEmailAddresses")]
        public static void ResetExampleUnregisteredEmailAddresses()
        {
            var membersToClear = new[] { "new@bjtu.edu.cn", "new@usil.edu.pe", "new@griffith.edu.au" };
            using (var context = new UCosmicContext(null))
            {
                foreach (var memberToClear in membersToClear)
                {
                    var member = Membership.GetUser(memberToClear);
                    if (member != null)
                        Membership.DeleteUser(memberToClear);

                    var person = context.People.SingleOrDefault(p => p.User != null 
                        && memberToClear.Equals(p.User.Name, StringComparison.OrdinalIgnoreCase))
                        ?? context.People.SingleOrDefault(p => p.Emails.Any(
                            e => memberToClear.Equals(e.Value, StringComparison.OrdinalIgnoreCase)));
                    if (person == null) continue;
                    if (person.User != null)
                        context.Users.Remove(person.User);
                    context.People.Remove(person);
                }
                context.SaveChanges();
            }

        }

    }
}