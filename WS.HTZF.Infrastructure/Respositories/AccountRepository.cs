using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.Repositories;

namespace WS.HTZF.Infrastructure.Respositories
{
    public class AccountRepository : BaseRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(HTZFDbContext dbContext) : base(dbContext)
        {

        }
    }
}