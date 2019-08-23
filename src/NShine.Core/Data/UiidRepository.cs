using NShine.Core.Data.Record;

namespace NShine.Core.Data
{
    /// <summary>
    /// 唯一整数主键数据记录仓储服务（New unique integer id）。
    /// </summary>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    public class UiidRepository<TRecord> : RepositoryBase<int, TRecord>, IUiidRepository<TRecord> where TRecord : class, IUiidRecord, new()
    {

    }
}
