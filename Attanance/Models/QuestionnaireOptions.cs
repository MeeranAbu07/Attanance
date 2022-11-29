using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class QuestionnaireOptions
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public int Options { get; set; }
        public float Score { get; set; }
    }
}
