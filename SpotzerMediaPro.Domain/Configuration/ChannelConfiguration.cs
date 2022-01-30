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
                  ApiKey = "spotzer_test_51JUu1MGNU5r3gGaDKd4aZKlcgy0IWF1px7EjZQlnNwfC9IRMy2uPQj3c0ZLhCLhyoHdhSFUXgewCXCN2nJeRWpro00W1qWBesM",
                  Name = "Partner A",
                  IsActive = true
              },
               new Channel
               {
                   Id =        "3be6a48b-47d4-4cdd-89d5-c02419dd73a9",
                   ApiKey = "spotzer_test_51JUu1MGNU5r3gGaDKd4aZKlcgy0IWF1px7EjZQlnNwfC9IRMy2uPQj3c0ZLhCLhyoHdhSFUXgewCXCN2nJeRWpro00W1qLePvT",
                   Name = "Partner B",
                   IsActive = true
               },
                 new Channel
                 {
                     Id =      "8bc3f28c-e64b-4546-9083-b0dad58d1b40",
                     ApiKey = "spotzer_test_51JUu1MGNU5r3gGaDKd4aZKlcgy0IWF1px7EjZQlnNwfC9IRMy2uPQj3c0ZLhCLhyoHdhSFUXgewCXCN2nJeRWpro00W1qAeWVe",
                     Name = "Partner C",
                     IsActive = true
                 },
                   new Channel
                   {
                       Id =     "c9d4c053-49b6-410c-bc78-2d54a9991890",
                       ApiKey = "spotzer_test_51JUu1MGNU5r3gGaDKd4aZKlcgy0IWF1px7EjZQlnNwfC9IRMy2uPQj3c0ZLhCLhyoHdhSFUXgewCXCN2nJeRWpro00W1qreGeFe",
                       Name = "Partner D",
                       IsActive = true
                   }
            );
        }
    }
}
