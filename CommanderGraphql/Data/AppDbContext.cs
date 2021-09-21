using Microsoft.EntityFrameworkCore;

namespace CommanderGraphql.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options){
     
        }
    }
}