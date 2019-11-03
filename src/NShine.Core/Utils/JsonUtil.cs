using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace NShine.Core.Utils
{
    /// <summary>
    /// JSON序列化应用。
    /// </summary>
    public static class JsonUtil
    {
        /// <summary>
        /// JSON转换器的默认设置。
        /// </summary>
        static JsonUtil()
        {
            if (JsonConvert.DefaultSettings == null)
            {
                JsonConvert.DefaultSettings = () =>
                {
                    var serializerSettings = new JsonSerializerSettings();
                    serializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                    return serializerSettings;
                };
            }
        }

        /// <summary>
        /// 将指定的对象序列化为JSON字符串。
        /// </summary>
        /// <param name="value">要序列化的对象的值。</param>
        /// <returns></returns>
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// 使用格式化将指定的对象序列化为JSON字符串。
        /// </summary>
        /// <param name="value">要序列化的对象的值。</param>
        /// <param name="format">格式化选项。</param>
        /// <returns></returns>
        public static string Serialize(object value, Formatting format)
        {
            return JsonConvert.SerializeObject(value, format);
        }

        /// <summary>
        /// 从包含JSON的字符串中获取JObject。
        /// </summary>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <returns></returns>
        public static dynamic Deserialize(string value)
        {
            return JObject.Parse(value);
        }

        /// <summary>
        /// 尝试从包含JSON的字符串中获取JObject。
        /// </summary>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <returns></returns>
        public static dynamic TryDeserialize(string value)
        {
            return TryUtil.ExecuteResult(Deserialize, value);
        }

        /// <summary>
        /// 将JSON反序列化为指定的类型。
        /// </summary>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <param name="type">指定的类型。</param>
        /// <returns></returns>
        public static object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }

        /// <summary>
        /// 尝试将JSON反序列化为指定的类型。
        /// </summary>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <param name="type">指定的类型。</param>
        /// <returns></returns>
        public static object TryDeserialize(string value, Type type)
        {
            return TryUtil.ExecuteResult(() => Deserialize(value, type));
        }

        /// <summary>
        /// 将JSON反序列化为指定的对象类型。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <returns></returns>
        public static T Deserialize<T>(string value) where T : class
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 尝试将JSON反序列化为指定的对象类型。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <returns></returns>
        public static T TryDeserialize<T>(string value) where T : class
        {
            return TryUtil.ExecuteResult(Deserialize<T>, value);
        }

        /// <summary>
        /// 将JSON反序列化为给定的匿名类型。
        /// </summary>
        /// <typeparam name="T">匿名类型。</typeparam>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <param name="anonymousTypeObject">匿名类型对象。</param>
        /// <returns></returns>
        public static T Deserialize<T>(string value, T anonymousTypeObject) where T : class
        {
            return JsonConvert.DeserializeAnonymousType(value, anonymousTypeObject);
        }

        /// <summary>
        /// 尝试将JSON反序列化为给定的匿名类型。
        /// </summary>
        /// <typeparam name="T">匿名类型。</typeparam>
        /// <param name="value">要反序列化的字符串的值。</param>
        /// <param name="anonymousTypeObject">匿名类型对象。</param>
        /// <returns></returns>
        public static T TryDeserialize<T>(string value, T anonymousTypeObject) where T : class
        {
            return TryUtil.ExecuteResult(() => Deserialize(value, anonymousTypeObject));
        }
    }
}
