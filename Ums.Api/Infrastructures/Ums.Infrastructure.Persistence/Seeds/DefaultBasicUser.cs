using Microsoft.EntityFrameworkCore;
using System;
using Ums.Domain.Entities;
using Ums.Domain.Enums;

namespace Ums.Infrastructure.Persistence.Seeds
{
    public static class DefaultBasicUser
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var defaultUser = new User
            {
                Id = Guid.NewGuid(),
                Email = "tvkien1992@gmail.com",
                FirstName = "Kien",
                LastName = "Truong",
                Status = UserStatus.Active,
                AzureId = Guid.NewGuid(),
                Created = DateTime.Now,
            };

            modelBuilder.Entity<User>().HasData(defaultUser);
        }
    }
}