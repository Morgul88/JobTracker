using JobTracker.Data;
using JobTracker.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http.HttpResults;

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
            
            var result =  await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);

            if(result != null)
            {
                return result;
            }
            else
            {
                return NotFound();
            }
        
        }

        private Jobs? NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<Jobs?> UpdateOne(Jobs job)
        {
            var jobToUpdate = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == job.Id);

            if (jobToUpdate != null)
            {
                jobToUpdate.Title = job.Title;
                jobToUpdate.Company = job.Company;
                jobToUpdate.Description = job.Description;
                jobToUpdate.Status = job.Status;
                jobToUpdate.Notes = job.Notes;
                jobToUpdate.Contact = job.Contact;
                jobToUpdate.CreatedAt = job.CreatedAt;
                jobToUpdate.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();

                return jobToUpdate;

            }

            return null;
            
        }

        public async Task<Jobs?> RemoveOne(Jobs job)
        {
            var jobToDelete = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == job.Id);
            
            if(jobToDelete != null)
            {
                _context.Jobs.Remove(jobToDelete);

                await _context.SaveChangesAsync();

                return jobToDelete;
            }
            return null;

        }


    }
}
