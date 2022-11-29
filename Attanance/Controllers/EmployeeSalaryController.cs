using Attanance.IRepo;
using Attanance.Models;
using Attanance.ViewModels;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "OKDR7EIlB6Hi7sQUrVAbUdkmkppSxCO2OQ0ENoQD",
            BasePath = "https://attananceapp-default-rtdb.firebaseio.com"
        };
        IFirebaseClient client;




        private readonly IEmployeeRepository mEmployeeRepository;
        private readonly AppDbContext appDbContext;
        public EmployeeSalaryController(IEmployeeRepository employeeRepository, AppDbContext aappDbContext)
        {
            mEmployeeRepository = employeeRepository;
            appDbContext = aappDbContext;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(Employee employeeViewModel)
        {
           
           
           //  client = new FireSharp.FirebaseClient(config);
           // var data = employeeViewModel;
           // PushResponse response = client.Push("Employee/", data.Id);
           // ////bool convert = string.TryParse(employeeViewModel.Id, out string val);
           // //// $(this).data("id")
           // string str = Convert.ToString(employeeViewModel.Id);
           // str  = response.Result.name;
           //// data.FirstName = response.Result.name;
           // SetResponse setResponse = client.Set("Employee/" + data.Id, data);
           // if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
           // {
           //     ModelState.AddModelError(string.Empty, "Added Succesfully");
           // }
           // else
           // {
           //     ModelState.AddModelError(string.Empty, "Something went wrong!!");
           // }


            var responsess = await mEmployeeRepository.CreateEmployee(employeeViewModel);
            return Ok(responsess);
        }
        [HttpPost("CreateSalayList")]
        public async Task<IActionResult> CreateSalary(SalaryListViewModel salaryListViewModel)
        {
            var rsponse = await mEmployeeRepository.CreateSalary(salaryListViewModel);
            return Ok(rsponse);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeListbyId(int id)
        {
           
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse responses = client.Get("Employee/" + id);
                Employee data = JsonConvert.DeserializeObject<Employee>(responses.Body);
         //   return RedirectToAction("Index");

            var response = await mEmployeeRepository.GetEmployeeListById(id);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmplyeee(EmployeeViewModel salaryListViewModel, int id )
        {
            var responsess= await mEmployeeRepository.UpdateEmplyee(salaryListViewModel, id);
            return Ok(responsess);
        }
        [HttpPut("updateId")]
        public async Task<IActionResult> incrementvalue(int id)
        {
            var response = await mEmployeeRepository.incrementvalue(id);
            return Ok(response);
        }

    }
}
