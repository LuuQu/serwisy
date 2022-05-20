using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
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
            Records = _personService.GetActivePeople();
        }
        public IActionResult OnPost()
        {
            string name = Request.Form["Name"];
            string lastName = Request.Form["LastName"];
            DateTime actualdata = DateTime.Now;
            string tmp = actualdata.ToString("MM/dd/yyyy");
            string sqlQuery = "INSERT INTO People(FirstName,LastName,Date) VALUES('" + name + "', '" + lastName + "', '" + tmp + "')";
            string sqlLink = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=serwisyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(sqlLink);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.ExecuteNonQuery();
            con.Close();
            Records = _personService.GetActivePeople();
            return Page();
        }
    }
}