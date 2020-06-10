using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.Repositories;

namespace WS.HTZF.Infrastructure.Respositories
{
    public class CategoryRespository : BaseRepository<Category, int>, ICategoryRespository
    {
        public CategoryRespository(HTZFDbContext dbContext) : base(dbContext)
        {

        }
    }
}
