using System;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 值类型扩展方法。
    /// </summary>
    public static class ValueTypeExtension
    {
        #region bool

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <returns></returns>
        public static TResult Conditional<TResult>(this bool condition, TResult trueResult, TResult falseResult)
        {
            return condition ? trueResult : falseResult;
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <returns></returns>
        public static TResult Conditional<TResult>(this bool condition, Func<TResult> trueResult, TResult falseResult)
        {
            return condition ? trueResult() : falseResult;
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <returns></returns>
        public static TResult Conditional<TResult>(this bool condition, TResult trueResult, Func<TResult> falseResult)
        {
            return condition ? trueResult : falseResult();
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <returns></returns>
        public static TResult Conditional<TResult>(this bool condition, Func<TResult> trueResult, Func<TResult> falseResult)
        {
            return condition ? trueResult() : falseResult();
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <param name="param">参数值。</param>
        /// <returns></returns>
        public static TResult Conditional<TParam, TResult>(this bool condition, TResult trueResult, Func<TParam, TResult> falseResult, TParam param)
        {
            return condition ? trueResult : falseResult(param);
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <param name="param">参数值。</param>
        /// <returns></returns>
        public static TResult Conditional<TParam, TResult>(this bool condition, Func<TParam, TResult> trueResult, TResult falseResult, TParam param)
        {
            return condition ? trueResult(param) : falseResult;
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <param name="param">参数值。</param>
        /// <returns></returns>
        public static TResult Conditional<TParam, TResult>(this bool condition, Func<TResult> trueResult, Func<TParam, TResult> falseResult, TParam param)
        {
            return condition ? trueResult() : falseResult(param);
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <param name="param">参数值。</param>
        /// <returns></returns>
        public static TResult Conditional<TParam, TResult>(this bool condition, Func<TParam, TResult> trueResult, Func<TResult> falseResult, TParam param)
        {
            return condition ? trueResult(param) : falseResult();
        }

        /// <summary>
        /// 获取满足条件的结果。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <typeparam name="TResult">返回结果的类型。</typeparam>
        /// <param name="condition">条件的值。</param>
        /// <param name="trueResult">如果条件的值为 true，要返回的结果。</param>
        /// <param name="falseResult">如果条件的值为 false，要返回的结果。</param>
        /// <param name="param">参数值。</param>
        /// <returns></returns>
        public static TResult Conditional<TParam, TResult>(this bool condition, Func<TParam, TResult> trueResult, Func<TParam, TResult> falseResult, TParam param)
        {
            return condition ? trueResult(param) : falseResult(param);
        }

        #endregion

        #region DateTime

        /// <summary>
        /// 转换为其等效的短日期字符串（默认格式 yyyy-MM-dd）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy-M-d，反之 yyyy-MM-dd（默认 false）。</param>
        /// <returns></returns>
        public static string ToShortDate(this DateTime dateTime, bool isConcise = false)
        {
            return dateTime.ToString(isConcise.Conditional("yyyy-M-d", "yyyy-MM-dd"));
        }

        /// <summary>
        /// 转换为其等效的长日期字符串（默认格式 yyyy年M月d日）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy年M月d日，反之 yyyy年MM月dd日（默认 true）。</param>
        /// <returns></returns>
        public static string ToLongDate(this DateTime dateTime, bool isConcise = true)
        {
            return dateTime.ToString(isConcise.Conditional("yyyy年M月d日", "yyyy年MM月dd日"));
        }

        /// <summary>
        /// 转换为其等效的短时间字符串（HH:mm）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static string ToShortTime(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm");
        }

        /// <summary>
        /// 转换为其等效的长时间字符串（HH:mm:ss）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static string ToLongTime(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 转换为其等效的日期短字符串（默认格式 yyyy-MM-dd HH:mm:ss）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy-M-d HH:mm:ss，反之 yyyy-MM-dd HH:mm:ss（默认 false）。</param>
        /// <returns></returns>
        public static string ToShortString(this DateTime dateTime, bool isConcise = false)
        {
            return dateTime.ToString(isConcise.Conditional("yyyy-M-d HH:mm:ss", "yyyy-MM-dd HH:mm:ss"));
        }

        /// <summary>
        /// 转换为其等效的日期长字符串（默认格式 yyyy年M月d日 HH:mm:ss）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <param name="isConcise">是否简洁格式，如果为 true，日期格式 yyyy年M月d日 HH:mm:ss，反之 yyyy年MM月dd日 HH:mm:ss（默认 true）。</param>
        /// <returns></returns>
        public static string ToLongString(this DateTime dateTime, bool isConcise = true)
        {
            return dateTime.ToString(isConcise.Conditional("yyyy年M月d日 HH:mm:ss", "yyyy年MM月dd日 HH:mm:ss"));
        }

        /// <summary>
        /// 本月第一天（日期）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return dateTime.AddDays(1 - dateTime.Day).Date;
        }

        /// <summary>
        /// 本月最后一天（日期）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return FirstDayOfMonth(dateTime).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 本年第一天（日期）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime dateTime)
        {
            return FirstDayOfMonth(dateTime.AddMonths(1 - dateTime.Month));
        }

        /// <summary>
        /// 本年最后一天（日期）。
        /// </summary>
        /// <param name="dateTime">日期时间的值。</param>
        /// <returns></returns>
        public static DateTime LastDayOfYear(this DateTime dateTime)
        {
            return FirstDayOfYear(dateTime).AddYears(1).AddDays(-1);
        }

        #endregion

        #region struct T

        /// <summary>
        /// 指示指定的值是否是默认值。
        /// </summary>
        /// <typeparam name="T">要测试的类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <returns></returns>
        public static bool IsDefault<T>(this T value) where T : struct
        {
            return value.Equals(default(T));
        }

        /// <summary>
        /// 指示指定的值是否不是默认值。
        /// </summary>
        /// <typeparam name="T">要测试的类型。</typeparam>
        /// <param name="value">要测试的值。</param>
        /// <returns></returns>
        public static bool IsNotDefault<T>(this T value) where T : struct
        {
            return !value.IsDefault();
        }

        #endregion
    }
}
