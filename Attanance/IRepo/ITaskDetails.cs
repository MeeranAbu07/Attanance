using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
    public interface ITaskDetails
    {
        public Task<string> CreateTaskDetails(TaskDetailsViewModel taskDetailsViewModel);
        public Task<List<TaskDetailsViewModel>> GetTaskList();


    }
}
