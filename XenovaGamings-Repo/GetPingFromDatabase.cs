using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenovaGamings_Repo.Models;

namespace XenovaGamings_Repo
{
    public class GetPingFromDatabase
    {
        private readonly XenovaDbContext context;
        public GetPingFromDatabase()
        {
            context = new XenovaDbContext();
        }
        public async Task<List<string?>> GetPingData()
        {
            var query = await context.Databasepings.AsQueryable().Select(x=>x.Name).ToListAsync();
            return query;
        }
    }
}
