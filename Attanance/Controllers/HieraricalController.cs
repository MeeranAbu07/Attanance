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
    public class HieraricalController : ControllerBase
    {
        private readonly IHieraricalRepository _repo;

        public HieraricalController(IHieraricalRepository hieraricalRepository)
        {
            _repo = hieraricalRepository;
        }
        [HttpPost()]
        public IActionResult Authenticate(HieraricalViewModel model)
        {
            var response = _repo.CreateParent(model);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool isRecursive, bool isDownwardDirection)
        {
            var result = await _repo.GetHieraricalById(id,isRecursive,isDownwardDirection);
            return Ok(result);
        }
    }
}
