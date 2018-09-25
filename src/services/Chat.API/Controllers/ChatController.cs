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
        /// Post api/chat/Add 
        /// </summary>
        /// <param name="question">Content-type application/json</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddChatQuestion([FromBody] Question question)
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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
