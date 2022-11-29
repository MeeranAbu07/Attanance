using Attanance.Firebase;
using Attanance.IRepo;
using Attanance.Models;
using Attanance.ViewModels;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Repo
{
    public class EmployeeSalaryRepository : IEmployeeRepository

    {

       

        private readonly AppDbContext mappDbContext;
        private readonly firebaseUnity mfirebaseUnity;

        public EmployeeSalaryRepository(AppDbContext appDbContext, firebaseUnity firebaseUnity)
        {
            mappDbContext = appDbContext;
            mfirebaseUnity = firebaseUnity;
        }

        public async Task<string> CreateEmployee(Employee employeeViewModel)
        {
            

            Employee employee = new Employee();

            {

                employee.Id = employeeViewModel.Id;
                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.Token = employeeViewModel.Token;
            }
            await mappDbContext.Employee.AddAsync(employee);
            await mappDbContext.SaveChangesAsync();
            mfirebaseUnity.Create(employee);
          
            return $"{employee.Id}";
        }

        public async Task<string> CreateSalary(SalaryListViewModel salaryListViewModel)
        {
            SalaryList salaryList = new SalaryList();
            {
                salaryList.Id = salaryListViewModel.Id;
                salaryList.TotalSalary = salaryListViewModel.TotalSalary;
                salaryList.Month = salaryListViewModel.Month;
                salaryList.Year = salaryListViewModel.Year;
                salaryList.Salary_Issued = salaryListViewModel.Salary_Issued;
            }
            await mappDbContext.SalaryList.AddAsync(salaryList);
            await mappDbContext.SaveChangesAsync();
            mfirebaseUnity.CreateSalary(salaryList);
            return $"{salaryList.Id}";
        }

        public async Task<List<EmployeeViewModel>> GetEmployeeListById(int id)
        {
            List<EmployeeViewModel> employeeViewModels = await (from emp in mappDbContext.Employee
                                                                where emp.Id == id
                                                                select new EmployeeViewModel
                                                                {
                                                                    Id = emp.Id,
                                                                    FirstName = emp.FirstName,
                                                                    LastName = emp.LastName
                                                                }).ToListAsync();
            return employeeViewModels;
        }

        public async Task<string> incrementvalue(int id)
        {
            Employee employeess = await mappDbContext.Employee.Where(x => x.Id == id).FirstOrDefaultAsync();
            int ids = await mappDbContext.Employee.Where(x => x.Id == id).Select(x => x.Token).FirstOrDefaultAsync();
            employeess.Token = ++ids;
            mappDbContext.Employee.Update(employeess);
            await mappDbContext.SaveChangesAsync();
            //client = new FireSharp.FirebaseClient(config);
            //SetResponse response = client.Set("Employee/" + employeess.Id, employeess);

            return "Update";
        }

        public async Task<string> UpdateEmplyee(EmployeeViewModel salaryListViewModel, int id)
        {
            Employee employee = await mappDbContext.Employee.Where(x => x.Id == id).FirstOrDefaultAsync();

            {
                employee.FirstName = salaryListViewModel.FirstName;
                employee.LastName = salaryListViewModel.LastName;
                employee.Token = salaryListViewModel.Token;
            };
             mappDbContext.Employee.Update(employee);
            await mappDbContext.SaveChangesAsync();
            //client = new FireSharp.FirebaseClient(config);
            //SetResponse response = client.Set("Employee/" + employee.Id, employee);


            return "Updated";

        }
    }
}
