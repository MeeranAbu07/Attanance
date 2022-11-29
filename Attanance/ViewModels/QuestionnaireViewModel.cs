using Attanance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.ViewModels
{
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }
        public int InputId { get; set; }
        public string Question { get; set; }
        public bool IsMandatory { get; set; }
        public int TemplateId { get; set; }
        public int WeightAge { get; set; }
        public float EachOptionScore { get; set; }
        List<QuestionnaireOptionsViewModel> questionnaireOptions = new List<QuestionnaireOptionsViewModel>();
    }
}
