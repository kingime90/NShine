using System;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 可 null 值类型扩展方法。
    /// </summary>
    public static class NullableTypeExtension
    {
        #region T

        /// <summary>
        /// 获取指定可 null 值类型的值 或 默认值 （默认 <see cref="default(T)"/>）。
        /// </summary>
        /// <typeparam name="T">泛型类型的基础值类型。</typeparam>
        /// <param name="value">可 null 值类型的值。</param>
        /// <param name="defaultValue">默认值。</param>
        /// <returns></returns>
        public static T OrDefault<T>(this T? value, T defaultValue = default(T)) where T : struct
        {
            return value.GetValueOrDefault(defaultValue);
        }

        #endregion

        #region bool

        /// <summary>
        /// 指示指定的可 null 布尔类型是否有值并且值为 true。
        /// </summary>
        /// <param name="value">可 null 布尔类型的值。</param>
        /// <returns></returns>
        public static bool IsTrue(this bool? value)
        {
            return value.HasValue && value.Value;
        }

        /// <summary>
        /// 指示指定的可 null 布尔类型是否没有值或值为 false。
        /// </summary>
        /// <param name="value">可 null 布尔类型的值。</param>
        /// <returns></returns>
        public static bool IsFalse(this bool? value)
        {
            return !value.IsTrue();
        }

        #endregion

        #region DateTime

        /// <summary>
        /// 转换为其等效的短日期字符串（默认格式 yyyy-MM-dd）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy-M-d，反之 yyyy-MM-dd（默认 false）。</param>
        /// <returns></returns>
        public static string ToShortDate(this DateTime? dateTime, string defaultValue = "", bool isConcise = false)
        {
            return dateTime.HasValue.Conditional(() => dateTime.Value.ToShortDate(isConcise), defaultValue);
        }

        /// <summary>
        /// 转换为其等效的长日期字符串（默认格式 yyyy年M月d日）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy年M月d日，反之 yyyy年MM月dd日（默认 true）。</param>
        /// <returns></returns>
        public static string ToLongDate(this DateTime? dateTime, string defaultValue = "", bool isConcise = true)
        {
            return dateTime.HasValue.Conditional(() => dateTime.Value.ToLongDate(isConcise), defaultValue);
        }

        /// <summary>
        /// 转换为其等效的短时间字符串（HH:mm）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static string ToShortTime(this DateTime? dateTime, string defaultValue = "")
        {
            return dateTime.HasValue.Conditional(() => dateTime.Value.ToShortTime(), defaultValue);
        }

        /// <summary>
        /// 转换为其等效的长时间字符串（HH:mm:ss）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static string ToLongTime(this DateTime? dateTime, string defaultValue = "")
        {
            return dateTime.HasValue.Conditional(() => dateTime.Value.ToLongTime(), defaultValue);
        }

        /// <summary>
        /// 转换为其等效的日期短字符串（默认格式 yyyy-MM-dd HH:mm:ss）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy-M-d HH:mm:ss，反之 yyyy-MM-dd HH:mm:ss（默认 false）。</param>
        /// <returns></returns>
        public static string ToShortString(this DateTime? dateTime, string defaultValue = "", bool isConcise = false)
        {
            return dateTime.HasValue.Conditional(() => dateTime.Value.ToShortString(isConcise), defaultValue);
        }

        /// <summary>
        /// 转换为其等效的日期长字符串（默认格式 yyyy年M月d日 HH:mm:ss）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy年M月d日 HH:mm:ss，反之 yyyy年MM月dd日 HH:mm:ss（默认 true）。</param>
        /// <returns></returns>
        public static string ToLongString(this DateTime? dateTime, string defaultValue = "", bool isConcise = true)
        {
            return dateTime.HasValue.Conditional(() => dateTime.Value.ToLongString(isConcise), defaultValue);
        }

        #endregion
    }
}
