using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.ViewModels
{
    public class TaskDetailsViewModel
    {
        public int Id { get; set; }
        public int UserBasicDetailsId { get; set; }
        public string TaskDetail { get; set; }
        public string ModuleName { get; set; }
        public string ProjectName { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskCompleteDate { get; set; }
    }
}
