using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DreamApi.Dtos;
using DreamApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace DreamApi.Services
{
    public class AuthService:IAuthService
    {
        private readonly string key=null;
        public AuthService(string key)
        {
            this.key = key;
        }
        private List<UserDto> userList=new List<UserDto>
        {
            new UserDto
            {
                Password = "1234",UserName = "admin"
            },
            new UserDto
            {
                Password = "1234",UserName = "badmin"
            }
        };
        public string Authenticate(UserDto userDto)
        {
            if (userDto.UserName.Length < 2)//for demo purpose only
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor=new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,userDto.UserName), 
                    }
                ),
                Expires = DateTime.UtcNow.AddMonths(12),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256 )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
