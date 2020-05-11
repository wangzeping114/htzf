using System;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 账号
    /// </summary>
    public class Account:Entity<int>
    {
        public Account()
        {
            CreateAt = DateTime.Now;
            LatestUpdatedAt = DateTime.Now;
            IsDisplay = false;
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LatestUpdatedAt { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        public bool IsDisplay { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual Role Role { get; set; }
    }
}