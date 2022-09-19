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
    public class UserRoleRepository : iUserRoleRepository
    {
        private readonly AppDbContext mAppDbContext;
        public UserRoleRepository(AppDbContext iAppDbContext)
        {
            mAppDbContext = iAppDbContext;
        }

        public async Task<string> CreateRoles(UserRoleViewModel userRoleViewModel)
        {
            try
            {
                UserRole userRole = new UserRole()
                {
                    Id = userRoleViewModel.Id,
                    CreateTime = DateTime.UtcNow,
                    LastUpdatedate = DateTime.Now,
                    IsActive = true,
                    LowerRole = userRoleViewModel.LowerRole,
                    Role = userRoleViewModel.Role,
                    Description = userRoleViewModel.Description,
                    RoleCode = userRoleViewModel.RoleCode,
                    UserTypeId = userRoleViewModel.UserTypeId
                };
                mAppDbContext.UserRole.Add(userRole);
                 mAppDbContext.SaveChangesAsync();
                return $"Added-{userRole.Id}";
            }
            catch (Exception Ex)
            {

                throw new Exception(Ex.Message);
            }
           
        }

        public async Task<List<GetAllattendanceViewModel>> GetAllattendance(int id)
        {
            List<GetAllattendanceViewModel> models = await mAppDbContext.attanances.Where(x => x.UserBasicDetailsId == id).Select(x => new GetAllattendanceViewModel
            { 
                Id = x.Id,
                AttendanceReason = x.LeaveReason,
                userBasicId = x.UserBasicDetailsId

            }).ToListAsync();
            List<int> userIds = mAppDbContext.attanances.Select(x => x.UserBasicDetailsId).ToList();
            List<UserBasicDetails> userBasicDetails = mAppDbContext.UserBasics.Where(x => userIds.Contains(x.Id)).ToList();
            foreach (GetAllattendanceViewModel addendance in models)
            {
                addendance.TotalAttendance = userBasicDetails.Where(x => x.Id.Equals(addendance.userBasicId)).ToList().Count();
            }
            return models;
        }
    }
}
