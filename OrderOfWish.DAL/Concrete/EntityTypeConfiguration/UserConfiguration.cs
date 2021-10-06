using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderOfWish.Model.Entities;
using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.DAL.Concrete.EntityTypeConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityAlwaysColumn();
            builder.Property(a => a.Email).HasMaxLength(30).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(10).IsRequired();
            builder.Property(a => a.FirstName).HasMaxLength(15).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(15).IsRequired();
            builder.Property(a => a.PhoneNumber).HasMaxLength(18).IsRequired();
            builder.Property(a => a.Address).HasMaxLength(100).IsRequired();
            builder.HasIndex(a => a.Email).IsUnique();

            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Burak",
                LastName = "Tosun",
                Email = "burak.tosun53.bt@gmail.com",
                Password = "1907",
                Address = "Kadıköy",
                Gender = Gender.Male,
                Role = UserRole.Administrator,
                PhoneNumber = "05344155423",
                IsActive = true
            });

            builder.HasData(new User
            {
                ID = 2,
                FirstName = "Eser",
                LastName = "Kukul",
                Email="eser.kukul@remax.com",
                Password="1905",
                Address="Beykoz",
                Gender= Gender.Male,
                Role=UserRole.Administrator,
                PhoneNumber="05424352345",
                IsActive=true
            });
        }
    }
}
