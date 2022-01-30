using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.DataContracts.Order
{
    public class BaseOrderLineItems
    {
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string ProductType { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
    }
}
