using Attanance.Models;
using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
    public interface IUsers
    {
        public Task<string> CreateUser(UserBasicDetailsViewModel userBasicDetails);
        public Task<List<UserBasicDetailsViewModel>> GetUserList();
        public Task<UserBasicDetailsViewModel> GetUserById(int id );
        public Task<string> CreateAttanance(AttanancesViewModel attanancesViewModel);
        public Task<string> UpdateUser(UserBasicDetailsViewModel userBasicDetails);
        public Task<string> DeleteUserById(int id);
        public Task<string> CreatePassword(UserPassowrdGenerateViewModel autoPasswordGenerate );


    }
}
