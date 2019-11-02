using System.Collections.Generic;
using System.Linq;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 集合扩展方法。
    /// </summary>
    public static class CollectionExtentsion
    {
        /// <summary>
        /// 指示指定的泛型集合是 null 或 集合中的元素为空。
        /// </summary>
        /// <typeparam name="T">集合中元素的类型。</typeparam>
        /// <param name="source">泛型集合对象。</param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || Enumerable.Count(source) == 0;
        }

        /// <summary>
        /// 指示指定的泛型集合不是 null 并且 集合中的元素不为空。
        /// </summary>
        /// <typeparam name="T">集合中元素的类型。</typeparam>
        /// <param name="source">泛型集合对象。</param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return !source.IsEmpty();
        }
    }
}
