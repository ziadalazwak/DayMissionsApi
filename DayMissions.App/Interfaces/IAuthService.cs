
using DayMissions.App.Dtos.Authentication;
using DayMissions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResult>Register(RegisterDto registerDto);
        public Task<AuthResult> Login(LoginDto loginDto);
        public Task<AuthResult> GetToken(IEnumerable<Claim> claims);
    }
}
