using System;
using NShine.Core.Extensions;

namespace NShine.Core.Utils
{
    /// <summary>
    /// 对象克隆应用。
    /// </summary>
    public static class CloneableUtil
    {
        /// <summary>
        /// 深复制克隆对象。
        /// </summary>
        /// <typeparam name="T">要克隆的泛型类型。</typeparam>
        /// <param name="t">要克隆的对象实例。</param>
        /// <returns></returns>
        public static T Clone<T>(T t) where T : class
        {
            if (t == null)
            {
                return t;
            }
            //
            return JsonUtil.Deserialize<T>(JsonUtil.Serialize(t));
        }

        /// <summary>
        /// 合并。
        /// </summary>
        /// <typeparam name="T">要合并的泛型类型。</typeparam>
        /// <param name="source">要合并的来源。</param>
        /// <param name="defaultValue">要合并的默认值。</param>
        /// <param name="isDeepCopy">是否深度复制。</param>
        /// <returns></returns>
        public static T Merge<T>(T source, T defaultValue, bool isDeepCopy = true) where T : class
        {
            if (source == null || defaultValue == null)
            {
                return source.OrDefault(defaultValue);
            }
            //
            var type = typeof(T);
            var properties = type.GetProperties();
            var result = Clone(defaultValue);
            object value;
            foreach (var property in properties)
            {
                value = property.GetValue(source);
                if (value == null || (property.PropertyType.FullName == "System.String" && Convert.ToString(value).IsEmpty()))
                {
                    continue;
                }
                //
                property.SetValue(result, value);
            }
            return result;
        }
    }
}
