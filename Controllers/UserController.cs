using Azure;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Interface;
using SampleApi.Models;
using SampleApi.Response;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly ILogger<UserController> _logger;
        public UserController(IUser user, ILogger<UserController> logger)
        {
            _user = user;
            _logger = logger;
        }

        [HttpPost("EnrollUser")]
        //[Route("api/v1/{}")]
        public async Task<IActionResult> Signup([FromBody] SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            try
            {
                var result = await _user.PostUserInfoAsync(request);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }
    }
}
