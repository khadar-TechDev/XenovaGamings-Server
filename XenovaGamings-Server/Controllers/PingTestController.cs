using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XenovaGamings_Service;

namespace XenovaGamings_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingTestController : ControllerBase
    {
        [HttpGet("ApiPing")]
        public string GetApiPing()
        {
            return "Khadar Testing API Ping.";
        }

        [HttpGet("DatabasePing")]
        public async Task<string> GetDatabasePing()
        {
            var service = new TestPingService();
            return await service.GetPingTestDataFromDatabase();
        }
    }
}