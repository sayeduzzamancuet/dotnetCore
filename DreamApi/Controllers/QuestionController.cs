using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamApi.Models;
using DreamApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace DreamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            this._questionService = questionService;
        }
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddNewTopic([FromBody] Question question)
        {
            var result = this._questionService.AddNewQuestion(question);
            if (result == true) return Ok("added");
            else
            {
                return NotFound("Error occurred");
            }
        }
        [Route("find")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult FindQuestions([FromQuery] string company,[FromQuery] string stack,[FromQuery] string position)
        {
            return Ok(_questionService.GetQuestionByQuery(company,stack,position));
        }
        [Route("update")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult UpdateQuestions([FromBody] Question question)
        {
             _questionService.UpdateQuestionById(question);
            return Ok("updated");
        }
        [Route("companies")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetListedCompanies()
        {
            var data=_questionService.GetListedCompanies();
            return Ok(data);
        }
    }
}
