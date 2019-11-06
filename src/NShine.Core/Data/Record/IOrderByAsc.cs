namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义升序排序接口（优先）。
    /// </summary>
    public interface IOrderByAsc
    {
        /// <summary>
        /// 优先级（升序）。
        /// </summary>
        int Priority { get; set; }
    }
}
