using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.ViewModels
{
    public class GetAllattendanceViewModel
    {
        public int Id { get; set; }
        public string AttendanceReason { get; set; }
        public int TotalAttendance { get; set; }
        public int userBasicId { get; set; }
    }
}
