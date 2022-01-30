using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Contracts.DataContracts.Order;
using SpotzerMediaPro.Contracts.ServiceContracts;
using SpotzerMediaPro.Domain.Helpers;
using System;
using System.Threading.Tasks;
using SpotzerMediaPro.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpotzerMediaPro.Common.Interfaces;

namespace SpotzerMediaPro.Services
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly DataContext _context;
        private readonly IAuditTrailService _auditTrail;
        private readonly ILoggerService  _loggerService;
        
        public CreateOrderService(DataContext context, IAuditTrailService auditTrail, ILoggerService loggerService) 
        {
            _context = context;
            _auditTrail = auditTrail;
            _loggerService = loggerService;
        }

        public async Task<ApiResponse<CreateResponse>> CreateOrder(OrderDto model)
        {
            try
            {
                var partnerExist = await _context.Channels.FirstOrDefaultAsync(x => x.Id == model.Partner);
                if (partnerExist == null)
                {
                    _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> getting partner with Partner Id -> [{model.Partner}] does not exist");
                    return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = "Partner does not exist" }, IsSuccess = false };
                }
                if (!partnerExist.IsActive)
                {
                    _loggerService.Info($"[CreateOrderService]  Order with OrderId [{model.OrderId}] -> [{partnerExist.Name}] is not active");
                    return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = "Partner is not active" }, IsSuccess = false };
                }
                var orderExist = await _context.Orders.FirstOrDefaultAsync(x => x.Id == model.OrderId);
                if (orderExist != null)
                {
                    _loggerService.Info($"[CreateOrderService]  Order with OrderId [{model.OrderId}] -> already exist");
                    return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Order with OrderId: [{model.OrderId}] already exist" }, IsSuccess = false };
                }

                if (model.LineItems.Count == 0)
                {
                    _loggerService.Info($"[CreateOrderService]  Order with OrderId [{model.OrderId}] -> No Line item was added to your order");
                    return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = "No Line item was added to your order" }, IsSuccess = false };
                }

                foreach (var item in model.LineItems)
                {
                    var productExist = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == item.ProductID);
                    if (productExist == null)
                    {
                        _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> Product with ProductId [{item.ProductID}] does not exist");
                        return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Product with ProductId [{item.ProductID}] does not exist" }, IsSuccess = false };
                    }
                    if (!productExist.IsActive)
                    {
                        _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> Product with ProductId [{item.ProductID}] is not active");
                        return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Product with ProductId [{item.ProductID}] is not active" }, IsSuccess = false };
                    }

                    if (Enum.GetName(typeof(ProductType), productExist.ProductType) != item.ProductType)
                    {
                        _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> Product Type [{item.ProductType}] does not match ProductId [{item.ProductID}]");
                        return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Product Type [{item.ProductType}] does not match ProductId [{item.ProductID}]" }, IsSuccess = false };
                    }

                    var channelProduct = await _context.ChannelProducts.FirstOrDefaultAsync(x => x.ProductId == item.ProductID && x.ChannelId == model.Partner);
                    if (channelProduct == null)
                    {
                        _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> Product  [{productExist.ProductName}] does not exist for partner [{partnerExist.Name}]");
                        return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Product  [{productExist.ProductName}] does not exist for partner [{partnerExist.Name}]" }, IsSuccess = false };
                    }
                    if (!channelProduct.IsActive)
                    {
                        _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> Product  [{productExist.ProductName}] is not active for partner [{partnerExist.Name}]");
                        return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Product  [{productExist.ProductName}] is not active for partner [{partnerExist.Name}]" }, IsSuccess = false };
                    }
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
                        _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> {order} was added to Order Table");

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
                            _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> {orderLineItems} was added to OrderLineItem Table");
                        }
                        if (adwordCampaigns.Count > 0)
                        {
                            _context.OrderLineItemAdwordCampaigns.AddRange(adwordCampaigns);
                            _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> {adwordCampaigns} was added to OrderLineItemAdwordCampaign Table");
                        }
                        if (webSiteDetails.Count > 0)
                        {
                            _context.OrderLineItemWebSiteDetails.AddRange(webSiteDetails);
                            _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> {webSiteDetails} was added to OrderLineItemWebSiteDetail Table");
                        }

                        result = await _context.SaveChangesAsync() > 0;
                        if (result)
                        {
                            _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> Order was saved successfully");

                            var details = $"Created new Order with OrderId => {model.OrderId}:OrderItemCount = {model.LineItems.Count}";
                            _auditTrail.SaveAuditTrail(details, "Create Order", ActionType.Created, model.SubmittedBy);
                            
                            trans.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] ->  Saving Order failed  {ex.Message}");
                        return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Error encountered {ex.Message}" }, IsSuccess = false };
                    }
                }

                var response = new CreateResponse
                {
                    Status = result,
                    Id = model.OrderId,
                    Message = "Record created successfully"
                };

                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = true;
                apiResponse.ResponseType = response;

                return apiResponse;

            }
            catch (Exception ex)
            {
                _loggerService.Info($"[CreateOrderService] Order with OrderId [{model.OrderId}] -> Error encountered {ex.Message}");
                return new ApiResponse<CreateResponse>() { StatusCode = System.Net.HttpStatusCode.BadRequest, ResponseType = new CreateResponse() { Status = false, Id = "", Message = $"Error encountered {ex.Message}" }, IsSuccess = false };
            }
        }

    }
}
