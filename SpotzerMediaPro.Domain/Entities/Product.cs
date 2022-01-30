using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public ProductType ProductType { get; set; }
     
        public bool IsActive { get; set; }
    }
    public enum ProductType
    {
        /*
         * Websites Type
         */
        Websites = 1,

        /*
         * Paid Search Campaigns Type
         */
        PaidSearchCampaigns = 2,
    }
}
