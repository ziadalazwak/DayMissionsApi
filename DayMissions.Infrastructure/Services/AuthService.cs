using DayMissions.App.Dtos.Authentication;
using DayMissions.App.Interfaces;
using DayMissions.Domain.Entities;
using DayMissions.Infrastructure; // ApplicationUser is now in Infrastructure
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<AuthResult> GetToken(IEnumerable<Claim> claims)
        {
            var jwtSection = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
     issuer: jwtSection["Issuer"],
     audience: jwtSection["Audience"],
     claims: claims,
     expires: DateTime.UtcNow.AddDays(5),
     signingCredentials: creds // ✅ Add this
 );

            return new AuthResult
            {
                Success = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Errors = null
            };
        }

        public async Task<AuthResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                return new AuthResult
                {
                    Success = false,
                    Token = null,
                    Errors = new List<string> { "User not found." }
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                return await GetToken(claims);
            }
            return new AuthResult
            {
                Success = false,
                Token = null,
                Errors = new List<string> { "Invalid password." }
            };
        }

        public async Task<AuthResult> Register(RegisterDto registerDto)
        {
            if (registerDto == null || string.IsNullOrEmpty(registerDto.UserName) || string.IsNullOrEmpty(registerDto.Password))
            {
                return new AuthResult
                {
                    Success = false,
                    Token = null,
                    Errors = new List<string> { "Invalid input." }
                };
            }
            var check = await _userManager.FindByNameAsync(registerDto.UserName);
            if (check != null)
            {
                return new AuthResult
                {
                    Success = false,
                    Token = null,
                    Errors = new List<string> { "User already exists." }
                };
            }
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                // Registration successful, do NOT return token
                return new AuthResult
                {
                    Success = true,
                    Token = null,
                    Errors = null
                };
            }
            else
            {
                return new AuthResult
                {
                    Success = false,
                    Token = null,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
        }
    }
}
