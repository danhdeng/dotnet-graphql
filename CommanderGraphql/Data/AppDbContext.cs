using CommanderGraphql.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGraphql.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options){
     
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}