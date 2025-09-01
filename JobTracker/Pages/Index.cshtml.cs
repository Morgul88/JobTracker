using JobTracker.Data;
using JobTracker.Model;
using JobTracker.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JobService _jobService;
        [BindProperty]
        public Jobs Job { get; set; } = new Jobs();
        public IList<Jobs> Jobs { get; set; } = new List<Jobs>();

        public IndexModel(ILogger<IndexModel> logger, JobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _jobService.GetAll();

            if(result != null)
            {
                Jobs = result;

                return Page();
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }

            await _jobService.CreateJobAsync(Job);

            return RedirectToPage("Index");

        }
    }
}
