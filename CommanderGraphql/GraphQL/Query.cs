using System.Linq;
using CommanderGraphql.Data;
using CommanderGraphql.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGraphql.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context){
            return context.Platforms;
        }
    }
}