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
    public class ValuesNameController : ControllerBase
    {
        private readonly IValuesNamesRepository mvaluesNames;
        public ValuesNameController(IValuesNamesRepository valuesNames)
        {
            mvaluesNames = valuesNames;
        }
        [HttpPost("createValues")]
        public async Task<IActionResult> CreateValues(ValuesViewmodel valuesNameViewModel)
        {
            var response = await mvaluesNames.Create(valuesNameViewModel);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var reponse = await mvaluesNames.GettValuesById(id);
            return Ok(reponse);
        }
    }
}
