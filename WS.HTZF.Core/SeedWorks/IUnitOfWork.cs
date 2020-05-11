using System.Threading.Tasks;

namespace WS.HTZF.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}