﻿namespace UCosmic.Domain.Identity
{
    public static class UserFactory
    {
        public static User Create(string userName, bool isRegstered)
        {
            var user = new User
            {
                Name = userName,
                IsRegistered = isRegstered,
            };
            return user;
        }
    }
}
