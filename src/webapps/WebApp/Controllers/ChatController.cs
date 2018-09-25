using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ChatController : Controller
    {
        public ChatController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ActionResult Index()
        {
            var user = HttpContext.User.Identity.Name;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Customer()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> AddChat([FromBody] string question)
        {
            if (ModelState.IsValid)
            {
                await CreateQuestion(HttpContext.Session.Id, question);
            }
            return Json("success");
        }


        private async Task CreateQuestion(string sessionID, string question)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Configuration.GetValue<string>("ChatApiUri"));
            var creatQuestionApiPath = Configuration.GetValue<string>("ChatApi_CreatQuestion");
            await client.PostAsJsonAsync<Object>(creatQuestionApiPath, new { Session = sessionID, Text = question });

        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
