using JobTracker.Model;
using JobTracker.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobTracker.Pages
{

    
    public class DetailsModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;
        private readonly JobService _jobService;

        public DetailsModel(ILogger<IndexModel> logger, JobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }


        [BindProperty]
        public Jobs? SelectedJob { get; set; }



        

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SelectedJob = await _jobService.GetOne(id);

            if (SelectedJob == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updatedJob = await _jobService.UpdateOne(SelectedJob);
            
            if(updatedJob == null)
            {
                return NotFound();
            }

            return RedirectToPage("index");
            
        }
    }
}
