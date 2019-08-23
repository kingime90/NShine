using NShine.Core.Extensions;
using NShine.Core.Public;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace NShine.Core.Utils
{
    /// <summary>
    /// 排序选择器应用。
    /// </summary>
    public static class OrderUtil
    {
        /// <summary>
        /// 按升序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<T> Ascending<T>(params Expression<Func<T, object>>[] keySelectors) where T : class
        {
            return new OrderSelector<T>(keySelectors);
        }

        /// <summary>
        /// 按降序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<T> Descending<T>(params Expression<Func<T, object>>[] keySelectors) where T : class
        {
            return new OrderSelector<T>(ListSortDirection.Descending, keySelectors);
        }

        /// <summary>
        /// 根据指定排序选择器集合排序。
        /// </summary>
        /// <param name="queryable">提供对数据类型已知的特定数据源的查询进行计算的功能。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(IQueryable<T> queryable, params OrderSelector<T>[] orderSelectors) where T : class
        {
            if (queryable == null || orderSelectors.IsEmpty())
            {
                return queryable;
            }
            //
            int index = 0;
            bool isAscending;
            IOrderedQueryable<T> orderedQueryable = null;
            foreach (var orderSelector in orderSelectors)
            {
                isAscending = orderSelector.SortDirection == ListSortDirection.Ascending;
                foreach (var keySelector in orderSelector.KeySelectors)
                {
                    if (index == 0)
                    {
                        orderedQueryable = isAscending ? queryable.OrderBy(keySelector) : queryable.OrderByDescending(keySelector);
                    }
                    else
                    {
                        orderedQueryable = isAscending ? orderedQueryable.ThenBy(keySelector) : orderedQueryable.ThenByDescending(keySelector);
                    }
                    //
                    index++;
                }
            }
            return orderedQueryable;
        }
    }
}
