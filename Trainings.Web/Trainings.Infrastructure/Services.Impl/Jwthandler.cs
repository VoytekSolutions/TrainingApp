using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trainings.Infrastructure.DTO;
using Trainings.Infrastructure.Extentions;
using Trainings.Infrastructure.Settings;

namespace Trainings.Infrastructure.Services.Impl
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JWTSettings Settings;

        public JwtHandler(JWTSettings settings)
        {
            Settings = settings;
        }

        public JwtDTO CreateToken(string email, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
            };

            var signingCridentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Key)), SecurityAlgorithms.HmacSha256);

            var expires = now.AddMinutes(Settings.ExpiringMinutes);

            var jwt = new JwtSecurityToken(
                issuer: Settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCridentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDTO
            {
                Token = token,
                Expiriation = expires.ToTimeStamp()
            };
        }
    }
}
