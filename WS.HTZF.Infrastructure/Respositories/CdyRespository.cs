using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.Repositories;

namespace WS.HTZF.Infrastructure.Respositories
{
    public class CdyRespository : BaseRepository<Commodity, int>, ICdyRespository
    {
        public CdyRespository(HTZFDbContext dbContext) : base(dbContext)
        {

        }
    }
}
