using Attanance.Models;
using Attanance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.IRepo
{
   public interface IEmployeeRepository
    {
        Task<string> CreateEmployee(Employee employeeViewModel); 
        Task<string> CreateSalary(SalaryListViewModel salaryListViewModel);
        Task<List<EmployeeViewModel>> GetEmployeeListById(int id);
        Task<string> UpdateEmplyee(EmployeeViewModel salaryListViewModel, int id);
        Task<string> incrementvalue(int id);
    }
}
