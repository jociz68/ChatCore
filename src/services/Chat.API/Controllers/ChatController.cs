using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chat.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatDataManager _data;
        readonly ILogger _logger;
        public ChatController(IChatDataManager data, ILogger<ChatController> logger)
        {
            _data = data;
            _logger = logger;
        }

        /// <summary>
        /// Post api/chat/AddQuestion
        /// </summary>
        /// <param name="question">Content-type application/json</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddQuestion([FromBody] Question question)
        {
            using (_logger.BeginScope("Add Chat Question"))
            {
                var success = _data.CreatQuestion(new Question()
                {
                    Text = question.Text,
                    Session = question.Session
                });

                if (success)
                {
                    _logger.LogDebug("Question has been created");
                    return Ok("Question has been created successfully ");
                }
                else
                {
                    _logger.LogDebug("Failed to create Question");
                    return StatusCode(400, "Failed to create Question");
                }
            }
        }

        [HttpGet("{session}")]
        public IActionResult GetActiveQuestions(string session)
        {
            var questions = _data.GetActiveQuestions(session).ToList();
            return Ok(questions);
        }

        [HttpGet]
        public IActionResult GetQuestionsNotAnswered()
        {
            var questions = _data.GetQuestionsNotAnswered().ToList();
            return Ok(questions);
        }

        [HttpPost("{questionID}")]
        public IActionResult AddAnswer([FromBody] Answer answer, int questionID)
        {
            var retVal = _data.CreateAnswer(answer, questionID);
            return Ok(retVal);
        }

    }
}
