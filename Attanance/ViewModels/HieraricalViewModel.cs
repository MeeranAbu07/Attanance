using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.ViewModels
{
    public class HieraricalViewModel
    {
        public int Id { get; set; }

        public string ParentName { get; set; }
        public int ? ParentId { get; set; }
        //public List<HieraricalViewModel> child { get; set; }  = new List<HieraricalViewModel>();
    }
}
