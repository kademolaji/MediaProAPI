using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotzerMediaPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
              new Product
              {
                  ProductId = "62d85b57-db26-4742-a5ba-fb695c8cc9a2",
                  ProductName = "Website",
                  DisplayName = "Website",
                  Description = "Website Product",
                  ProductType = ProductType.Websites,
                  IsActive  = true
              },
               new Product
               {
                   ProductId = "909b9bcc-a9a2-4ed1-b130-3e9bba11ab77",
                   ProductName = "Paid Search Campaigns",
                   DisplayName = "Paid Search Campaigns",
                   Description = "Paid Search Campaigns Product",
                   ProductType = ProductType.PaidSearchCampaigns,
                   IsActive = true
               }
            );
        }
    }
}