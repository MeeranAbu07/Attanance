using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class Attanances
    {
        public int Id { get; set; }
        [ForeignKey("UserBasicDetails")]
        public int UserBasicDetailsId{ get; set; }
        public bool Attanance { get; set; }
        public string LeaveReason { get; set; }
        public DateTime AttananceDate { get; set; }
        public UserBasicDetails basicDetails { get; set; }

    }
}
