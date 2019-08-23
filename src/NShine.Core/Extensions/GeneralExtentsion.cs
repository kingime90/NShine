using NShine.Core.Options;
using System;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 常规扩展方法（泛型）。
    /// </summary>
    public static class GeneralExtentsion
    {
        #region 泛型

        /// <summary>
        /// 获取指定对象的值 或 默认值 （默认 <see cref="default(T)"/>）。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="value">对象的值。</param>
        /// <param name="defaultValue">如果对象的值为 null，要返回的默认值（默认 <see cref="default(T)"/>）。</param>
        /// <returns></returns>
        public static T GetOrDefault<T>(this T value, T defaultValue = default(T)) where T : class
        {
            return (value != null).Get(value, defaultValue);
        }

        /// <summary>
        /// 比较指定的值是否大于另一个值。
        /// </summary>
        /// <typeparam name="T">比较对象类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <param name="compareValue">与此实例进行比较的值。</param>
        /// <returns></returns>
        public static bool IsGreater<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) > 0;
        }

        /// <summary>
        /// 比较指定的值是否大于等于另一个值。
        /// </summary>
        /// <typeparam name="T">比较对象类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <param name="compareValue">与此实例进行比较的值。</param>
        /// <returns></returns>
        public static bool IsGreaterEqual<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) >= 0;
        }

        /// <summary>
        /// 比较指定的值是否小于另一个值。
        /// </summary>
        /// <typeparam name="T">比较对象类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <param name="compareValue">与此实例进行比较的值。</param>
        /// <returns></returns>
        public static bool IsLess<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) < 0;
        }

        /// <summary>
        /// 比较指定的值是否小于等于另一个值。
        /// </summary>
        /// <typeparam name="T">比较对象类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <param name="compareValue">与此实例进行比较的值。</param>
        /// <returns></returns>
        public static bool IsLessEqual<T>(this T value, T compareValue) where T : struct, IComparable
        {
            return value.CompareTo(compareValue) <= 0;
        }

        /// <summary>
        /// 比较指定的值是不是在指定的范围内（默认 大于等于和小于等于）。
        /// </summary>
        /// <typeparam name="T">比较对象类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <param name="minValue">指定的范围最小值。</param>
        /// <param name="maxValue">指定的范围最大值。</param>
        /// <param name="compareOption">比较选项（默认 <see cref="CompareOption.GreaterEqAndLessEq"/>）。</param>
        /// <returns></returns>
        public static bool IsRange<T>(this T value, T minValue, T maxValue, CompareOption compareOption = CompareOption.GreaterEqAndLessEq) where T : struct, IComparable
        {
            bool result = false;
            switch (compareOption)
            {
                case CompareOption.GreaterAndLess:
                    result = value.IsGreater(minValue) && value.IsLess(maxValue);
                    break;
                case CompareOption.GreaterEqAndLess:
                    result = value.IsGreaterEqual(minValue) && value.IsLess(maxValue);
                    break;
                case CompareOption.GreaterAndLessEq:
                    result = value.IsGreater(minValue) && value.IsLessEqual(maxValue);
                    break;
                case CompareOption.GreaterEqAndLessEq:
                    result = value.IsGreaterEqual(minValue) && value.IsLessEqual(maxValue);
                    break;
            }
            return result;
        }

        #endregion

        /// <summary>
        /// 指示指定的比较器接口实例是否有值。
        /// </summary>
        /// <param name="value">比较器接口实例。</param>
        /// <returns></returns>
        public static bool HasValue<T>(this IEquatable<T> value)
        {
            return !(value == null || value.Equals(default(T)) || ((value is string) && Convert.ToString(value).IsEmpty()));
        }
    }
}
