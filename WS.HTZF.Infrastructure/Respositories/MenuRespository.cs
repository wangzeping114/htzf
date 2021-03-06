﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Core.Repositories;

namespace WS.HTZF.Infrastructure.Respositories
{
    public class MenuRespository : BaseRepository<Menu, int>, IMenuRespository
    {
        public MenuRespository(HTZFDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 获取所有菜单项
        /// </summary>
        /// <returns></returns>
        public async Task<List<Menu>> GetAllMenus()
        {
            var allentites = await Entities.Include(x => x.Children).Where(x => x.Parent == null).ToListAsync();
            return allentites;

        }
        /// <summary>
        /// 根据角色ID获取所有菜单项
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public async Task<List<Menu>> GetMenuByRole(int RoleId)
        {
            var objlist=  Entities.Include(c => c.Children)
                 .Where(c => c.RoleMenus.Any(x => x.RoleId == RoleId) && c.Parent == null)
                 .Select(t => new 
                 {
                      Id = t.Id,
                      Children = t.Children.Where(c => c.RoleMenus.Any(x => x.RoleId == RoleId)).ToList(),
                      Name = t.Name,
                      ActionSref = t.ActionSref,
                      Icon = t.Icon
                  }).ToList()
                  .Select(x=>new Menu { 
                    Id=x.Id,
                    Children=x.Children
                  });
            return await Task.FromResult<List<Menu>>(objlist.ToList());
        }
        /// <summary>
        /// 根据父类ID获取菜单项
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<Menu> GetParentMenu(int parentId)
        {
            var entity = await Task.Run(() => Entities.Include(x => x.Children).Where(x => x.Id == parentId).First());
            return entity;
        }
    }
}
