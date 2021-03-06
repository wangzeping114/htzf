﻿using System;
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
                InitMenus(context);
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

        /// <summary>
        /// 初始化菜单配置
        /// </summary>
        public static void InitMenus(HTZFDbContext hTZFDbContext) 
        {
            var tbmenu = hTZFDbContext.Set<Menu>();
            if (tbmenu.Any()) return;
            var menus = new List<Menu>()
            {
                new Menu
                {
                    Icon="fa fa-cogs",
                    Name="系统配置",
                    Path="系统配置",
                    Level=0,
                    Children=new List<Menu>
                    {
                        new Menu
                        {
                            Name="页面配置",
                            Level=1,
                            Path="系统配置/页面配置",
                            ActionSref="BaseSet/SystemSet.aspx",
                        },
                        new Menu
                        {
                            Name="二维码海报默认设置",
                            Level=1,
                            Path="系统配置/二维码海报默认设置",
                            ActionSref="BaseSet/ShareImgSet.aspx"
                        },
                        new Menu
                        {
                            Name="微信配置",
                            Level=1,
                            Path="系统配置/微信配置",
                            ActionSref="BaseSet/WxPayConfig.aspx"
                        },
                        new Menu
                        {
                            Name="运费模板",
                            Level=1,
                            Path="系统配置/运费模板",
                            ActionSref="BaseSet/PostSet.aspx"
                        }
                    }
                },
                new Menu
                {
                    Icon="fa fa-user",
                    Name="用户管理",
                    Path="用户管理",
                    Level=0,
                    Children=new List<Menu>
                    {
                        new Menu
                        {
                            Name="权限组管理",
                            Level=1,
                            Path="用户管理/权限组管理",
                            ActionSref="User/PowerGroupList.aspx",
                        },
                        new Menu
                        {
                            Name="用户管理",
                            Level=1,
                            Path="用户管理/用户管理",
                            ActionSref="User/UserList.aspx",
                        }
                    }
                },
                new Menu
                {
                    Icon="fa fa-user",
                    Name="会员管理",
                    Path="会员管理",
                    Level=0,
                    Children=new List<Menu>()
                    {
                        new Menu
                        {
                              Name="会员等级管理",
                              Path="会员管理/会员等级管理",
                              ActionSref="Member/MemberLevelList.aspx",
                              Level=1
                        },
                        new Menu
                        {
                              Name="会员等级分佣配置",
                              Path="会员管理/会员等级分佣配置",
                              ActionSref="Member/MemberLevelSet.aspx",
                              Level=1
                        },
                        new Menu
                        {
                              Name="会员列表",
                              Path="会员管理/会员列表",
                              ActionSref="Member/MemberList.aspx",
                              Level=1
                        },
                    }
                },
                new Menu
                {
                    Icon="fa fa-cogs",
                    Name="商品管理",
                    Path="商品管理",
                    Level=0,
                    Children=new List<Menu>
                    {
                        new Menu
                        {
                            Name="商品类型列表",
                            Path="商品管理/商品类型列表",
                            ActionSref="Product/ProductTypeList.aspx",
                            Level=1,

                        },
                        new Menu
                        {
                            Name="商品列表",
                            Path="商品管理/商品列表",
                            ActionSref="Product/ProductList.aspx",
                            Level=1
                        }
                    }
                },
                new Menu
                {
                    Name="订单管理",
                    Icon="fa fa-cogs",
                    Path="订单管理",
                    Level=0,
                    Children=new List<Menu>
                    {
                       new Menu
                       {
                           Name="订单列表",
                           Path="订单管理/订单列表",
                           ActionSref="Order/OrderList.aspx",
                           Level=1
                       }
                    }
                },
                new Menu
                {
                    Name="代金券管理",
                    Path="代金券管理",
                    Icon="fa fa-cogs",
                    Level=0,
                    Children=new List<Menu>
                    {
                       new Menu
                       {
                           Name="代金券列表",
                           Path="代金券管理/代金券列表",
                           ActionSref="Voucher/VoucherList.aspx",
                           Level=1
                       }
                    }
                },
                new Menu
                {
                    Icon="fa fa-cogs",
                    Name="活动管理",
                    Path="活动管理",
                    Level=0,
                    Children=new List<Menu>
                    {
                        new Menu
                        {
                            Name="抢购",
                            Path="活动管理/抢购",
                            ActionSref="Active/ShoppingRush.aspx",
                            Level=1
                        },
                        new Menu
                        {
                            Name="拼团",
                            Path="活动管理/拼团",
                            ActionSref="Active/ShoppingGroup.aspx",
                            Level=1
                        }
                    }
                },
                new Menu
                {
                    Icon="fa fa-cogs",
                    Name="财务管理",
                    Path="财务管理",
                    Level=0,
                    Children=new List<Menu>
                    {
                        new Menu
                        {
                            Name="用户提现",
                            Path="财务管理/用户提现",
                            Level=1,
                            ActionSref="Finance/UserWithdraw.aspx",
                        },
                        new Menu
                        {
                            Name="线下支付",
                            Path="财务管理/线下支付",
                            Level=1,
                            ActionSref="Finance/OfflinePay.aspx"
                        }
                    }
                },
                new Menu{
                    Icon="fa fa-cogs",
                    Name="报表管理",
                    Path="报表管理",
                    Level=0,
                    Children=new List<Menu>
                    {
                        new Menu
                        {
                            Name="营业收支汇总表",
                            Path="报表管理/营业收支汇总表",
                            Level=1,
                            ActionSref="ReportForm/OperatingAccount.aspx"
                        },
                        new Menu
                        {
                            Name="会籍升级统计表",
                            Path="报表管理/会籍升级统计表",
                            Level=1,
                            ActionSref="ReportForm/MemberUp.aspx"
                        },
                        new Menu
                        {
                            Name="产品销售分析表",
                            Path="报表管理/产品销售分析表",
                            Level=1,
                            ActionSref="ReportForm/ProductSale.aspx"
                        }
                    }
                },
            };
            tbmenu.AddRange(menus);
            hTZFDbContext.SaveChanges();
        }
    }
}
