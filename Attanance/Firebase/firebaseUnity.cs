using Attanance.Models;
using Attanance.Repo;
using Attanance.ViewModels;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Firebase
{
    public class firebaseUnity
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "OKDR7EIlB6Hi7sQUrVAbUdkmkppSxCO2OQ0ENoQD",
            BasePath = "https://attananceapp-default-rtdb.firebaseio.com"
        };
        IFirebaseClient client;

       
        public void Create(Employee employee)
        {

            client = new FireSharp.FirebaseClient(config);
            var data = employee;
            PushResponse response = client.Push("Employee/", data.Id);
            SetResponse setResponse = client.Set("Employee/" + data.Id, data);
        }
        public void CreateSalary(SalaryList salaryList)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = salaryList;
            PushResponse response = client.Push("EmployeeList/", data.Id);
            SetResponse setResponse = client.Set("EmployeeList/" + data.Id, data);
        }

    }
}
