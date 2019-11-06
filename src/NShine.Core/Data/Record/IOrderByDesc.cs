namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义降序排序接口。
    /// </summary>
    public interface IOrderByDesc
    {
        /// <summary>
        /// 优先级（降序）。
        /// </summary>
        int Priority { get; set; }
    }
}
