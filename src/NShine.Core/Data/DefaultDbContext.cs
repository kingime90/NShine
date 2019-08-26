﻿namespace NShine.Core.Data
{
    /// <summary>
    /// 默认数据库上下文。
    /// </summary>
    public class DefaultDbContext : DbContextBase<DefaultDbContext>
    {
        /// <summary>
        /// 初始化一个<see cref="DefaultDbContext"/>类型的新实例。
        /// </summary>
        public DefaultDbContext() : base()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DefaultDbContext"/>类型的新实例。
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public DefaultDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}
