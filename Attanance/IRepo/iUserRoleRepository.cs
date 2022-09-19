using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
  public  interface iUserRoleRepository
    {
        Task<string> CreateRoles(UserRoleViewModel userRoleViewModel);
        Task<List<GetAllattendanceViewModel>> GetAllattendance(int id);
    }
}
