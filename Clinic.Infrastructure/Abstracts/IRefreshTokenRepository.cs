using Clinic.Data.Entities.Identity;
using Clinic.Infarastructure.InfrastructureBases;

namespace Clinic.Infrustructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {

    }
}
