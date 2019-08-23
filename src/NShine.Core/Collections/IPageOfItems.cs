using System.Collections.Generic;

namespace NShine.Core.Collections
{
    /// <summary>
    /// 定义分页集合接口。
    /// </summary>
    /// <typeparam name="T">分页数据类型。</typeparam>
    public interface IPageOfItems<T> : IEnumerable<T>
    {
        /// <summary>
        /// 获取 页码。
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// 获取 页大小。
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 获取 总记录数。
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// 获取 总页码。
        /// </summary>
        int TotalPage { get; }
    }
}
