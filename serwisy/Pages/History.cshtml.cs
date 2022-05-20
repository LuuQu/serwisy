using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serwisy.Interfaces;
using serwisy.Models;

namespace serwisy.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly ILogger<HistoryModel> _logger;
        private readonly IPersonService _personService;
        public IQueryable<People> Records { get; set; }

        public HistoryModel(ILogger<HistoryModel> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public void OnGet()
        {
            Records = _personService.GetAllEntries();
        }
    }
}