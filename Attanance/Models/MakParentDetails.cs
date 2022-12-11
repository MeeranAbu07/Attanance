using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class MakParentDetails
    {
        [Key]
        public int Id { get; set; }
        public string ParentName { get; set; }

        [ForeignKey("MakUsser")]
        public int MakUserId { get; set; }
    }
}
