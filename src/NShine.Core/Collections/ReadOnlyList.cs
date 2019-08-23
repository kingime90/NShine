using NShine.Core.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace NShine.Core.Collections
{
    /// <summary>
    /// 表示可按照索引单独访问的一组只读对象。
    /// </summary>
    /// <typeparam name="T">对象类型。</typeparam>
    public class ReadOnlyList<T> : IReadOnlyList<T>
    {
        private readonly List<T> _collection;

        /// <summary>
        /// 初始化一个<see cref="ReadOnlyList{T}"/>类型的新实例。
        /// </summary>
        public ReadOnlyList()
        {
            _collection = new List<T>();
        }

        /// <summary>
        /// 初始化一个<see cref="ReadOnlyList{T}"/>类型的新实例。
        /// </summary>
        /// <param name="collection">对象集合。</param>
        public ReadOnlyList(IEnumerable<T> collection) : this()
        {
            if (collection.IsEmpty())
            {
                return;
            }
            _collection.AddRange(collection);
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
                return _collection[index];
            }
        }

        /// <summary>
        /// 获取集合中包含的元素数。
        /// </summary>
        public int Count
        {
            get
            {
                return _collection.Count;
            }
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
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
