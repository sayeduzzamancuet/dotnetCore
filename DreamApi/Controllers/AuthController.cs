using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DreamApi.Dtos;
using DreamApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace DreamApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [Route("token")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDto user)
        {
           var token= _authService.Authenticate(user);
           if (token == null)
           {
               return Unauthorized();
           }

           return new JsonResult(token);
        }
    }
}
