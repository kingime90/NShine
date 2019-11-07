namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义升序排序数据记录接口（与<see cref="IOrderByDesc"/>互斥，只能继承其中一个）。
    /// </summary>
    public interface IOrderByAsc
    {
        /// <summary>
        /// 优先级（升序）。
        /// </summary>
        int Priority { get; set; }
    }
}
