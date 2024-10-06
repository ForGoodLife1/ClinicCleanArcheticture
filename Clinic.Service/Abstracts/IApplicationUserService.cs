using Clinic.Data.Entities.Identity;

namespace Clinic.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
