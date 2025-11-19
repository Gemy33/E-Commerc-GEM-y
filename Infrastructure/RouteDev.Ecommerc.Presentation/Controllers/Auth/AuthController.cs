using Microsoft.AspNetCore.Mvc;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presentation.Controllers.Auth
{
    public class AuthController:BaseController
    {
        private readonly IserviceManager _serviceManager;

        public AuthController(IserviceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
           var user= await _serviceManager.AuthService.LoginAsync(loginDto);
            return Ok(user);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await _serviceManager.AuthService.RegisterAsync(registerDto);
            return Ok(user);
        }
    }
}
