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

    public class ChannelProductConfiguration : IEntityTypeConfiguration<ChannelProduct>
    {
        public void Configure(EntityTypeBuilder<ChannelProduct> builder)
        {
            builder.HasData
            (
              new ChannelProduct
              {
                  Id = 1,
                  ChannelId = new Guid("7f107726-562e-4b6e-9ebe-722d2b0959de"),
                  ProductId = new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2"),
                  IsActive = true
              },
               new ChannelProduct
               {
                   Id = 2,
                   ChannelId = new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"),
                   ProductId = new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2"),
                   IsActive = true
               },
                 new ChannelProduct
                 {
                     Id = 3,
                     ChannelId = new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"),
                     ProductId = new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77"),
                     IsActive = true
                 },
                   new ChannelProduct
                   {
                       Id = 4,
                       ChannelId = new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"),
                       ProductId = new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2"),
                       IsActive = true
                   },
                     new ChannelProduct
                     {
                         Id = 5,
                         ChannelId = new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"),
                         ProductId = new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77"),
                         IsActive = true
                     },
                       new ChannelProduct
                       {
                           Id = 6,
                           ChannelId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991890"),
                           ProductId = new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77"),
                           IsActive = true
                       }
            );
        }
    }
}