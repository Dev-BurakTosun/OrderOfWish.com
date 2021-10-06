using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.DAL.Concrete.EntityTypeConfiguration
{
    class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityAlwaysColumn();
            builder.Property(a => a.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(a => a.City).HasMaxLength(40);
            builder.Property(a => a.Country).HasMaxLength(40);
            builder.Property(a => a.Address).HasMaxLength(50);
            builder.Property(a => a.PhoneNumber).HasMaxLength(18);
            builder.Property(a => a.Email).HasMaxLength(40);           

            builder.HasData(new Supplier
            {
                ID = 1,
                CompanyName = "US.ForU",
                City = "Oregon,USA",
                Address = "Behind the Oregon Cemetery",
                PhoneNumber = "12345678890",
                Email = "usforu@oregon.com"
            });
            builder.HasData(new Supplier
            {
                ID = 2,
                CompanyName = "ForLoveAndPeace",
                City = "California,USA",
                Address = "Behind the California Cemetery",
                PhoneNumber = "0987654321",
                Email = "peaceangel@for.com"
            });
            builder.HasData(new Supplier
            {
                ID = 3,
                CompanyName = "dunnowhatUwant",
                City = "Anywhere in USA",
                Address = "Just Cemetery",
                PhoneNumber = "1238763458",
                Email = "imjustdiedbro@our.com"
            });
            builder.HasData(new Supplier
            {
                ID = 4,
                CompanyName = "Oh Really?",
                City = "what u want from me?",
                Address = "im a visiter too mate",
                PhoneNumber = "23456787609",
                Email = "jesuschrist@man.wow"
            });
        }
    }
}
