using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Services
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<UserDto> LoginAsync(LoginDto loginDto);
    }
}
