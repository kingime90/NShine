using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace NShine.Web.WebApi.Utils
{
    /// <summary>
    /// JSON 媒体类型格式化应用。
    /// </summary>
    public static class JsonFormatterUtil
    {
        /// <summary>
        /// 构建设置。
        /// </summary>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static JsonMediaTypeFormatter BuildSettings(JsonMediaTypeFormatter formatter)
        {
            formatter.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            //formatter.SerializerSettings.Converters.Add(new VICloudDateTimeConverter());
            formatter.SerializerSettings.Formatting = Formatting.None;
            return formatter;
        }
    }
}
