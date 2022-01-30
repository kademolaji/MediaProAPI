using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Domain.Entities
{
    public class BaseEntity<TPrimaryKey>
    {
        public BaseEntity()
        {
            IsDeleted = false;
            CreatedOn = DateTimeOffset.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }
        public Guid ChannelId { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public bool IsDeleted { get; set; }
    }
}
