using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Contracts.DataContracts.Order;
using SpotzerMediaPro.Contracts.ServiceContracts;
using SpotzerMediaPro.Domain.Helpers;
using System;
using System.Threading.Tasks;
using SpotzerMediaPro.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotzerMediaPro.Services
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly DataContext _context;
        private readonly IAuditTrailService _auditTrail;

        public CreateOrderService(DataContext context, IAuditTrailService auditTrail)
        {
            _context = context;
            _auditTrail = auditTrail;
        }

        public async Task<ApiResponse<CreateResponse>> CreateOrder(OrderDto model, long userId)
        {
            try
            {

                if (model.LineItems.Count == 0)
                {
                    return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = "No Line item was added to your order" }, IsSuccess = false };
                }

                var apiResponse = new ApiResponse<CreateResponse>();
                bool result = false;
                using (var trans = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = new Order
                        {
                            Id = model.OrderId,
                            TypeOfOrder = model.TypeOfOrder,
                            SubmittedBy = model.SubmittedBy,
                            CompanyID = model.CompanyID,
                            CompanyName = model.CompanyName,
                            MetaData = JsonConvert.SerializeObject(model.MetaData),
                            ChannelId = model.Partner
                        };
                        _context.Orders.Add(order);

                        List<OrderLineItem> orderLineItems = new List<OrderLineItem>();
                        List<OrderLineItemAdwordCampaign> adwordCampaigns = new List<OrderLineItemAdwordCampaign>();
                        List<OrderLineItemWebSiteDetail> webSiteDetails = new List<OrderLineItemWebSiteDetail>();
                        
                        foreach (var item in model.LineItems)
                        {
                            var orderLineItemId = Guid.NewGuid().ToString();
                            OrderLineItem orderLineItem = new OrderLineItem
                            {
                                Id = orderLineItemId,
                                ProductID = item.ProductID,
                                ProductType = item.ProductType,
                                Notes = item.Notes,
                                Category = item.Category,
                                OrderId = model.OrderId,
                                ChannelId = model.Partner
                            };
                            orderLineItems.Add(orderLineItem);
                            if (item.AdwordCampaign != null)
                            {
                                var adwordCampaignId = Guid.NewGuid().ToString();
                                OrderLineItemAdwordCampaign adwordCampaign = new OrderLineItemAdwordCampaign
                                {
                                    Id = adwordCampaignId,
                                    OrderLineItemId = orderLineItemId,
                                    CampaignName = item.AdwordCampaign.CampaignName,
                                    CampaignAddressLine1 = item.AdwordCampaign.CampaignAddressLine1,
                                    CampaignPostCode = item.AdwordCampaign.CampaignPostCode,
                                    CampaignRadius = item.AdwordCampaign.CampaignRadius,
                                    LeadPhoneNumber = item.AdwordCampaign.LeadPhoneNumber,
                                    SMSPhoneNumber = item.AdwordCampaign.SMSPhoneNumber,
                                    UniqueSellingPoint1 = item.AdwordCampaign.UniqueSellingPoint1,
                                    UniqueSellingPoint2 = item.AdwordCampaign.UniqueSellingPoint2,
                                    UniqueSellingPoint3 = item.AdwordCampaign.UniqueSellingPoint3,
                                    Offer = item.AdwordCampaign.Offer,
                                    DestinationURL = item.AdwordCampaign.DestinationURL,
                                    ChannelId = model.Partner,
                                };
                                adwordCampaigns.Add(adwordCampaign);
                            }

                            if (item.WebsiteDetails != null)
                            {
                                var webSiteDetailId = Guid.NewGuid().ToString();
                                OrderLineItemWebSiteDetail webSiteDetail = new OrderLineItemWebSiteDetail
                                {
                                    Id = webSiteDetailId,
                                    OrderLineItemId = orderLineItemId,
                                    TemplateId = item.WebsiteDetails.TemplateId,
                                    WebsiteBusinessName = item.WebsiteDetails.TemplateId,
                                    WebsiteAddressLine1 = item.WebsiteDetails.TemplateId,
                                    WebsiteAddressLine2 = item.WebsiteDetails.TemplateId,
                                    WebsiteCity = item.WebsiteDetails.TemplateId,
                                    WebsiteState = item.WebsiteDetails.TemplateId,
                                    WebsitePostCode = item.WebsiteDetails.TemplateId,
                                    WebsitePhone = item.WebsiteDetails.TemplateId,
                                    WebsiteEmail = item.WebsiteDetails.TemplateId,
                                    WebsiteMobile = item.WebsiteDetails.TemplateId,
                                    ChannelId = model.Partner,
                                };
                                webSiteDetails.Add(webSiteDetail);
                            }

                        }

                        if (orderLineItems.Count > 0)
                        {
                            _context.OrderLineItems.AddRange(orderLineItems);
                        }
                        if (adwordCampaigns.Count > 0)
                        {
                            _context.OrderLineItemAdwordCampaigns.AddRange(adwordCampaigns);
                        }
                        if (webSiteDetails.Count > 0)
                        {
                            _context.OrderLineItemWebSiteDetails.AddRange(webSiteDetails);
                        }

                        result = await _context.SaveChangesAsync() > 0;
                        if (result)
                        {
                            var details = $"Created new Order with OrderId => {model.OrderId}:OrderItemCount = {model.LineItems.Count}";
                            _auditTrail.SaveAuditTrail(details, "Create Order", ActionType.Created, model.SubmittedBy);
                            trans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Error encountered {ex.Message}" }, IsSuccess = false };
                    }
                }

                var response = new CreateResponse
                {
                    Status = result,
                    Id = userId,
                    Message = "Record created successfully"
                };

                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = true;
                apiResponse.ResponseType = response;

                return apiResponse;

            }
            catch (Exception ex)
            {
                return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Error encountered {ex.Message}" }, IsSuccess = false };
            }
        }

    }
}
