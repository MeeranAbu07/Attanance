using Attanance.IRepo;
using Attanance.Models;
using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Attanance.Repo
{
    public class StringToValueRepository : IStringToValueIRepository
    {
        private readonly AppDbContext _db;

        public StringToValueRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }
        public async Task<string> CreateStringToFloatValue(StringToValueViewModel stringToFloat)
        {
            try
            {
                bool flag = float.TryParse(stringToFloat.value, out float num);
                StringToValue stringToValue = new()
                {
                    Id = stringToFloat.Id,
                    Value = num
                };
                _db.stringToFloats.Add(stringToValue);
                _db.SaveChanges();
                return "suceefully create";

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
