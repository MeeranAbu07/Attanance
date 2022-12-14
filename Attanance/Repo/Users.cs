using Attanance.IRepo;
using Attanance.Models;
using Attanance.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public async Task<string> UpdateUser(UserBasicDetailsViewModel userBasicDetails)
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
             _db.UserBasics.Update(userBasicDetails1);
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
                    LeaveReason = attanances.LeaveReason,
                    AttananceDate = attanances.AttananceDate
               };
                if (attanances.Attanance == false)
                {
                    at.LeaveReason = attanances.LeaveReason;
                }
                await _db.attanances.AddAsync(at);
                await _db.SaveChangesAsync();

                return "Created sucessfully";
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<UserBasicDetailsViewModel> GetUserById(int id)
        {
            UserBasicDetailsViewModel userViewModels = await _db.UserBasics.Where(x => x.Id == id).Select((mak) => new UserBasicDetailsViewModel
            {

                Id = mak.Id,
                UserName = mak.UserName,
                Email = mak.Email,
                EmployeeCode = mak.EmployeeCode,
                Dob = mak.Dob,
                Doj = mak.Doj
            }).FirstOrDefaultAsync();

            return userViewModels;
        }
        public async Task<string> DeleteUserById(int id)
        {
            UserBasicDetails userViewModels =  _db.UserBasics.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
                UserBasicDetails userBasicDetails1ss = new UserBasicDetails()
                {
                    Id = userViewModels.Id,
                    UserName = userViewModels.UserName,
                    EmployeeCode = userViewModels.EmployeeCode,
                    Dob = userViewModels.Dob,
                    Email = userViewModels.Email,
                    Doj = userViewModels.Doj

                };
            _db.UserBasics.Remove(userBasicDetails1ss);
            await _db.SaveChangesAsync();

            return "Delete";
        }
        public async Task<List<UserBasicDetailsDemoViewModel>> GetUserList()
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
                List<UserBasicDetailsDemoViewModel> mak = userViewModels.Select(x => new UserBasicDetailsDemoViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    EmployeeCode = x.EmployeeCode
                }).ToList();

                return mak;

            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public async Task<string> CreatePassword(UserPassowrdGenerateViewModel autoPasswordGenerate)
        {
            try
            {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(autoPasswordGenerate.Password);

                byte[] hash = md5.ComputeHash(inputBytes);

                // convert byte array to hex string
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    //to make hex string use lower case instead of uppercase add parameter "X2"
                    sb.Append(hash[i].ToString("X2"));
                }

                UserPassowrdGenerate autoPassword = new()
                {
                    Id = autoPasswordGenerate.Id,
                    Name = autoPasswordGenerate.Name,
                    Password = sb.ToString()
                };

                _db.UserPassowrd.Add(autoPassword);
                _db.SaveChanges();

                return "sucessfull";
            }
            catch (Exception ex)
            {

                throw;
            }
           

        }
    }
}
