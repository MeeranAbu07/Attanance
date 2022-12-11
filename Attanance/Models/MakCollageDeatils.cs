using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class MakCollageDeatils
    {
        [Key]
        public int CollageId { get; set; }
        public string Collage { get; set; }
        public string Course { get; set; }
    }
}
