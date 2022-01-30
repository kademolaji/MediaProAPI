﻿using SpotzerMediaPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.DataContracts.Shared
{
    public class SearchAuditTrailDto
    {
        public DateTime? ActionDate { get; set; }
        public string ActionBy { get; set; }
        public string Details { get; set; }
        public string IPAddress { get; set; }
        public string HostAddress { get; set; }
        public string Endpoint { get; set; }
        public ActionType ActionType { get; set; }
    }
}
