﻿using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class Category:Entity<int>
    {
        public Category()
        {
            Commoditys = new HashSet<Commodity>();
            IsDisplay = true;
            Sequence = 1;
        }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsDisplay { get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        public virtual ICollection<Commodity> Commoditys { get; set; }

        /// <summary>
        /// 积分商品
        /// </summary>
        public virtual ICollection<IntergralComdity> IntergralComdities { get; set; }
    }
}