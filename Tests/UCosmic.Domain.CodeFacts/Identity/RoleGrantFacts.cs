﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using UCosmic.Domain.Establishments;

namespace UCosmic.Domain.Identity
{
    public static class RoleGrantFacts
    {
        [TestClass]
        public class UserProperty
        {
            [TestMethod]
            public void HasGetSet()
            {
                var value = new User();
                var entity = new RoleGrant { User = value };
                entity.ShouldNotBeNull();
                entity.User.ShouldEqual(value);
            }

            [TestMethod]
            public void IsVirtual()
            {
                new RoleGrantRuntimeEntity();
            }
            private class RoleGrantRuntimeEntity : RoleGrant
            {
                public override User User
                {
                    get { return null; }
                    protected internal set { }
                }
            }
        }

        [TestClass]
        public class RoleProperty
        {
            [TestMethod]
            public void HasGetSet()
            {
                var value = new Role();
                var entity = new RoleGrant { Role = value };
                entity.ShouldNotBeNull();
                entity.Role.ShouldEqual(value);
            }

            [TestMethod]
            public void IsVirtual()
            {
                new RoleGrantRuntimeEntity();
            }
            private class RoleGrantRuntimeEntity : RoleGrant
            {
                public override Role Role
                {
                    get { return null; }
                    protected internal set { }
                }
            }
        }

        [TestClass]
        public class ForEstablishmentProperty
        {
            [TestMethod]
            public void HasGetSet()
            {
                var value = new Establishment();
                var entity = new RoleGrant { ForEstablishment = value };
                entity.ShouldNotBeNull();
                entity.ForEstablishment.ShouldEqual(value);
            }

            [TestMethod]
            public void IsVirtual()
            {
                new RoleGrantRuntimeEntity();
            }
            private class RoleGrantRuntimeEntity : RoleGrant
            {
                public override Establishment ForEstablishment
                {
                    get { return null; }
                    protected internal set { }
                }
            }
        }
    }
}
