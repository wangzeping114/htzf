using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WS.HTZF.Application.Handlers;
using WS.HTZF.Core.Entites.Sys;
using WS.HTZF.Utilities.Helper;

namespace WS.HTZF.Infrastructure
{
    public class DBInitializer : IDatabaseInitializer<HTZFDbContext>
    {
        public void InitializeDatabase(HTZFDbContext context)
        {
            var exists = context.Database.Exists();

            try
            {
                if (exists && context.Database.CompatibleWithModel(true))
                {
                    // 一切都很好，我们完成了
                }
                if (!exists)
                {
                    context.Database.Create();
                }
            }
            catch (Exception ex)
            {
                //有些地方出了问题，要么是我们无法定位元数据，要么是模型不兼容。
                if (exists)
                {
                    context.Database.ExecuteSqlCommand("更改数据库SWHTZF设置SINGLE_USER并立即回滚");
                    context.Database.ExecuteSqlCommand("使用Master删除数据库SWHTZF");
                    context.SaveChanges();
                }

                context.Database.Create();
            }
            finally
            {
                InitRoleAndAccount(context);
            }

        }
        /// <summary>
        /// 初始化角色和账号
        /// </summary>
        /// <param name="hTZFDbContext"></param>
        public static void InitRoleAndAccount(HTZFDbContext hTZFDbContext)
        {
            var role = hTZFDbContext.Set<Role>();
            if (role.Any()) return;
            var enctrypwd = LazyFactory<PasswordHandler>.Instance.GenerateEncryptPassword("888888");
            var roleName = "超级管理员";
            var Role = new Role
            {
                Name = roleName,
                Description = "最高权限拥有者",
                IsSuperAdmin = true,
                Accounts=new List<Account>
                {
                    new Account(){ UserName="admin",Password=enctrypwd, FullName="陈总" }
                }
            };
            role.Add(Role);
            hTZFDbContext.SaveChanges();
        }
    }
}
