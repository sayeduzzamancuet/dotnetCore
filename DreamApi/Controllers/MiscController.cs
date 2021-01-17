using DreamApi.Dtos;
using DreamApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace DreamApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MiscController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public MiscController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // GET api/<MiscController>/5
        [HttpGet("{id}")]
        public string[] Get(int id)
        {
            return new string[] {"value1", "value2"};
        }

        // POST api/<MiscController>
        [Route("sendemail")]
        [HttpPost]
        public void SendEmail([FromBody] EmailDto content)
        {
            _emailService.sendEmail("eliaszamanonline@gmail.com", "eliaszamanonline@gmail.com", content.Subject,
                content.Body);
        }

        [Route("demo")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Demo()
        {
            return new JsonResult(new List<object>()
            {
                new
                {
                    id = 1,
                    first_name = "Jeanette",
                    last_name = "Penddreth",
                    email = "jpenddreth0@census.gov",
                    gender = "Female",
                    ip_address = "26.58.193.2"
                },
                new
                {
                    id = 2,
                    first_name = "Jeanette",
                    last_name = "Penddreth",
                    email = "jpenddreth0@census.gov",
                    gender = "Female",
                    ip_address = "26.58.193.2"
                },
                new
                {
                    id = 3,
                    first_name = "Jeanette",
                    last_name = "Penddreth",
                    email = "jpenddreth0@census.gov",
                    gender = "Female",
                    ip_address = "26.58.193.2"
                },
                new
                {
                    id = 4,
                    first_name = "Jeanette",
                    last_name = "Penddreth",
                    email = "jpenddreth0@census.gov",
                    gender = "Female",
                    ip_address = "26.58.193.2"
                },
                new
                {
                    id = 5,
                    first_name = "Jeanette",
                    last_name = "Penddreth",
                    email = "jpenddreth0@census.gov",
                    gender = "Female",
                    ip_address = "26.58.193.2"
                }

            });
        }

        
    }
}
