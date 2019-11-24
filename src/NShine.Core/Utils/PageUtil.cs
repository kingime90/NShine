using NShine.Core.Collections;
using NShine.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace NShine.Core.Utils
{
    /// <summary>
    /// 分页应用。
    /// </summary>
    public static class PageUtil
    {
        /// <summary>
        /// 获取安全的分页信息。
        /// </summary>
        /// <param name="page">分页信息接口。</param>
        /// <returns></returns>
        public static IPage GetSafePage(IPage page)
        {
            IPage safePage;
            if ((safePage = (page as SafePage)) != null)
            {
                return safePage;
            }
            //
            if (!(page?.PageNumber).HasValue || !(page?.PageSize).HasValue)
            {
                safePage = new SafePage(page.PageNumber, page.PageSize);
            }
            else
            {
                safePage = page;
            }
            return safePage;
        }

        /// <summary>
        /// 分页空集合。
        /// </summary>
        /// <typeparam name="T">数据项类型。</typeparam>
        /// <param name="page">分页信息接口。</param>
        /// <returns></returns>
        public static IPageOfItems<T> Empty<T>(IPage page)
        {
            return new PageOfItems<T>(page.PageNumber.Value, page.PageSize.Value, 0, Enumerable.Empty<T>());
        }

        /// <summary>
        /// 构建分页集合。
        /// </summary>
        /// <typeparam name="T">数据项类型。</typeparam>
        /// <param name="totalCount">总记录数。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="items">数据项集合。</param>
        /// <returns></returns>
        public static IPageOfItems<T> Items<T>(int totalCount, IPage page, IEnumerable<T> items)
        {
            return new PageOfItems<T>(page.PageNumber.Value, page.PageSize.Value, totalCount, items);
        }
    }
}