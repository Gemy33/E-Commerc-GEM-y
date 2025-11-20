using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presentation.Controllers.Auth
{
    public class AuthController : BaseController
    {
        private readonly IserviceManager _serviceManager;

        public AuthController(IserviceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // helper method to get the email from jwtToken
        private string? GetEmail()
        {
            return User.FindFirst(ClaimTypes.Email)?.Value;

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _serviceManager.AuthService.LoginAsync(loginDto);
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await _serviceManager.AuthService.RegisterAsync(registerDto);
            return Ok(user);
        }

        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var isExist = await _serviceManager.AuthService.IsEmailExistAsync(email);
            return Ok(isExist);
        }

        //--Authunteicated end poing

        [HttpGet("GetUser")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUser()
        {

            var email = GetEmail();
            if (email == null)
                return Unauthorized("Email not found in token");
            var UserisExist = await _serviceManager.AuthService.GetUserAsync(email);
            if (UserisExist == null)
                return NotFound("user not found");
            return Ok(UserisExist);
        }
        [HttpGet("GetUserAddress")]
        [Authorize]
        public async Task<ActionResult<bool>> GetAddress()
        {

            var email = GetEmail();
            if (email == null)
                return Unauthorized("Email not found in token");

            var AddressExist = await _serviceManager.AuthService.GetAddressAsync(email);
            return Ok(AddressExist);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<bool>> UpdataAddress(AddressDto dto)
        {
            var email = GetEmail();
            if (email == null)
                return Unauthorized("Email not found in token");

            var Address = await _serviceManager.AuthService.UpdateAddressAsync(email, dto);
            return Ok(Address);
        }
    }
}
