using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfControlPrototype.Models
{
    [Table("Notification")]
    public class Notification : BaseEntity
    {
        public Word WordContent { get; set; }
    }
}
