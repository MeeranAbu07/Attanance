using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.ViewModels
{
    public class UserBasicDetailsViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Doj { get; set; }
    }
}
