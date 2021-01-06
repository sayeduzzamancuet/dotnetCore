using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamApi.Dtos;

namespace DreamApi.Services
{
   public interface IAuthService
    {
        public string Authenticate(UserDto userDto);
    }
}
