using NShine.Core.Data.Record;

namespace NShine.Core.Data
{
    /// <summary>
    /// 定义唯一整数主键数据记录仓储服务接口（New unique integer id）。
    /// </summary>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    public interface IUiidRepository<TRecord> : IRepository<int, TRecord> where TRecord : class, IUiidRecord, new()
    {

    }
}
