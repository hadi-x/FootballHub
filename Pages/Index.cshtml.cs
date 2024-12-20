using FootballHub.Models;
using FootballHub.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballHub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<APiResults> SoccerResult { get; set; }
        private readonly ApiService _apiService;
        public IndexModel(ILogger<IndexModel> logger , ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                SoccerResult =   await _apiService.CallService(0,0);
                return Page();   
            }
            catch (Exception ex)
            {
                if (ex.Message == "Too many requests. Please try again later.")
                {
                    return RedirectToPage("/Error", new { errorMessage = ex.Message });
                }

                return RedirectToPage("/Error", new { errorMessage = "An unexpected error occurred." });
            }
        }
    }
}
