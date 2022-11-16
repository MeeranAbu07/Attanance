using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
    public interface IHieraricalRepository
    {
        Task<string> CreateParent(HieraricalViewModel movie);
        public Task<List<HieraricalViewModel>> GetHieraricalById(int id, bool isRecursive, bool isDownwardDirection);


    }
}
