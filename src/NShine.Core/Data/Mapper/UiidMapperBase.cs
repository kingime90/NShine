using NShine.Core.Data.Record;
using System.Data.Entity;

namespace NShine.Core.Data.Mapper
{
    /// <summary>
    /// 唯一整数主键数据记录映射配置基类。
    /// </summary>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    /// <typeparam name="TDbContext">数据库上下文类型。</typeparam>
    public abstract class UiidMapperBase<TRecord, TDbContext> : MapperBase<int, TRecord, TDbContext>
        where TRecord : class, IUiidRecord, new()
        where TDbContext : DbContext
    {

    }
}
