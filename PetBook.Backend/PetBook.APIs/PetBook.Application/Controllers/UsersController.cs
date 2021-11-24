using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetBook.Domain.UsersDomain;
using PetBook.Services.UsersServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBook.APIs.Application
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users/")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try {
                await _userService.AddUser(user);
                return Ok("User was Created");
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("users/")]
        public async Task<IActionResult> GetAllUsers()
        {
            try {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("users/")]
        [Authorize( Roles = "admin")]
        public async Task<IActionResult> DeleteUsers()
        {
            try {
                await _userService.DeleteUsers();
                return Ok("Users were deleted");
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("users/auth")]
        public async Task<IActionResult> AuthUser([FromBody] LoginData logindData)
        {
            try {
                var user = new User();
                if (_userService.Auth(logindData.Name, logindData.Password, out user)) 
                    return Ok(new { Token = _userService.GenerateUserToken(user) });
                return Unauthorized("Username or password is wrong");
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
