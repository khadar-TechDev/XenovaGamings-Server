using Microsoft.AspNetCore.Mvc;

namespace XenovaGamings_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingTestController: ControllerBase
    {
        [HttpGet(Name = "ApiPing")]
        public string GetApiPing()
        {
            return "API ping success";
        }
    }
}
