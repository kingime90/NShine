namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义数据记录接口。
    /// </summary>
    /// <typeparam name="TKey">主键类型。</typeparam>
    public interface IRecord<out TKey>
    {
        /// <summary>
        /// 获取 主键ID。
        /// </summary>
        TKey Id { get; }
    }
}
