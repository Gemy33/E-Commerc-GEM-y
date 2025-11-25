using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RouteDev.Ecommerc.Domain.Entites.IDentity;
using RouteDev.Ecommerc.Domain.Exceptions.NotFound;
using RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RouteDev.Ecommerc.Services.Services
{
    public class AuthService: IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IConfiguration config,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AuthService> logger)
        {
            _configuration = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<AddressDto> UpdateAddressAsync(string email, AddressDto addressDto)
        {
    
            var user =await _userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email);
            if (user is null) throw new UserNotFoundException(email);
            if (user.Address is null)
            {
                user.Address = new Address()
                {
                    FirstName = addressDto.FirstName,
                    LastName = addressDto.LastName,
                    Street = addressDto.Street,
                    City = addressDto.City,
                    Country = addressDto.Cuntry,
                    UserId = user.Id

                };
            }
            else
            {
                user.Address.FirstName = addressDto.FirstName;
                user.Address.LastName = addressDto.LastName;
                user.Address.Street = addressDto.Street;
                user.Address.City = addressDto.City;
                user.Address.Country = addressDto.Cuntry;
            }
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) throw new Exception("Failed to update address");
            return addressDto;

        }
        public async Task<AddressDto> GetAddressAsync(string email)
        {
            var user = await _userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email) ?? throw new UserNotFoundException(email);
            if (user.Address is null) throw new AddressNotFoundException();
            return new AddressDto()
            {
                FirstName = user.Address.FirstName,
                LastName = user.Address.LastName,
                Street = user.Address.Street,
                City = user.Address.City,
                Cuntry= user.Address.Country,
            };

        }
        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return null;
            return new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                ID = user.Id,
                Token = CreateToken(user)
            };

        }
        public Task<bool> IsEmailExistAsync(string email)
        {
            var exist = _userManager.Users.AnyAsync(u => u.Email == email);
            return exist;
        }
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var ExistUser = await _userManager.FindByEmailAsync(loginDto.Email);
            if (ExistUser is null) throw new InvalidCredentialsException();
            var result = await _signInManager.CheckPasswordSignInAsync(ExistUser, loginDto.Password, lockoutOnFailure: true);
            if (result.IsNotAllowed) throw new Exception("User is not allowed to sign in");
            if (result.IsLockedOut) throw new UserLockedOutException();
            if (!result.Succeeded) throw new InvalidCredentialsException();
            return new UserDto()
            {
                DisplayName = ExistUser.DisplayName,
                Email = ExistUser.Email!,
                ID = ExistUser.Id,
                Token = CreateToken(ExistUser)

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
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));
            return new UserDto()
            {
                
                DisplayName = user.DisplayName,
                Email = user.Email,
                ID = user.Id,
                Token = CreateToken(user)
            };


        }
        private string CreateToken(ApplicationUser user)
        {
            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email!),
                new Claim("DisplayName",user.DisplayName),


            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"], claims, DateTime.UtcNow, DateTime.UtcNow.AddDays(3), signingCredentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.WriteToken(token);
                return jwt;
            }
            catch (Exception ex)
            {
                _logger.LogError("when Generate the token");
                throw new TokenGenerationException();

                
            }
        }

        
    }
}
