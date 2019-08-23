using NShine.Core.Data.Record;

namespace NShine.Core.Data
{
    /// <summary>
    /// 定义唯一字符串主键数据记录仓储服务接口（New unique string id）。
    /// </summary>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    public interface IUsidRepository<TRecord> : IRepository<string, TRecord> where TRecord : class, IUsidRecord, new()
    {

    }
}
