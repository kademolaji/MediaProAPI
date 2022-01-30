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

    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasData
            (
              new Channel
              {
                  Id =      "7f107726-562e-4b6e-9ebe-722d2b0959de",
                  ApiKey =  "bec30ac8-260f-499a-b421-f1813b687f29",
                  Name = "Partner A",
                  IsActive = true
              },
               new Channel
               {
                   Id =        "3be6a48b-47d4-4cdd-89d5-c02419dd73a9",
                   ApiKey =    "aaac4232-b56d-4add-b508-17b15c39fefc",
                   Name = "Partner B",
                   IsActive = true
               },
                 new Channel
                 {
                     Id =      "8bc3f28c-e64b-4546-9083-b0dad58d1b40",
                     ApiKey =  "2f60912a-333d-4e77-aa58-0d3693d1335b",
                     Name = "Partner C",
                     IsActive = true
                 },
                   new Channel
                   {
                       Id =     "c9d4c053-49b6-410c-bc78-2d54a9991890",
                       ApiKey = "c9d4c053-49b6-410c-bc78-2d54a9966666",
                       Name = "Partner D",
                       IsActive = true
                   }
            );
        }
    }
}
