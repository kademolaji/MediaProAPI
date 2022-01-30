using SpotzerMediaPro.Contracts.DataContracts.Order;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotzerMediaPro.WebAPI.Filters
{

    public class SwaggerMultipleExampleFilter : IMultipleExamplesProvider<OrderDto>
    {
        public IEnumerable<SwaggerExample<OrderDto>> GetExamples()
        {
            // An example without a summary.
            yield return SwaggerExample.Create(
                "Websites product Only",
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

                    }
            );

            yield return SwaggerExample.Create(
               "Paid Search product Only",
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

                   }
           );

            yield return SwaggerExample.Create(
                "Both Websites and Paid Search product",
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
            );
        }
    }
}