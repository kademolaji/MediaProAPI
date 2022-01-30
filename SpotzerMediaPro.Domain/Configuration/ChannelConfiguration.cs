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
                  Id =      new Guid("7f107726-562e-4b6e-9ebe-722d2b0959de"),
                  ApiKey =  new Guid("bec30ac8-260f-499a-b421-f1813b687f29"),
                  ApiCode = new Guid("4ee50142-0e46-400b-b665-32767b1f6c56"),
                  Name = "Partner A",
                  IsActive = true
              },
               new Channel
               {
                   Id =         new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"),
                   ApiKey =     new Guid("aaac4232-b56d-4add-b508-17b15c39fefc"),
                   ApiCode =    new Guid("ed36abff-aa46-46dd-a20f-c3566df41289"),
                   Name = "Partner B",
                   IsActive = true
               },
                 new Channel
                 {
                     Id =       new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"),
                     ApiKey =   new Guid("2f60912a-333d-4e77-aa58-0d3693d1335b"),
                     ApiCode =  new Guid("6899ffa8-d0da-4e22-87c5-534ad1e468ee"),
                     Name = "Partner C",
                     IsActive = true
                 },
                   new Channel
                   {
                       Id =     new Guid("c9d4c053-49b6-410c-bc78-2d54a9991890"),
                       ApiKey = new Guid("c9d4c053-49b6-410c-bc78-2d54a9966666"),
                       ApiCode =new Guid("c9d4c053-49b6-410c-bc78-2d54a9977777"),
                       Name = "Partner D",
                       IsActive = true
                   }
            );
        }
    }
}
