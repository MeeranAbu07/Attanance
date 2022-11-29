using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public int InputId { get; set; }
        public string Question { get; set; }
        public bool IsMandatory { get; set; }
        public int TemplateId { get; set; }
        public int WeightAge { get; set; }
        public float EachOptionScore { get; set; }
    }
}
