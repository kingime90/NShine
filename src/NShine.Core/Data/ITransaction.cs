using System.Data;

namespace NShine.Core.Data
{
    /// <summary>
    /// 定义数据库事务接口。
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// 获取 是否开启事务。
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 显式开启数据库事物。
        /// </summary>
        /// <param name="isolationLevel">指定连接的事务锁定行为，默认<see cref="IsolationLevel.Unspecified"/>。</param>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);

        /// <summary>
        /// 提交数据库事物更改。
        /// </summary>
        void Commit();

        /// <summary>
        /// 显式回滚数据库事物。
        /// </summary>
        void Rollback();
    }
}
