using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class TextFileUpload
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
    }
}
