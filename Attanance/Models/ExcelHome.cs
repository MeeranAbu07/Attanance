using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class ExcelHome
    {
        [Key]
        public int Id { get; set; }
        public string Aid { get; set; }
        public string RentOrOwn { get; set; }
    }
}
