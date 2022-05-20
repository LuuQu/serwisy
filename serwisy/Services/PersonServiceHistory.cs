using Microsoft.Data.SqlClient;
using serwisy.Data;
using serwisy.Interfaces;
using serwisy.Models;

namespace serwisy.Services
{
    public class PersonServiceHistory : IPersonService
    {
        private readonly PeopleContext _context;
        public PersonServiceHistory(PeopleContext context)
        {
            _context = context;
        }
        public IQueryable<People> GetAllEntries()
        {
            return _context.People;
        }
        public IQueryable<People> GetEntriesFromToday()
        {
            DateTime actualdata = DateTime.Now;
            string tmp = actualdata.ToString("MM/dd/yyyy");
            return _context.People.Where(p => p.Date == tmp);
        }
        public void AddEntry(string name, string lastName)
        {
            DateTime actualdata = DateTime.Now;
            string tmp = actualdata.ToString("MM/dd/yyyy");
            string sqlQuery = "INSERT INTO People(FirstName,LastName,Date) VALUES('" + name + "', '" + lastName + "', '" + tmp + "')";
            string sqlLink = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=serwisyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(sqlLink);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.ExecuteNonQuery();
            con.Close();
        }

    }
}
