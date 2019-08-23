namespace NShine.Core.Public
{
    /// <summary>
    /// 定义分页信息接口。
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// 获取 页码。
        /// </summary>
        int? PageNumber { get; }

        /// <summary>
        /// 获取 页大小。
        /// </summary>
        int? PageSize { get; }
    }
}
