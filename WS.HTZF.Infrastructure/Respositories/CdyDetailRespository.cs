using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.Repositories;

namespace WS.HTZF.Infrastructure.Respositories
{
    public class CdyDetailRespository : BaseRepository<CommodityDetail, int>, ICdyDetailRespository
    {
        public CdyDetailRespository(HTZFDbContext dbContext) : base(dbContext)
        {
        }
    }
}
