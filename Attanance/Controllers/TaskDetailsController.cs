using Attanance.IRepo;
using Attanance.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private readonly ITaskDetails _users;

        public TaskDetailsController(ITaskDetails users)
        {
            _users = users;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskDetailsViewModel taskDetailsViewModel)
        {
            var result = await _users.CreateTaskDetails(taskDetailsViewModel);
            return Ok(result);
        }
    }
}
