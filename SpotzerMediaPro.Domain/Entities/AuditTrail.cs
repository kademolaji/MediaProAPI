using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Entities
{
    public partial class AuditTrail : BaseEntity<long>
    {
        public DateTime? ActionDate { get; set; }
        [StringLength(50)]
        public string ActionBy { get; set; }
        [StringLength(2000)]
        public string Details { get; set; }
        [StringLength(50)]
        public string IPAddress { get; set; }
        [StringLength(50)]
        public string HostAddress { get; set; }
        [StringLength(100)]
        public string Endpoint { get; set; }
        [StringLength(100)]
        public ActionType ActionType { get; set; }
    }

    public enum ActionType
    {
        /*
         * Create Action Type
         */
        Created = 1,

        /*
         * Update Action Type
         */
        Updated = 2,

        /*
       * Delete Action Type
       */
        Deleted = 2,
    }
}
