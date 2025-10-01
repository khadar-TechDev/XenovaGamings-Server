using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenovaGamings_Repo;

namespace XenovaGamings_Service
{
    public class TestPingService
    {
        public async Task<string> GetPingTestDataFromDatabase()
        {
            var repo = new GetPingFromDatabase();
            var result = await repo.GetPingData();

            return string.Join(',', result);
        }
    }
}
