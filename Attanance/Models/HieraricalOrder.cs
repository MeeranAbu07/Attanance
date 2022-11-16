using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class HieraricalOrder
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public int? ParentId { get; set; }

    }
}
