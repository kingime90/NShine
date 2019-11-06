using NShine.Core.Collections;
using NShine.Core.Data;
using NShine.Core.Data.Record;
using NShine.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 数据记录仓储服务接口扩展方法。
    /// </summary>
    public static class IRepositoryExtentsion
    {
        /// <summary>
        /// 创建数据记录集合。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <param name="records">数据记录实例数组。</param>
        public static void Create<TKey, TRecord>(this IRepository<TKey, TRecord> repository, params TRecord[] records)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            repository.Create(records);
        }

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <param name="keys">主键值数组。</param>
        public static void Delete<TKey, TRecord>(this IRepository<TKey, TRecord> repository, params TKey[] keys)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            repository.Delete(keys);
        }

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <param name="records">数据记录实例数组。</param>
        public static void Delete<TKey, TRecord>(this IRepository<TKey, TRecord> repository, params TRecord[] records)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            repository.Delete(records);
        }

        /// <summary>
        /// 返回数据记录中满足条件的的元素数量。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <returns></returns>
        public static int Count<TKey, TRecord>(this IRepository<TKey, TRecord> repository)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            return repository.Count(null);
        }

        /// <summary>
        /// 获取数据记录实例集合。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <param name="keys">主键值数组。</param>
        /// <returns></returns>
        public static IEnumerable<TRecord> Get<TKey, TRecord>(this IRepository<TKey, TRecord> repository, params TKey[] keys)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            return repository.Get(keys);
        }

        /// <summary>
        /// 获取数据结果实例集合。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <typeparam name="TResult">数据结果类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <param name="selector">要应用于每个元素投影函数。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public static IEnumerable<TResult> Fetch<TKey, TRecord, TResult>(this IRepository<TKey, TRecord> repository, Expression<Func<TRecord, TResult>> selector, params OrderSelector<TRecord>[] orderSelectors)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            return repository.Fetch(selector, null, orderSelectors);
        }

        /// <summary>
        /// 分页并获取数据记录实例集合。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public static IPageOfItems<TRecord> PageOfItems<TKey, TRecord>(this IRepository<TKey, TRecord> repository, IPage page, params OrderSelector<TRecord>[] orderSelectors)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            return repository.PageOfItems(null, page, orderSelectors);
        }

        /// <summary>
        /// 分页并获取数据结果实例集合。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <typeparam name="TRecord">数据记录类型。</typeparam>
        /// <typeparam name="TResult">数据结果类型。</typeparam>
        /// <param name="repository">数据记录仓储服务接口。</param>
        /// <param name="selector">要应用于每个元素投影函数。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public static IPageOfItems<TResult> PageOfItems<TKey, TRecord, TResult>(this IRepository<TKey, TRecord> repository, Expression<Func<TRecord, TResult>> selector, IPage page, params OrderSelector<TRecord>[] orderSelectors)
            where TRecord : class, IRecord<TKey>, new()
            where TKey : IEquatable<TKey>
        {
            return repository.PageOfItems(selector, null, page, orderSelectors);
        }
    }
}
