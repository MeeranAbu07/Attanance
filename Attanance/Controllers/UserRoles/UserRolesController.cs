using Attanance.IRepo;
using Attanance.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attanance.Controllers.UserRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly iUserRoleRepository mUserRoleRepository;
        public UserRolesController(iUserRoleRepository iUserRoleRepository)
        {
            mUserRoleRepository = iUserRoleRepository;
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] UserRoleViewModel userRoleViewModel)
        {
            var response = await mUserRoleRepository.CreateRoles(userRoleViewModel);
            return Ok(response);
        }
        [HttpGet("GetAllattendance")]
        public async Task<IActionResult> GetAllattendance(int id)
        {
            var reponse = await mUserRoleRepository.GetAllattendance(id);
            return Ok(reponse);
        }
    }
}
