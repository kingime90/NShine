using NShine.Core.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace NShine.Core.Public
{
    /// <summary>
    /// 排序选择器。
    /// </summary>
    /// <typeparam name="T">排序对象类型。</typeparam>
    public class OrderSelector<T> where T : class
    {
        private readonly ReadOnlyList<Expression<Func<T, object>>> _keySelectors;

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{T}"/>类型的新实例（默认 按升序排序）。
        /// </summary>
        /// <param name="keySelectors">用于从元素中提取键的函数数组。</param>
        public OrderSelector(params Expression<Func<T, object>>[] keySelectors)
        {
            _keySelectors = new ReadOnlyList<Expression<Func<T, object>>>(keySelectors);
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{T}"/>类型的新实例（默认 按升序排序）。
        /// </summary>
        /// <param name="keySelectors">用于从元素中提取键的函数集合。</param>
        public OrderSelector(IEnumerable<Expression<Func<T, object>>> keySelectors)
        {
            _keySelectors = new ReadOnlyList<Expression<Func<T, object>>>(keySelectors);
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{T}"/>类型的新实例。
        /// </summary>
        /// <param name="sortDirection">排序方向。</param>
        /// <param name="keySelectors">用于从元素中提取键的函数数组。</param>
        public OrderSelector(ListSortDirection sortDirection, params Expression<Func<T, object>>[] keySelectors) : this(keySelectors)
        {
            SortDirection = sortDirection;
        }

        /// <summary>
        /// 初始化一个<see cref="OrderSelector{T}"/>类型的新实例。
        /// </summary>
        /// <param name="sortDirection">排序方向。</param>
        /// <param name="keySelectors">用于从元素中提取键的函数集合。</param>
        public OrderSelector(ListSortDirection sortDirection, IEnumerable<Expression<Func<T, object>>> keySelectors) : this(keySelectors)
        {
            SortDirection = sortDirection;
        }

        /// <summary>
        /// 用于从元素中提取键的函数列表。
        /// </summary>
        public IReadOnlyList<Expression<Func<T, object>>> KeySelectors
        {
            get
            {
                return _keySelectors;
            }
        }

        /// <summary>
        /// 排序方向（默认 按升序排序）。
        /// </summary>
        public ListSortDirection SortDirection { get; } = ListSortDirection.Ascending;
    }
}
