using NShine.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NShine.Core.Collections
{
    /// <summary>
    /// 分页集合。
    /// </summary>
    /// <typeparam name="T">数据项类型。</typeparam>
    public class PageOfItems<T> : List<T>, IPageOfItems<T>
    {
        /// <summary>
        /// 初始化一个<see cref="PageOfItems{T}"/>类型的新实例。
        /// </summary>
        /// <param name="pageNumber">页码。</param>
        /// <param name="pageSize">页大小。</param>
        /// <param name="totalCount">总记录数。</param>
        /// <param name="items">数据项集合。</param>
        public PageOfItems(int pageNumber, int pageSize, int totalCount, IEnumerable<T> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            if (items.IsEmpty())
            {
                return;
            }
            //
            AddRange(items);
        }

        /// <summary>
        /// 获取 页码。
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// 获取 页大小。
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// 获取 总记录数。
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// 获取 总页码。
        /// </summary>
        public int TotalPage
        {
            get { return (int)Math.Ceiling((double)TotalCount / PageSize); }
        }
    }
}