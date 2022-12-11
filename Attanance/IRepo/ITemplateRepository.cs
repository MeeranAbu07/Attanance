using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
    public interface ITemplateRepository
    {
        Task<string> CreateTemplate(TemplateViewModel templateViewModel);
        Task<string> UpdateTemplate(TemplateViewModel templateViewModel);
    }
}
