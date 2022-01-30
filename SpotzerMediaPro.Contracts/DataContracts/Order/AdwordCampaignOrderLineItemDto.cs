using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.DataContracts.Order
{
    public class AdwordCampaignOrderLineItemDto : BaseOrderLineItems
    {
        public OrderLineItemAdwordCampaignDto AdWordCampaign { get; set; }
    }
}
