using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
  public  interface IValuesNamesRepository
    {
        Task<string> Create(ValuesViewmodel stringValues);
        Task<List<ValuesViewmodelss>> GettValuesById(int id);
    }
}
