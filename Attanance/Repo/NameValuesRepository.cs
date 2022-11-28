using Attanance.IRepo;
using Attanance.Models;
using Attanance.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Repo
{
    public class NameValuesRepository : IValuesNamesRepository
    {
        private readonly AppDbContext mappDbContext;
        public NameValuesRepository(AppDbContext appDbContext)
        {
            mappDbContext = appDbContext;
        }

        public async Task<string> Create(ValuesViewmodel stringValues)
        {
            bool convert = float.TryParse(stringValues.ValuesInt, out float val);
            ValuesName valuesNames = new ValuesName();
            {
                valuesNames.Id = stringValues.Id;
                valuesNames.ValuesInt = val;    
            };
            mappDbContext.ValuesName.Add(valuesNames);
            mappDbContext.SaveChanges();
            return "suess";
        }

        public async Task<List<ValuesViewmodelss>> GettValuesById(int id)
        {
            try
            {
                List<ValuesViewmodelss> valuesNameViewModelsss = await (from values in mappDbContext.ValuesName
                                                                      where values.Id == id
                                                                      select new ValuesViewmodelss
                                                                      {
                                                                          Id = values.Id,
                                                                          ValuesInt = values.ValuesInt,
                                                                      }).ToListAsync();
                return valuesNameViewModelsss;
            }
            catch (Exception Ex)
            {

                throw;
            }
         
        }
    }
}
