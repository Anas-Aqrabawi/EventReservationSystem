using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleProject.Application.Common.Interfaces;
using SampleProject.Core.Entities;
using SampleProject.Domain.Constants;
using SampleProject.Domain.Entities;

namespace SampleProject.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTime;
    private readonly JwtSettings jwtSettings;
    public JwtTokenGenerator(IDateTimeProvider dateTime, IOptions<JwtSettings> jwtSettings)
    {
        _dateTime = dateTime;
        this.jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
                           new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),//must be 16 at least
                           SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.Firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.Lastname),
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
               
            };
        //if(user.Roleid == 1)
        //{
        //    claims.Append( new Claim(ClaimTypes.Role, Roles.Administrator));
        //}
        //if (user.Roleid == 2)
        //{
        //    claims.Append(new Claim(ClaimTypes.Role, Roles.User));
        //}
        var securityToken = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            expires: _dateTime.UtcNow.AddHours(jwtSettings.ExpiryInMinutes),
            audience: jwtSettings.Audience,
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
