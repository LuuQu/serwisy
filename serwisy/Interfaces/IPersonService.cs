using serwisy.Models;

namespace serwisy.Interfaces
{
    public interface IPersonService
    {
        public IQueryable<People> GetEntriesFromToday();
        public IQueryable<People> GetAllEntries();
        public void AddEntry(string name, string lastName);

    }
}
