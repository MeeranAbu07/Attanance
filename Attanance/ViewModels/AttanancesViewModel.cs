using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.ViewModels
{
    public class AttanancesViewModel
    {
        public int Id { get; set; }
        public int UserBasicDetailsId { get; set; }
        public bool Attanance { get; set; }
        public string LeaveReason { get; set; }
        public DateTime AttananceDate { get; set; }
    }
}
