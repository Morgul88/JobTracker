
using JobTracker.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<Jobs> Jobs { get; set; } = null!;
    }
}
