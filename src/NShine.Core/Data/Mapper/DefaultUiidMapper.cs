using NShine.Core.Data.Record;

namespace NShine.Core.Data.Mapper
{
    /// <summary>
    /// 默认唯一整数主键数据记录映射配置基类。
    /// </summary>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    public abstract class DefaultUiidMapper<TRecord> : UiidMapperBase<TRecord, DefaultDbContext>
        where TRecord : class, IUiidRecord, new()
    {

    }
}
