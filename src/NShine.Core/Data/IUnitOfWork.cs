using System.Data;

namespace NShine.Core.Data
{
    /// <summary>
    /// 定义业务单元操作接口。
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获取 是否开启事务提交。
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 显式开启数据库事物。
        /// </summary>
        /// <param name="isolationLevel">指定连接的事务锁定行为，默认<see cref="IsolationLevel.Unspecified"/>。</param>
        void Begin(IsolationLevel isolationLevel = IsolationLevel.Unspecified);

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
