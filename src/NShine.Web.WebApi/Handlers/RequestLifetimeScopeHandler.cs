using NShine.Web.WebApi.Constants;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace NShine.Web.WebApi.Handlers
{
    /// <summary>
    /// 请求的生命周期作用域处理器。
    /// </summary>
    public class RequestLifetimeScopeHandler : DelegatingHandler
    {
        /// <summary>
        /// 将 HTTP 请求发送到内部处理程序将发送到服务器以异步操作。
        /// </summary>
        /// <param name="request">要向服务器发送的 HTTP 请求消息。</param>
        /// <param name="cancellationToken">要取消操作的取消标记。</param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var scope = CallContext.LogicalGetData(HttpConstant.RequestLifetimeScopeKey) as IDependencyScope;
            if (scope == null)
            {
                scope = request.GetDependencyScope();
                CallContext.LogicalSetData(HttpConstant.RequestLifetimeScopeKey, scope);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
