using SpotzerMediaPro.Contracts.DataContracts.Order;
using SpotzerMediaPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Tests.Utils
{
    public static class SpotzerMediaProFaker
    {
        public static ICollection<Channel> GetChannels()
        {
            return new List<Channel>
            {
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
            };
        }

        public static ICollection<Product> GetProducts()
        {
            return new List<Product>
            {
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
            };
        }
        public static ICollection<ChannelProduct> GetChannelProducts()
        {
            return new List<ChannelProduct>
            {
                new ChannelProduct
              {
                  Id = 1,
                  ChannelId = "7f107726-562e-4b6e-9ebe-722d2b0959de",
                  ProductId = "62d85b57-db26-4742-a5ba-fb695c8cc9a2",
                  IsActive = true
              },
               new ChannelProduct
               {
                   Id = 2,
                   ChannelId =  "3be6a48b-47d4-4cdd-89d5-c02419dd73a9",
                   ProductId =  "62d85b57-db26-4742-a5ba-fb695c8cc9a2",
                   IsActive = true
               },
                 new ChannelProduct
                 {
                     Id = 3,
                     ChannelId = "3be6a48b-47d4-4cdd-89d5-c02419dd73a9",
                     ProductId = "909b9bcc-a9a2-4ed1-b130-3e9bba11ab77",
                     IsActive = true
                 },
                   new ChannelProduct
                   {
                       Id = 4,
                       ChannelId ="8bc3f28c-e64b-4546-9083-b0dad58d1b40",
                       ProductId = "62d85b57-db26-4742-a5ba-fb695c8cc9a2",
                       IsActive = true
                   },
                     new ChannelProduct
                     {
                         Id = 5,
                         ChannelId = "8bc3f28c-e64b-4546-9083-b0dad58d1b40",
                         ProductId = "909b9bcc-a9a2-4ed1-b130-3e9bba11ab77",
                         IsActive = true
                     },
                       new ChannelProduct
                       {
                           Id = 6,
                           ChannelId = "c9d4c053-49b6-410c-bc78-2d54a9991890",
                           ProductId = "909b9bcc-a9a2-4ed1-b130-3e9bba11ab77",
                           IsActive = true
                       }
            };
        }

        public static ICollection<OrderDto> GetOrders()
        {
            return new List<OrderDto>
            {
                  new OrderDto
                    {
                        Partner = "7f107726-562e-4b6e-9ebe-722d2b0959de",
                        OrderId = "sample string1",
                        TypeOfOrder = "sample string 8",
                        SubmittedBy = "sample string 11",
                        CompanyName = "sample string 29",
                        CompanyID = "sample string 28",
                        MetaData = new Dictionary<string, string>()
                        {
                            {"AdditionalProperty1", "AdditionalProperty1 Value"},
                            {"AdditionalProperty2", "AdditionalProperty2 Value"},
                            {"AdditionalProperty3", "AdditionalProperty3 Value"}
                        },
                        LineItems = new List<OrderLineItemDto>()
                        {
                            new OrderLineItemDto
                            {
                               ID =1,
                               ProductID ="62d85b57-db26-4742-a5ba-fb695c8cc9a2",
                               ProductType ="Websites",
                               Notes = "sample string 53",
                               Category ="sample string 245",
                               WebsiteDetails = new OrderLineItemWebSiteDetailDto
                               {
                                   TemplateId ="sample string 245",
                                   WebsiteBusinessName = "sample string 245",
                                   WebsiteAddressLine1 = "sample string 246",
                                   WebsiteAddressLine2 = "sample string 247",
                                   WebsiteCity =  "sample string 248",
                                   WebsiteState = "sample string 249",
                                   WebsitePostCode ="sample string 250",
                                   WebsitePhone = "sample string 257",
                                   WebsiteEmail = "sample string 258",
                                   WebsiteMobile =  "sample string 259",
                               }
                            }

                        }
                    },
                  new OrderDto
                   {
                       Partner = "c9d4c053-49b6-410c-bc78-2d54a9991890",
                       OrderId = "sample string1",
                       TypeOfOrder = "sample string 8",
                       SubmittedBy = "sample string 11",
                       CompanyName = "sample string 29",
                       CompanyID = "sample string 28",
                       MetaData = new Dictionary<string, string>()
                       {
                            {"AdditionalProperty1", "AdditionalProperty1 Value"},
                            {"AdditionalProperty2", "AdditionalProperty2 Value"},
                            {"AdditionalProperty3", "AdditionalProperty3 Value"}
                       },
                       LineItems = new List<OrderLineItemDto>()
                       {
                            new OrderLineItemDto
                            {
                               ID =1,
                               ProductID ="909b9bcc-a9a2-4ed1-b130-3e9bba11ab77",
                               ProductType ="PaidSearchCampaigns",
                               Notes = "sample string 53",
                               Category ="sample string 245",
                               AdwordCampaign = new OrderLineItemAdwordCampaignDto
                               {
                                   CampaignName = "sample string 1",
                                   CampaignAddressLine1="sample string 2",
                                   CampaignPostCode = "sample string 6",
                                   CampaignRadius = "sample string 13",
                                   LeadPhoneNumber = "sample string 14",
                                   SMSPhoneNumber = "sample string 15",
                                   UniqueSellingPoint1= "sample string 18",
                                   UniqueSellingPoint2 = "sample string 19",
                                   UniqueSellingPoint3 = "sample string 20",
                                   Offer = "sample string 21",
                                   DestinationURL= "sample string 23",
                               }
                            }

                       }

                   },
                  new OrderDto
                      {
                          Partner = "3be6a48b-47d4-4cdd-89d5-c02419dd73a9",
                          OrderId = "sample string1",
                          TypeOfOrder = "sample string 8",
                          SubmittedBy = "sample string 11",
                          CompanyName = "sample string 29",
                          CompanyID = "sample string 28",
                          MetaData = new Dictionary<string, string>()
                        {
                            {"AdditionalProperty1", "AdditionalProperty1 Value"},
                            {"AdditionalProperty2", "AdditionalProperty2 Value"},
                            {"AdditionalProperty3", "AdditionalProperty3 Value"}
                        },
                          LineItems = new List<OrderLineItemDto>()
                        {
                            new OrderLineItemDto
                            {
                               ID =1,
                               ProductID ="62d85b57-db26-4742-a5ba-fb695c8cc9a2",
                               ProductType ="Websites",
                               Notes = "sample string 53",
                               Category ="sample string 245",
                               WebsiteDetails = new OrderLineItemWebSiteDetailDto
                               {
                                   TemplateId ="sample string 245",
                                   WebsiteBusinessName = "sample string 245",
                                   WebsiteAddressLine1 = "sample string 246",
                                   WebsiteAddressLine2 = "sample string 247",
                                   WebsiteCity =  "sample string 248",
                                   WebsiteState = "sample string 249",
                                   WebsitePostCode ="sample string 250",
                                   WebsitePhone = "sample string 257",
                                   WebsiteEmail = "sample string 258",
                                   WebsiteMobile =  "sample string 259",
                               }
                            },
                            new OrderLineItemDto
                            {
                               ID =1,
                               ProductID ="909b9bcc-a9a2-4ed1-b130-3e9bba11ab77",
                               ProductType ="PaidSearchCampaigns",
                               Notes = "sample string 53",
                               Category ="sample string 245",
                               AdwordCampaign = new OrderLineItemAdwordCampaignDto
                               {
                                   CampaignName = "sample string 1",
                                   CampaignAddressLine1="sample string 2",
                                   CampaignPostCode = "sample string 6",
                                   CampaignRadius = "sample string 13",
                                   LeadPhoneNumber = "sample string 14",
                                   SMSPhoneNumber = "sample string 15",
                                   UniqueSellingPoint1= "sample string 18",
                                   UniqueSellingPoint2 = "sample string 19",
                                   UniqueSellingPoint3 = "sample string 20",
                                   Offer = "sample string 21",
                                   DestinationURL= "sample string 23",
                               }
                            }

                        }

                      }
            };
        }
    }
}