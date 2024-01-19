using Microsoft.EntityFrameworkCore;
using SWWalks.API.Models.Domain;

namespace SWWalks.API.Data
{
    public class SWWalksDbcontext : DbContext
    {
        public SWWalksDbcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
