using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.DataContracts.Order
{
    public class OrderLineItemDto : BaseOrderLineItems
    {
        public OrderLineItemWebSiteDetailDto WebsiteDetails { get; set; }
        //public WebsiteDetailOrderLineItemDto WebSiteDetails { get; set; }
        public OrderLineItemAdwordCampaignDto AdwordCampaign { get; set; }
    }
}
