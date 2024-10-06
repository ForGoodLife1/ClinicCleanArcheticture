using Clinic.Data.Entities.Identity;
using Clinic.Infrastructure.AppDbContext;
using Clinic.Infrastructure.InfrastructureBases;
using Clinic.Infrustructure.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrustructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private DbSet<UserRefreshToken> userRefreshToken;
        #endregion

        #region Constructors
        public RefreshTokenRepository(ClinicDbContext dbContext) : base(dbContext)
        {
            userRefreshToken=dbContext.Set<UserRefreshToken>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
