using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Entities
{
    public class Order : BaseEntity<string>
    {
        public string TypeOfOrder { get; set; }
        public string SubmittedBy { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string MetaData { get; set; }
        public ICollection<OrderLineItem> OrderLineItem { get; set; }
        
    }
}
