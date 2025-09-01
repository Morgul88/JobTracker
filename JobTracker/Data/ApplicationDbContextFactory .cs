using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JobTracker.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\stara\\OneDrive\\Skrivbord\\JobTracker\\JobTracker\\JobTracker\\Data\\localdb.mdf;Integrated Security=True;Connect Timeout=30");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
