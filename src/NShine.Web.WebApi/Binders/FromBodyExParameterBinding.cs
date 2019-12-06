using NShine.Core.Extensions;
using NShine.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace NShine.Web.WebApi.Binders
{
    /// <summary>
    /// HTTP来自主体绑定参数。
    /// </summary>
    public class FromBodyExParameterBinding : HttpParameterBinding
    {
        /// <summary>
        /// 初始化一个<see cref="FromBodyExParameterBinding"/>类型的新实例。
        /// </summary>
        /// <param name="descriptor">HTTP参数描述符。</param>
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
            //类 或 泛型
            if (!Descriptor.ParameterType.IsClass && !typeof(IEnumerable<>).IsGenericAssignableFrom(Descriptor.ParameterType))
            {
                return Task.CompletedTask;
            }
            //
            var stream = ((HttpContextBase)actionContext.Request.Properties["MS_HttpContext"]).Request.InputStream;
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                if (content.IsNotEmpty())
                {
                    //
                    SetValue(actionContext, JsonUtil.TryDeserialize(content, Descriptor.ParameterType).OrDefault(() => Activator.CreateInstance(Descriptor.ParameterType)));
                }
            }
            //
            return Task.CompletedTask;
        }
    }
}
