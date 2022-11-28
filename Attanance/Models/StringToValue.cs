using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class StringToValue
    {
        [Key]
        public int Id { get; set; }
        public float Value { get; set; }
    }
}
