using System;
using System.Text;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// String 扩展方法。
    /// </summary>
    public static class StringExtentsion
    {
        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串（默认 忽略前后空白字符）。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <param name="isIgnoreWhite">是否忽略前后空白字符（默认 true）。</param>
        /// <returns></returns>
        public static bool IsEmpty(this string value, bool isIgnoreWhite = true)
        {
            return isIgnoreWhite.Get(string.IsNullOrWhiteSpace, string.IsNullOrEmpty, value);
        }

        /// <summary>
        /// 指示指定的字符串不是 null 并且 不是 System.String.Empty 字符串（默认 忽略前后空白字符）。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <param name="isIgnoreWhite">是否忽略前后空白字符（默认 true）。</param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string value, bool isIgnoreWhite = true)
        {
            return !IsEmpty(value, isIgnoreWhite);
        }

        /// <summary>
        /// 获取字符串或默认值（默认 清除前后空白字符）。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <param name="defaultValue">如果字符串的值的为 null，要返回的默认字符串（默认 “空字符串”）。</param>
        /// <returns></returns>
        public static string GetOrDefault(this string value, string defaultValue = "")
        {
            return GetOrDefault(value, true, defaultValue);
        }

        /// <summary>
        /// 获取字符串 或 默认值。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <param name="isClearWhite">是否清除前后空白字符。</param>
        /// <param name="defaultValue">如果字符串的值的为 null，要返回的默认字符串（默认 “空字符串”）。</param>
        /// <returns></returns>
        public static string GetOrDefault(this string value, bool isClearWhite, string defaultValue = "")
        {
            return value != null ? (isClearWhite ? value.Trim() : value) : defaultValue;
        }

        /// <summary>
        /// 替换指定字符串的开头（默认 完全替换）。
        /// </summary>
        /// <param name="value">要替换的字符串。</param>
        /// <param name="start">匹配开头的字符串。</param>
        /// <param name="replace">要替换开头出现的 start 的字符串。</param>
        /// <param name="isComplete">是否完全替换，如果为 true，将会循环完全替换，否则只替换一次（默认 true）。</param>
        /// <returns></returns>
        public static string ReplaceStart(this string value, string start, string replace, bool isComplete = true)
        {
            if (IsEmpty(value, false) || IsEmpty(start, false) || !value.StartsWith(start))
            {
                return value;
            }
            //
            value = replace + value.Remove(0, start.Length);
            if (!isComplete)
            {
                return value;
            }
            //
            return ReplaceStart(value, start, replace, isComplete);
        }

        /// <summary>
        /// 替换指定字符串的尾部（默认 完全替换）。
        /// </summary>
        /// <param name="value">要替换的字符串。</param>
        /// <param name="end">匹配尾部的字符串。</param>
        /// <param name="replace">要替换尾部出现的 end 的字符串。</param>
        /// <param name="isComplete">是否完全替换，如果为 true，将会循环完全替换，否则只替换一次（默认 true）。</param>
        /// <returns></returns>
        public static string ReplaceEnd(this string value, string end, string replace, bool isComplete = true)
        {
            if (IsEmpty(value, false) || IsEmpty(end, false) || !value.EndsWith(end))
            {
                return value;
            }
            //
            value = value.Substring(0, value.Length - end.Length) + replace;
            if (!isComplete)
            {
                return value;
            }
            //
            return ReplaceEnd(value, end, replace, isComplete);
        }

        /// <summary>
        /// 基于数组中的字符串将字符串拆分为多个子字符串（默认 移除空字符串的数组元素）。 
        /// </summary>
        /// <param name="value">要分隔的字符串。</param>
        /// <param name="separator">分隔此字符串中子字符串的字符串数组、不包含分隔符的空数组或 null。</param>
        /// <returns></returns>
        public static string[] Split(this string value, params string[] separator)
        {
            return value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Base64加密字符串。
        /// </summary>
        /// <param name="value">要加密的字符串。</param>
        /// <returns></returns>
        public static string ToBase64(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Base64解密字符串。
        /// </summary>
        /// <param name="value">要解密的字符串。</param>
        /// <returns></returns>
        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }
}
