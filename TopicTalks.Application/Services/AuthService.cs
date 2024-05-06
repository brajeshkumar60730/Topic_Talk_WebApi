using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Application.Interfaces;
using TopicTalks.Domain.Entities;
using TopicTalks.Domain.Enums;

namespace TopicTalks.Application.Services
{
    internal class AuthService(IConfiguration configuration) : IAuthService
    {
        public string GenerateJwtToken(User user)
        {
            var utcNow = DateTime.UtcNow;
            var expiresAt = utcNow.AddDays(7);

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()), // Subject (user ID)
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expiresAt).ToUnixTimeSeconds().ToString()), // Expiration Time
            new(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(utcNow).ToUnixTimeSeconds().ToString()), // Not Before
            new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(utcNow).ToUnixTimeSeconds().ToString()), // Issued At
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID
            new(ClaimTypes.Role, user.UserRoles.FirstOrDefault()?.Role?.RoleName ?? RoleType.Student.ToString())
        };

            var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Key").Value ?? string.Empty);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    issuer: "https://rawfin.net",
                    audience: "https://rawfin.net",
                    claims: claims,
                    expires: expiresAt,
                    signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
