using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.DataContracts.Order
{
    public class OrderLineItemDto : BaseOrderLineItems
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public OrderLineItemWebSiteDetailDto WebsiteDetails { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public OrderLineItemAdwordCampaignDto AdwordCampaign { get; set; }
    }
}
