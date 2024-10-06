using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Infrastructure.AppDbContext;
using Clinic.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Repositories
{
    public class PersonRepository: GenericRepositoryAsync<Person>,IPersonRepository
    {
        private readonly DbSet<Person> _person;            
        public PersonRepository(ClinicDbContext dbContext) : base(dbContext)//base on GenericRepositoryAsync
        {
            _person=dbContext.Set<Person>();
        }

        public async Task<List<Person>> GetPersonsListAsync()
        {
            return await _person.Include(x=>x.Patients).ToListAsync();
        }
    }
}
