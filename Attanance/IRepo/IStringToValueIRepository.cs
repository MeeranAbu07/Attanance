using Attanance.Models;
using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
    public interface IStringToValueIRepository
    {
       public Task<string> CreateStringToFloatValue(StringToValueViewModel stringToFloat);
    }
}
