using NShine.Core.Collections;
using NShine.Core.Data.Record;
using NShine.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NShine.Core.Data
{
    /// <summary>
    /// 定义数据记录仓储服务接口。
    /// </summary>
    /// <typeparam name="TKey">主键类型。</typeparam>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    public interface IRepository<TKey, TRecord> : ITransientDependency where TRecord : class, IRecord<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 创建单个数据记录。
        /// </summary>
        /// <param name="record">数据记录实例。</param>
        void Create(TRecord record);

        /// <summary>
        /// 创建数据记录集合。
        /// </summary>
        /// <param name="records">数据记录实例集合。</param>
        void Create(IEnumerable<TRecord> records);

        /// <summary>
        /// 删除单个数据记录。
        /// </summary>
        /// <param name="key">主键值。</param>
        void Delete(TKey key);

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <param name="keys">主键值集合。</param>
        void Delete(IEnumerable<TKey> keys);

        /// <summary>
        /// 删除单个数据记录。
        /// </summary>
        /// <param name="record">数据记录实例。</param>
        void Delete(TRecord record);

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <param name="records">数据记录实例集合。</param>
        void Delete(IEnumerable<TRecord> records);

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        void Delete(Expression<Func<TRecord, bool>> predicate);

        /// <summary>
        /// 更新单个数据记录。
        /// </summary>
        /// <param name="record">数据记录实例。</param>
        void Update(TRecord record);

        /// <summary>
        /// 返回数据记录中满足条件的的元素数量。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <returns></returns>
        int Count(Expression<Func<TRecord, bool>> predicate);

        /// <summary>
        /// 是否存在符合指定筛选表达式的数据。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="key">排除的主键值。</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TRecord, bool>> predicate, TKey key = default(TKey));

        /// <summary>
        /// 获取单个数据记录实例。
        /// </summary>
        /// <param name="key">主键值。</param>
        /// <returns></returns>
        TRecord Get(TKey key);

        /// <summary>
        /// 获取数据记录实例集合。
        /// </summary>
        /// <param name="keys">主键值集合。</param>
        /// <returns></returns>
        IEnumerable<TRecord> Get(IEnumerable<TKey> keys);

        /// <summary>
        /// 获取单个数据记录实例。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        TRecord Single(Expression<Func<TRecord, bool>> predicate, params OrderSelector<TRecord>[] orderSelectors);

        /// <summary>
        /// 获取数据记录实例集合。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IEnumerable<TRecord> Fetch(Expression<Func<TRecord, bool>> predicate, params OrderSelector<TRecord>[] orderSelectors);

        /// <summary>
        /// 获取数据结果实例集合。
        /// </summary>
        /// <typeparam name="TResult">数据结果类型。</typeparam>
        /// <param name="selector">要应用于每个元素投影函数。</param>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IEnumerable<TResult> Fetch<TResult>(Expression<Func<TRecord, TResult>> selector, Expression<Func<TRecord, bool>> predicate, params OrderSelector<TRecord>[] orderSelectors);

        /// <summary>
        /// 分页并获取数据记录实例集合。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IPageOfItems<TRecord> PageOfItems(Expression<Func<TRecord, bool>> predicate, IPage page, params OrderSelector<TRecord>[] orderSelectors);

        /// <summary>
        /// 分页并获取数据结果实例集合。
        /// </summary>
        /// <typeparam name="TResult">数据结果类型。</typeparam>
        /// <param name="selector">要应用于每个元素投影函数。</param>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IPageOfItems<TResult> PageOfItems<TResult>(Expression<Func<TRecord, TResult>> selector, Expression<Func<TRecord, bool>> predicate, IPage page, params OrderSelector<TRecord>[] orderSelectors);
    }
}
