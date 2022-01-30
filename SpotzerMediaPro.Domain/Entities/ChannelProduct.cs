using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Entities
{
    public class ChannelProduct: BaseEntity<long>
    {
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
