using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class UserBasicDetails
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Doj { get; set; }
    }
}
