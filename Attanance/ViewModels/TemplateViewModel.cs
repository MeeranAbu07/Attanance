using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.ViewModels
{
    public class TemplateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TotalMark { get; set; }

        List<QuestionnaireViewModel> questionnaireViewModels = new List<QuestionnaireViewModel>();
    }
}
