using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class ExcelUser
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; }
        public int Age { get; set; }
    }
}
