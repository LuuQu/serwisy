using serwisy.Models;

namespace serwisy.Interfaces
{
    public interface IPersonService
    {
        public IQueryable<People> GetActivePeople();
        public IQueryable<People> GetAllPeople();

    }
}
