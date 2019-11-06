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
        /// <param name="isIgnoreWhite">是否忽略前后空白字符（默认 忽略）。</param>
        /// <returns></returns>
        public static bool IsEmpty(this string value, bool isIgnoreWhite = true)
        {
            return isIgnoreWhite.Conditional(string.IsNullOrWhiteSpace, string.IsNullOrEmpty, value);
        }

        /// <summary>
        /// 指示指定的字符串不是 null 并且 不是 System.String.Empty 字符串（默认 忽略前后空白字符）。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <param name="isIgnoreWhite">是否忽略前后空白字符（默认 忽略）。</param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string value, bool isIgnoreWhite = true)
        {
            return !value.IsEmpty(isIgnoreWhite);
        }

        /// <summary>
        /// 确定此字符串是否与另一个指定的 System.String 对象具有相同的值，忽略大小写。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <param name="compareValue">要与此实例进行比较的字符串。</param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string value, string compareValue)
        {
            return value.Equals(compareValue, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 获取字符串 或 默认字符串（默认 清空前后空白字符）。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <param name="defaultValue">如果字符串的值的为 null，要返回的默认字符串。</param>
        /// <param name="isClearWhite">是否清空前后空白字符（默认 清空）。</param>
        /// <returns></returns>
        public static string OrDefault(this string value, string defaultValue, bool isClearWhite = true)
        {
            return value != null ? isClearWhite.Conditional(value.Trim, value) : defaultValue;
        }

        /// <summary>
        /// 安全清空指定字符串前后空白字符。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <returns></returns>
        public static string SafeTrim(this string value)
        {
            return value.OrDefault(string.Empty, true);
        }

        /// <summary>
        /// 使用固定区域性的大小写规则，将指定字符串安全的转换为大写形式的副本。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <returns></returns>
        public static string ToSafeUpper(this string value)
        {
            if (value.IsEmpty())
            {
                return string.Empty;
            }
            //
            return value.ToUpperInvariant();
        }

        /// <summary>
        /// 使用固定区域性的大小写规则，将指定字符串安全的转换为小写形式的副本。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <returns></returns>
        public static string ToSafeLower(this string value)
        {
            if (value.IsEmpty())
            {
                return string.Empty;
            }
            //
            return value.ToLowerInvariant();
        }

        /// <summary>
        /// 使用固定区域性的大小写规则，将指定字符串首字母安全的转换为大写形式的副本。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <returns></returns>
        public static string ToFirstUpper(this string value)
        {
            if (value.IsEmpty())
            {
                return string.Empty;
            }
            //
            var result = value[0].ToString().ToUpperInvariant();
            if (value.Length > 1)
            {
                result += value.Substring(1);
            }
            //
            return result;
        }

        /// <summary>
        /// 使用固定区域性的大小写规则，将指定字符串首字母安全的转换为小写形式的副本。
        /// </summary>
        /// <param name="value">字符串的值。</param>
        /// <returns></returns>
        public static string ToFirstLower(this string value)
        {
            if (value.IsEmpty())
            {
                return string.Empty;
            }
            //
            var result = value[0].ToString().ToLowerInvariant();
            if (value.Length > 1)
            {
                result += value.Substring(1);
            }
            //
            return result;
        }

        /// <summary>
        /// 替换指定字符串的开头（默认 循环完全替换）。
        /// </summary>
        /// <param name="value">要替换的字符串。</param>
        /// <param name="start">匹配开头的字符串。</param>
        /// <param name="replace">要替换开头出现的 start 的字符串。</param>
        /// <param name="isComplete">是否完全替换，如果为 true，将会循环完全替换，否则只替换一次（默认 完全替换）。</param>
        /// <returns></returns>
        public static string ReplaceStart(this string value, string start, string replace, bool isComplete = true)
        {
            if (value.IsEmpty(false) || start.IsEmpty(false) || !value.StartsWith(start))
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
        /// 替换指定字符串的尾部（默认 循环完全替换）。
        /// </summary>
        /// <param name="value">要替换的字符串。</param>
        /// <param name="end">匹配尾部的字符串。</param>
        /// <param name="replace">要替换尾部出现的 end 的字符串。</param>
        /// <param name="isComplete">是否完全替换，如果为 true，将会循环完全替换，否则只替换一次（默认 完全替换）。</param>
        /// <returns></returns>
        public static string ReplaceEnd(this string value, string end, string replace, bool isComplete = true)
        {
            if (value.IsEmpty(false) || end.IsEmpty(false) || !value.EndsWith(end))
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
        /// 移除指定字符串的匹配开头的字符串（默认 循环完全移除）。
        /// </summary>
        /// <param name="value">要移除的字符串。</param>
        /// <param name="start">匹配开头的字符串。</param>
        /// <param name="isComplete">是否完全移除，如果为 true，将会循环完全移除，否则只移除一次（默认 完全移除）。</param>
        /// <returns></returns>
        public static string RemoveStart(this string value, string start, bool isComplete = true)
        {
            return value.ReplaceStart(start, string.Empty, isComplete);
        }

        /// <summary>
        /// 移除指定字符串的匹配尾部的字符串（默认 循环完全移除）。
        /// </summary>
        /// <param name="value">要移除的字符串。</param>
        /// <param name="end">匹配尾部的字符串。</param>
        /// <param name="isComplete">是否完全移除，如果为 true，将会循环完全移除，否则只移除一次（默认 完全移除）。</param>
        /// <returns></returns>
        public static string RemoveEnd(this string value, string end, bool isComplete = true)
        {
            return value.ReplaceEnd(end, string.Empty, isComplete);
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

        /// <summary>
        /// 基于数组中的字符串将字符串拆分为多个子字符串（默认 移除空字符串的数组元素）。 
        /// </summary>
        /// <param name="value">要分隔的字符串。</param>
        /// <param name="separator">分隔此字符串中子字符串的字符串数组、不包含分隔符的空数组或 null。</param>
        /// <returns></returns>
        public static string[] Split(this string value, params string[] separator)
        {
            if (value == null || separator.IsEmpty())
            {
                return Array.Empty<string>();
            }
            //
            return value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
