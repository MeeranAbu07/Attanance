using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdatedate { get; set; }
        public bool IsActive { get; set; }
        public string LowerRole { get; set; }
        public string Role { get; set; }
        public string  Description { get; set; }
        public string RoleCode { get; set; }
        public int UserTypeId { get; set; }
    }
}
