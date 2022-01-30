using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Contracts.DataContracts.Shared;
using SpotzerMediaPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.ServiceContracts
{
    public interface IAuditTrailService
    {
        void SaveAuditTrail(string details, string endpoint, ActionType actionType, string createdBy);
        Task<ApiResponse<SearchReply<SearchAuditTrailDto>>> SearchAuditTrail(SearchCall<string> options);
    }
}
