using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity_rest_service.Data;
using identity_rest_service.Helpers;
using identity_rest_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace identity_rest_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserParams userParams)
        {
            var result = await _repo.Register(userParams);

            if (result.Succeeded)
            {
                var user = await _repo.GetUserByName(userParams.UserName);
                return Ok(("Sign Up Successful", user));
            }
            else
            {
                string errorList = "";
                foreach (var error in result.Errors)
                {
                    errorList += error.Code + "\n";
                }
                return BadRequest(errorList);
            }
        }
        [HttpPost("getNewName")]
        public async Task<IActionResult> CheckAvailableUserNames([FromBody]UserParams userParams)
        {
            var userName = userParams.FirstName.ToLower() + userParams.LastName.ToLower();
            while (await _repo.GetUserByName(userName) != null)
            {
                userName += userName + (new Random()).Next(1, 999);
            }
            return Ok(userName);
        }
    }
}
