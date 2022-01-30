﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Entities
{
    public class OrderLineItemWebSiteDetail : BaseEntity<Guid>
    {
        public Guid OrderLineItemId { get; set; }
        public string TemplateId { get; set; }
        public string WebsiteBusinessName { get; set; }
        public string WebsiteAddressLine1 { get; set; }
        public string WebsiteAddressLine2 { get; set; }
        public string WebsiteCity { get; set; }
        public string WebsiteState { get; set; }
        public string WebsitePostCode { get; set; }
        public string WebsitePhone { get; set; }
        public string WebsiteEmail { get; set; }
        public string WebsiteMobile { get; set; }
    }
}
