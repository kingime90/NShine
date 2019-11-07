using System.Collections;
using System.Collections.Generic;
using NShine.Core.Extensions;

namespace NShine.Core.Collections
{
    /// <summary>
    /// 表示可按照索引单独访问的一组只读对象。
    /// </summary>
    /// <typeparam name="T">对象类型。</typeparam>
    public class ReadOnlyList<T> : IReadOnlyList<T>
    {
        private readonly List<T> _items;

        /// <summary>
        /// 初始化一个<see cref="ReadOnlyList{T}"/>类型的新实例。
        /// </summary>
        public ReadOnlyList()
        {
            _items = new List<T>();
        }

        /// <summary>
        /// 初始化一个<see cref="ReadOnlyList{T}"/>类型的新实例。
        /// </summary>
        /// <param name="collection">数据项集合。</param>
        public ReadOnlyList(IEnumerable<T> items) : this()
        {
            if (items.IsEmpty())
            {
                return;
            }
            _items.AddRange(items);
        }

        /// <summary>
        /// 初始化一个<see cref="ReadOnlyList{T}"/>类型的新实例。
        /// </summary>
        /// <param name="collection">数据项数组。</param>
        public ReadOnlyList(params T[] items) : this()
        {
            if (items.IsEmpty())
            {
                return;
            }
            _items.AddRange(items);
        }

        /// <summary>
        /// 获取指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得的元素从零开始的索引。</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
        }

        /// <summary>
        /// 获取集合中包含的元素数。
        /// </summary>
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
