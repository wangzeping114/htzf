using System.Collections.Generic;
using System.Threading.Tasks;
using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Repositories
{
    public interface IMenuRespository:IRepository<Menu,int>
    {
        Task<Menu> GetParentMenu(int parentId);

        Task<List<Menu>> GetAllMenus();

        Task<List<Menu>> GetMenuByRole(int RoleId);
    }
}
