using Clinic.Data.Entities;
using Clinic.Data.Enums;
using Clinic.Infrastructure.Abstracts;
using Clinic.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Clinic.Service.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _PersonRepository;

        public PersonService(IPersonRepository PersonRepository)
        {
            _PersonRepository=PersonRepository;
        }

        public async Task<List<Person>> GetPersonsListAsync()
        {
            return await _PersonRepository.GetPersonsListAsync();
        }

        public async Task<Person> GetPersonByIDWithIncludeAsync(int id)
        {
            // var Person = await _PersonRepository.GetByIdAsync(id);
            var Person = _PersonRepository.GetTableNoTracking()
                                          .Include(x => x.Doctors)
                                          .Include(x => x.Patients)
                                          .Where(x => x.PersonId.Equals(id))
                                          .FirstOrDefault();
            return Person;
        }

        public async Task<string> AddAsync(Person Person)
        {
            //Added Person
            await _PersonRepository.AddAsync(Person);
            return "Success";
        }




        public async Task<string> EditAsync(Person Person)
        {
            await _PersonRepository.UpdateAsync(Person);
            return "Success";
        }

        public async Task<string> DeleteAsync(Person Person)
        {
            var trans = _PersonRepository.BeginTransaction();
            try
            {
                await _PersonRepository.DeleteAsync(Person);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }

        }

        public async Task<Person> GetByIDAsync(int id)
        {
            var Person = await _PersonRepository.GetByIdAsync(id);
            return Person;
        }

        public IQueryable<Person> GetPersonsQuerable()
        {
            return _PersonRepository.GetTableNoTracking()
                                    .Include(x => x.Doctors)
                                    .Include(x => x.Patients).AsQueryable();
        }

        public IQueryable<Person> FilterPersonPaginatedQuerable(PersonOrderingEnum orderingEnum, string search)
        {
            var querable = _PersonRepository.GetTableNoTracking()
                                            .Include(x => x.Doctors)
                                            .Include(x => x.Patients).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.NameAr.Contains(search) || x.Address.Contains(search));
            }
            switch (orderingEnum)
            {
                case PersonOrderingEnum.PersonId:
                    querable = querable.OrderBy(x => x.PersonId);
                    break;
                case PersonOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.NameEn);
                    break;
                case PersonOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case PersonOrderingEnum.Gender:
                    querable = querable.OrderBy(x => x.Gender);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderingEnum), orderingEnum, null);
            }

            return querable;
        }







        public Task<bool> IsNameArExist(string nameAr)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameEnExist(string nameEn)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            throw new NotImplementedException();
        }


    }
}
