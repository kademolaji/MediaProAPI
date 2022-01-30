using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Entities
{
    public class Channel
    {
        [Key]
        public string Id { get; set; }
        public string ApiKey { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
