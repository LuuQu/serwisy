using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serwisy.Interfaces;
using serwisy.Models;

namespace serwisy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        public IQueryable<People> Records { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public void OnGet()
        {
            Records = _personService.GetEntriesFromToday();
        }
        public IActionResult OnPost()
        {
            _personService.AddEntry(Request.Form["Name"], Request.Form["LastName"]);
            Records = _personService.GetEntriesFromToday();
            return Page();
        }
    }
}