using NShine.Core.Collections;
using NShine.Core.Data.Record;
using NShine.Core.Extensions;
using NShine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NShine.Core.Data
{
    /// <summary>
    /// 数据记录仓储服务基类。
    /// </summary>
    /// <typeparam name="TKey">主键类型。</typeparam>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    public abstract class RepositoryBase<TKey, TRecord> : IRepository<TKey, TRecord> where TRecord : class, IRecord<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        private DbSet<TRecord> _dbSet;

        /// <summary>
        /// 数据记录查询器。
        /// </summary>
        public IQueryable<TRecord> Queryable { get; }

        /// <summary>
        /// 创建单个数据记录。
        /// </summary>
        /// <param name="record">数据记录实例。</param>
        public virtual void Create(TRecord record)
        {
            if (record == null)
            {
                return;
            }
            //
            record.CheckCreate(DateTime.Now, 0);
            _dbSet.Add(record);
        }

        /// <summary>
        /// 创建数据记录集合。
        /// </summary>
        /// <param name="records">数据记录实例集合。</param>
        public virtual void Create(IEnumerable<TRecord> records)
        {
            if (records.IsEmpty())
            {
                return;
            }
            //
            foreach (var record in records)
            {
                record.CheckCreate(DateTime.Now, 0);
            }
            _dbSet.AddRange(records);
        }

        /// <summary>
        /// 删除单个数据记录。
        /// </summary>
        /// <param name="key">主键值。</param>
        public virtual void Delete(TKey key)
        {

        }

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <param name="keys">主键值集合。</param>
        public virtual void Delete(IEnumerable<TKey> keys)
        {
            if (keys.IsEmpty())
            {
                return;
            }
            //

        }

        /// <summary>
        /// 删除单个数据记录。
        /// </summary>
        /// <param name="record">数据记录实例。</param>
        public virtual void Delete(TRecord record)
        {
            if (record == null)
            {
                return;
            }
            //
            _dbSet.Remove(record);
        }

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <param name="records">数据记录实例集合。</param>
        public virtual void Delete(IEnumerable<TRecord> records)
        {
            if (records.IsEmpty())
            {
                return;
            }
            //
            _dbSet.RemoveRange(records);
        }

        /// <summary>
        /// 删除数据记录集合。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        public virtual void Delete(Expression<Func<TRecord, bool>> predicate)
        {

        }

        /// <summary>
        /// 更新单个数据记录。
        /// </summary>
        /// <param name="record">数据记录实例。</param>
        public virtual void Update(TRecord record)
        {

        }

        /// <summary>
        /// 返回实体集合中满足条件的的元素数量。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<TRecord, bool>> predicate)
        {
            return predicate != null ? Queryable.Count(predicate) : Queryable.Count();
        }

        /// <summary>
        /// 是否存在符合指定筛选表达式的数据。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="key">排除的主键值。</param>
        /// <returns></returns>
        public virtual bool Exists(Expression<Func<TRecord, bool>> predicate, TKey key = default(TKey))
        {
            if (key.HasValue())
            {
                predicate = predicate.And(p => !p.Id.Equals(key));
            }
            return Count(predicate) > 0;
        }

        /// <summary>
        /// 获取单个数据记录实例。
        /// </summary>
        /// <param name="key">主键值。</param>
        /// <returns></returns>
        public virtual TRecord Get(TKey key)
        {
            return _dbSet.Find(key);
        }

        /// <summary>
        /// 获取数据记录实例集合。
        /// </summary>
        /// <param name="keys">主键值集合。</param>
        /// <returns></returns>
        public virtual IEnumerable<TRecord> Get(IEnumerable<TKey> keys)
        {
            if (keys.IsEmpty())
            {
                return Enumerable.Empty<TRecord>();
            }
            //
            return Queryable.Where(p => keys.Contains(p.Id)).ToList();
        }

        /// <summary>
        /// 获取单个数据记录实例。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual TRecord Single(Expression<Func<TRecord, bool>> predicate, params OrderSelector<TRecord>[] orderSelectors)
        {
            return BuildQueryable(predicate, null, orderSelectors).FirstOrDefault();
        }

        /// <summary>
        /// 获取数据记录实例集合。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual IEnumerable<TRecord> Fetch(Expression<Func<TRecord, bool>> predicate, params OrderSelector<TRecord>[] orderSelectors)
        {
            return BuildQueryable(predicate, null, orderSelectors).ToList();
        }

        /// <summary>
        /// 获取数据结果实例集合。
        /// </summary>
        /// <typeparam name="TResult">数据结果类型。</typeparam>
        /// <param name="selector">要应用于每个元素投影函数。</param>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual IEnumerable<TResult> Fetch<TResult>(Expression<Func<TRecord, TResult>> selector, Expression<Func<TRecord, bool>> predicate, params OrderSelector<TRecord>[] orderSelectors)
        {
            if (selector == null)
            {
                return Enumerable.Empty<TResult>();
            }
            //
            return BuildQueryable(predicate, null, orderSelectors).Select(selector).ToList();
        }

        /// <summary>
        /// 分页并获取数据记录实例集合。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual IPageOfItems<TRecord> PageOfItems(Expression<Func<TRecord, bool>> predicate, IPage page, params OrderSelector<TRecord>[] orderSelectors)
        {
            var safePage = PageUtil.GetSafePage(page);
            var totalCount = Count(predicate);
            if (totalCount == 0)
            {
                return PageUtil.Empty<TRecord>(safePage);
            }
            //
            return PageUtil.Items(totalCount, safePage,
                BuildQueryable(predicate, safePage, orderSelectors).ToList());
        }

        /// <summary>
        /// 分页并获取数据结果实例集合。
        /// </summary>
        /// <typeparam name="TResult">数据结果类型。</typeparam>
        /// <param name="selector">要应用于每个元素投影函数。</param>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual IPageOfItems<TResult> PageOfItems<TResult>(Expression<Func<TRecord, TResult>> selector, Expression<Func<TRecord, bool>> predicate, IPage page, params OrderSelector<TRecord>[] orderSelectors)
        {
            var safePage = PageUtil.GetSafePage(page);
            int totalCount;
            if (selector == null || (totalCount = Count(predicate)) == 0)
            {
                return PageUtil.Empty<TResult>(safePage);
            }
            //
            return PageUtil.Items(totalCount, safePage,
                BuildQueryable(predicate, safePage, orderSelectors).Select(selector).ToList());
        }

        #region 辅助方法

        /// <summary>
        /// 构建查询。
        /// </summary>
        /// <param name="predicate">筛选表达式。</param>
        /// <param name="page">分页信息接口。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        protected IQueryable<TRecord> BuildQueryable(Expression<Func<TRecord, bool>> predicate, IPage page, params OrderSelector<TRecord>[] orderSelectors)
        {
            IQueryable<TRecord> queryable = Queryable;
            //数据过滤
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            //
            var hasPage = page != null;
            if (hasPage && orderSelectors.IsEmpty())
            {
                //构建分页默认排序
                orderSelectors = new OrderSelector<TRecord>[] { OrderUtil.Build<TKey, TRecord>() };
            }
            //构建排序
            queryable = OrderUtil.Build(queryable, orderSelectors);
            //分页
            if (hasPage)
            {
                queryable = queryable.Skip(page.PageSize.Value * (page.PageNumber.Value - 1)).Take(page.PageSize.Value);
            }
            return queryable;
        }

        #endregion
    }
}