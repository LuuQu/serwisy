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
        public IQueryable<People> GetAllPeople()
        {
            return _context.People;
        }
        public IQueryable<People> GetActivePeople()
        {
            DateTime actualdata = DateTime.Now;
            string tmp = actualdata.ToString("MM/dd/yyyy");
            return _context.People.Where(p => p.Date == tmp);
        }

    }
}
