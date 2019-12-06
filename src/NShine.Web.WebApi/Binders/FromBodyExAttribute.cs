using System.Web.Http;
using System.Web.Http.Controllers;

namespace NShine.Web.WebApi.Binders
{
    /// <summary>
    /// HTTP来自主体绑定参数自定义特性。
    /// </summary>
    public class FromBodyExAttribute : ParameterBindingAttribute
    {
        /// 获取参数绑定。
        /// </summary>
        /// <param name="parameter">参数说明。</param>
        /// <returns></returns>
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromBodyExParameterBinding(parameter);
        }
    }
}
