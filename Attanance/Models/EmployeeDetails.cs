using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime Date { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
    }
}
