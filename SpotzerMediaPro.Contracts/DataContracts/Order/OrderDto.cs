using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.DataContracts.Order
{
    public class OrderDto
    {
        public string Partner { get; set; }
        public string OrderId { get; set; }   
        public string TypeOfOrder { get; set; }
        public string SubmittedBy { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public ICollection<OrderLineItemDto> LineItems { get; set; }
    }
}

 