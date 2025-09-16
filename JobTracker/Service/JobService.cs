using JobTracker.Data;
using JobTracker.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace JobTracker.Service
{
    public class JobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Jobs>> GetAll()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task CreateJobAsync(Jobs jobs)
        {
            await _context.AddAsync(jobs);

            await _context.SaveChangesAsync();
        }


        public async Task<Jobs?> GetOne(int id)
        {
            return await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
