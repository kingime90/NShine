using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;

namespace NShine.Web.WebApi.Binders
{
    /// <summary>
    /// 
    /// </summary>
    public class FromBodyExParameterBinding : HttpParameterBinding
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="descriptor"></param>
        public FromBodyExParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
        {
            
        }

        /// <summary>
        /// 以异步方式执行给定请求的绑定。
        /// </summary>
        /// <param name="metadataProvider">要用于验证的元数据提供程序。</param>
        /// <param name="actionContext">绑定的操作上下文。操作上下文包含将使用参数填充的参数字典。</param>
        /// <param name="cancellationToken">用于取消绑定操作的取消标记。</param>
        /// <returns></returns>
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
