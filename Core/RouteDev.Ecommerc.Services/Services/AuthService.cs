using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using RouteDev.Ecommerc.Domain.Entites.IDentity;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RouteDev.Ecommerc.Services.Services
{
    public class AuthService(
         IConfiguration _configuration,
         UserManager<ApplicationUser> userManager,
         SignInManager<ApplicationUser> signInManager,
         ILogger<AuthService> _logger ) : IAuthService
        

    {
        

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var ExistUser = await userManager.FindByEmailAsync(loginDto.Email);
            if (ExistUser is null) throw new Exception("Invalide Email or Password");
            var result = await signInManager.CheckPasswordSignInAsync(ExistUser, loginDto.Password,lockoutOnFailure:true);
            if (result.IsNotAllowed) throw new Exception("User is not allowed to sign in");
            if (result.IsLockedOut) throw new Exception("User is locked out");
            if (!result.Succeeded) throw new Exception("Invalide Email or Password");
            return new UserDto()
            {
                UserName = ExistUser.UserName,
                Email = ExistUser.Email,
                ID = ExistUser.Id,
                Token = CreateToken()

            };
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                DisplayName = registerDto.DisplayName

            };
            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));
            return new UserDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                ID = user.Id,
                Token = CreateToken()
            };


        }

       
        private string CreateToken()
        {
            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "user id"),
                new Claim(JwtRegisteredClaimNames.UniqueName, "username"),
                new Claim(JwtRegisteredClaimNames.Email, "user email")
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"], claims,DateTime.UtcNow, DateTime.Now.AddDays(3), signingCredentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.WriteToken(token);
                return jwt;
            }
            catch (Exception ex)
            {
                _logger.LogError("when Generate the token");
                throw new Exception(ex.Message);

                throw;
            }
        }
    }
}
