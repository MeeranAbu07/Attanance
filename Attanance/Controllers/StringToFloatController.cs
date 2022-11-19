using Attanance.IRepo;
using Attanance.Models;
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
    public class StringToFloatController : ControllerBase
    {
        private readonly IStringToValueIRepository _repo;

        public StringToFloatController(IStringToValueIRepository stringToValueIRepository)
        {
            _repo = stringToValueIRepository;
        }
        [HttpPost()]
        public IActionResult Authenticate(StringToValueViewModel model)
        {
            var response = _repo.CreateStringToFloatValue(model);
            return Ok(response);
        }
    }
}
