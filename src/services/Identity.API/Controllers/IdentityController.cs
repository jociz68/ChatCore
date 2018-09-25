using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Identity.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        IUserManager _manager;
        readonly ILogger _logger;
        public IdentityController(IUserManager data, ILogger<IdentityController> logger)
        {
            _manager = data;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {
            _logger.LogDebug($"Authenticating user name: {user.Name}");
            User authUser = null;
            try
            {
                authUser = _manager.Authenticate(user.Name, user.PasswordHash);
                if (authUser != null)
                {
                    _logger.LogDebug($"User name: {user.Name} has been authenticated");
                }
                else
                {
                    _logger.LogDebug($"Failed to authenticate user name: {user.Name}");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpectd event occurred:{ex.Message}");
            }

            return Ok(authUser != null);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                return Ok(_manager.Create(user, user.PasswordHash));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpectd event occurred:{ex.Message}");
            }
            return Ok(false);
        }

    }
}