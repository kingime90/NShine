using NShine.Core.Data.Record;
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
        /// <typeparam name="T">泛型元素类型。</typeparam>
        /// <param name="keySelectors">用于从元素中提取键的函数数组。</param>
        /// <returns></returns>
        public static OrderSelector<T> Ascending<T>(params Expression<Func<T, object>>[] keySelectors) where T : class
        {
            return new OrderSelector<T>(keySelectors);
        }

        /// <summary>
        /// 按降序排序。
        /// </summary>
        /// <typeparam name="T">泛型元素类型。</typeparam>
        /// <param name="keySelectors">用于从元素中提取键的函数数组。</param>
        /// <returns></returns>
        public static OrderSelector<T> Descending<T>(params Expression<Func<T, object>>[] keySelectors) where T : class
        {
            return new OrderSelector<T>(ListSortDirection.Descending, keySelectors);
        }

        /// <summary>
        /// 构建默认排序。
        /// 优先级：
        /// 1、IOrderByAsc   Priority 升序。
        /// 2、IOrderByDesc  Priority 降序。
        /// 3、IRecord<TKey> Id 升序。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <returns></returns>
        public static OrderSelector<TRecord> Build<TKey, TRecord>()
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            //继承升序排序接口
            if (typeof(TRecord).IsSubclassOf(typeof(IOrderByAsc)))
            {
                return Ascending(ExpressionUtil.PropertySelector<TRecord>("Priority"));
            }
            //继承降序排序接口
            if (typeof(TRecord).IsSubclassOf(typeof(IOrderByDesc)))
            {
                return Descending(ExpressionUtil.PropertySelector<TRecord>("Priority"));
            }
            //默认 主键ID升序
            return Ascending<TRecord>(s => new { s.Id });
        }

        /// <summary>
        /// 根据指定排序选择器集合构建排序。
        /// </summary>
        /// <typeparam name="T">泛型元素类型。</typeparam>
        /// <param name="queryable">提供对数据类型已知的特定数据源的查询进行计算的功能。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public static IQueryable<T> Build<T>(IQueryable<T> queryable, params OrderSelector<T>[] orderSelectors) where T : class
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
                        orderedQueryable = isAscending.Conditional(queryable.OrderBy, queryable.OrderByDescending, keySelector);
                    }
                    else
                    {
                        orderedQueryable = isAscending.Conditional(orderedQueryable.ThenBy, orderedQueryable.ThenByDescending, keySelector);
                    }
                    //
                    index++;
                }
            }
            return orderedQueryable;
        }
    }
}
