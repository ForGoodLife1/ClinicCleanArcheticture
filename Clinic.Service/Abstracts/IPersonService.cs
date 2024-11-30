using Clinic.Data.Entities;
using Clinic.Data.Enums;

namespace Clinic.Service.Abstracts
{
    public interface IPersonService
    {
        public Task<List<Person>> GetPersonsListAsync();
        public Task<Person> GetPersonByIDWithIncludeAsync(int id);
        public Task<Person> GetByIDAsync(int id);
        public Task<string> AddAsync(Person person);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Person person);
        public Task<string> DeleteAsync(Person person);
        public IQueryable<Person> GetPersonsQuerable();
        public IQueryable<Person> GetPersonsByPersonIDQuerable(int PID);
        public IQueryable<Person> FilterPersonPaginatedQuerable(PatientOrderingEnum orderingEnum, string search);

    }
}
