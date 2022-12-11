using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Models
{
    public class SalaryList
    {
        public int Id { get; set; }
        public int TotalSalary { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool Salary_Issued { get; set; }
    }
}
