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
    public class Users : IUsers
    {
        private readonly AppDbContext _db;

        public Users(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userBasicDetails"></param>
        /// <returns></returns>
        public async Task<string> CreateUser(UserBasicDetailsViewModel userBasicDetails)
        {
           
            
                UserBasicDetails userBasicDetails1 = new UserBasicDetails()
                {
                    Id = userBasicDetails.Id,
                    UserName = userBasicDetails.UserName,
                    EmployeeCode = userBasicDetails.EmployeeCode,
                    Dob = userBasicDetails.Dob,
                    Email = userBasicDetails.Email,
                    Doj = userBasicDetails.Doj

                };
               await _db.UserBasics.AddAsync(userBasicDetails1);
               await _db.SaveChangesAsync();

                return "Created sucessfuylly";
          
           
        }
        public async Task<string> CreateAttanance(AttanancesViewModel attanances)
        {
            try
            {
                Attanances at = new Attanances()
                {
                    Id = attanances.Id,
                    UserBasicDetailsId = attanances.UserBasicDetailsId,
                    Attanance = attanances.Attanance,
                    AttananceDate = attanances.AttananceDate
               };
                if (attanances.Attanance == false)
                {
                    at.LeaveReason = attanances.LeaveReason;
                }
                await _db.attanances.AddAsync(at);
                await _db.SaveChangesAsync();

                return "Created sucessfuylly";
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public Task<UserBasicDetailsViewModel> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserBasicDetailsViewModel>> GetUserList()
        {
            try
            {
                List<UserBasicDetailsViewModel> userViewModels = await _db.UserBasics.OrderBy(x => x.Id).Select((mak) => new UserBasicDetailsViewModel
                {

                    Id = mak.Id,
                    UserName = mak.UserName,
                    Email = mak.Email,
                    EmployeeCode = mak.EmployeeCode,
                    Dob = mak.Dob,
                    Doj = mak.Doj
                }).ToListAsync();

                return userViewModels;

            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }
}
