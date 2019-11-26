using System.Web.Http;
using System.Web.Http.Controllers;

namespace NShine.Web.WebApi.Binders
{
    /// <summary>
    /// 一个特性，该特性指定操作参数仅来自传入 System.Net.Http.HttpRequestMessage 的实体正文。
    /// </summary>
    public class FromBodyExAttribute : ParameterBindingAttribute
    {
        /// <summary>
        /// 获取参数绑定。
        /// </summary>
        /// <param name="parameter">参数说明。</param>
        /// <returns></returns>
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}
