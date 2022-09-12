using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class TaskDetails
    {
        public int Id { get; set; }
        [ForeignKey("UserBasicDetails")]
        public int UserBasicDetailsId { get; set; }
        public string TaskDetail { get; set; }
        public string ModuleName { get; set; }
        public string ProjectName { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskCompleteDate { get; set; }
        public UserBasicDetails basicDetails { get; set; }

    }
}
