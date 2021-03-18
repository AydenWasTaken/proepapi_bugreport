using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// This controller provides ping functionality to make sure a client can connect to the API.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        /// <summary>
        /// Ping the API to test connection.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<string> Ping()
        {
            return Task.FromResult("Pong");
        }
    }
}
