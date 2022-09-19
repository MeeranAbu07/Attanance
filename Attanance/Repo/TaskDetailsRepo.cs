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
    public class TaskDetailsRepo : ITaskDetails
    {
        private readonly AppDbContext _db;

        public TaskDetailsRepo(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<string> CreateTaskDetails(TaskDetailsViewModel taskDetailsViewModel)
        {
            TaskDetails taskDetailsViewModel1 = new TaskDetails()
            {
                Id = taskDetailsViewModel.Id,
                ModuleName = taskDetailsViewModel.ModuleName,
                ProjectName = taskDetailsViewModel.ProjectName,
                TaskCompleteDate = taskDetailsViewModel.TaskCompleteDate,
                TaskDetail = taskDetailsViewModel.TaskDetail,
                TaskStartDate = taskDetailsViewModel.TaskStartDate,
                UserBasicDetailsId = taskDetailsViewModel.UserBasicDetailsId
            };
           
            _db.TaskDetails.Add(taskDetailsViewModel1);
            _db.SaveChanges();
            return "sucessfully created";
        }

        public async Task<List<TaskDetailsViewModel>> GetTaskList()
        {
            List<TaskDetailsViewModel> taskDetailsViewModels =await _db.TaskDetails.OrderBy(x => x.Id).Select((mak) => new TaskDetailsViewModel
            {
                Id = mak.Id,
                UserBasicDetailsId = mak.UserBasicDetailsId,
                ModuleName =mak.ModuleName,
                ProjectName =mak.ProjectName,
                TaskCompleteDate =mak.TaskCompleteDate,
                TaskDetail =mak.TaskDetail,
                TaskStartDate =mak.TaskStartDate,
                
            }).ToListAsync();

            return taskDetailsViewModels;
        }
    }
}
