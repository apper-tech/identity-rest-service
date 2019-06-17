using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using identity_rest_service.Data;
using identity_rest_service.Dtos;
using identity_rest_service.Helpers;
using identity_rest_service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identity_rest_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserParams userParams)
        {
            var result = await _repo.Register(userParams);

            if (result.Succeeded)
            {
                var user = await _repo.GetUserByName(userParams.UserName);
                var response = new ResponseToReturnDto
                {
                    Result = "success",
                    Data = _mapper.Map<UserToReturnDto>(user)
                };
                return Ok(response);
            }
            else
            {
                return BadRequest(_mapper.Map<ErrorToReturnDto>(IdentityErrors.HandleErrors(result.Errors)));
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserParams userParams)
        {
            var result = await _repo.Login(userParams);

            if (result.SignInResult.Succeeded)
            {
                var response = new ResponseToReturnDto
                {
                    Result = "success",
                    Data = _mapper.Map<UserToReturnDto>(result.Data)
                };
                return Ok(response);
            }
            else
            {
                return BadRequest(_mapper.Map<ErrorToReturnDto>(IdentityErrors.HandleErrors(result.SignInResult)));
            }
        }
        [HttpPost("getNewName")]
        public async Task<IActionResult> CheckAvailableUserNames([FromBody]UserParams userParams)
        {
            var userName = userParams.FirstName.ToLower() + userParams.LastName.ToLower();
            while (await _repo.GetUserByName(userName) != null)
            {
                userName = userName + (new Random()).Next(1, 999).ToString()[0];
            }
            return Ok(userName);
        }
    }
}
