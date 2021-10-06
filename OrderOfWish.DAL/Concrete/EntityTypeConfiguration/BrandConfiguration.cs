using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.DAL.Concrete.EntityTypeConfiguration
{
    class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityAlwaysColumn();
            builder.Property(a => a.BrandName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(100);
            

            builder.HasData(new Brand
            {
                ID = 1,
                BrandName = "Adidas"
                
            });
            
            builder.HasData(new Brand
            {
                ID=2,
                BrandName = "Nike"
                
            });

            builder.HasData(new Brand
            {
                ID=3,
                BrandName = "U.S Polo"
                
            });

            builder.HasData(new Brand
            {
                ID=4,
                BrandName = "The North Face"
                
            });

            builder.HasData(new Brand
            {
                ID = 5,
                BrandName = "Columbia"
                
               
            });
        }
    }
}
