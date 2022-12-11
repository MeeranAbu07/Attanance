using Attanance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        {

        }
        public DbSet<UserBasicDetails> UserBasics { get; set; }
        public DbSet<Attanances> attanances { get; set; }
        public DbSet<TaskDetails> TaskDetails { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<HieraricalOrder> HieraricalOrder { get; set; }

        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<StringToValue> stringToFloats{ get; set; }
        public DbSet<TextFileUpload> TextFileUpload { get; set; }
        public DbSet<UserPassowrdGenerate> UserPassowrd { get; set; }
        public DbSet<TestTable> testTables { get; set; }

        public DbSet<MakUser> MakUsers { get; set; }
        public DbSet<MakParentDetails> MakParents { get; set; }
        public DbSet<MakCollageDeatils> MakCollages { get; set; }



        public DbSet<ExcelHome> ExcelHomes { get; set; }
        public DbSet<ExcelAddress> excelAddresses { get; set; }
        public DbSet<ExcelUser> ExcelUsers { get; set; }

        public DbSet<ExcelUserss> ExcelUsersses { get; set; }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<SalaryList> SalaryList { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<ValuesName> ValuesName { get; set; }

    }
}
