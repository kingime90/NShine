using System;
using System.Data;
using System.Data.Entity;

namespace NShine.Core.Data
{
    /// <summary>
    /// 数据库上下文基类。
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class DbContextBase<TDbContext> : DbContext, ITransaction where TDbContext : DbContext, ITransaction, new()
    {
        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>类型的新实例。
        /// </summary>
        protected DbContextBase() : base(GetConnectionStringName())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DbContextBase{TDbContext}"/>类型的新实例。
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        protected DbContextBase(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        private static readonly Type _dbContextType = typeof(TDbContext);

        /// <summary>
        /// 获取 数据库上下文类型。
        /// </summary>
        public static Type DbContextType
        {
            get
            {
                return _dbContextType;
            }
        }

        /// <summary>
        /// 获取 是否开启事务。
        /// </summary>
        public bool Enabled => Database.CurrentTransaction != null;

        /// <summary>
        /// 显式开启数据库事物。
        /// </summary>
        /// <param name="isolationLevel"></param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            if (Enabled)
            {
                return;
            }
            //
            Database.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// 提交数据库事物更改。
        /// </summary>
        public void Commit()
        {
            var transaction = Database.CurrentTransaction;
            if (transaction == null)
            {
                return;
            }
            //
            try
            {
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 显式回滚数据库事物。
        /// </summary>
        public void Rollback()
        {
            var transaction = Database.CurrentTransaction;
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }

        #region 辅助方法

        /// <summary>
        /// 获取数据库连接字符串名称。
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionStringName()
        {
            return null;
        }

        #endregion
    }
}
