namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义降序排序数据记录接口（与<see cref="IOrderByAsc"/>互斥，只能继承其中一个）。
    /// </summary>
    public interface IOrderByDesc
    {
        /// <summary>
        /// 优先级（降序）。
        /// </summary>
        int Priority { get; set; }
    }
}
