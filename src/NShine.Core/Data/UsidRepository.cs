using NShine.Core.Data.Record;

namespace NShine.Core.Data
{
    /// <summary>
    /// 唯一字符串主键数据记录仓储服务（New unique string id）。
    /// </summary>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    public class UsidRepository<TRecord> : RepositoryBase<string, TRecord>, IUsidRepository<TRecord> where TRecord : class, IUsidRecord, new()
    {

    }
}
