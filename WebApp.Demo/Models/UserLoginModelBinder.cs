using NShine.Core.Extensions;
using NShine.Core.Utils;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace WebApp.Demo
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLoginModelBinder : IModelBinder
    {
        public UserLoginModelBinder()
        {

        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var stream = ((HttpContextBase)actionContext.Request.Properties["MS_HttpContext"]).Request.InputStream;
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                string content = streamReader.ReadToEnd();
                if (content.IsNotEmpty())
                {
                    var model = JsonUtil.Deserialize(content, bindingContext.ModelType);
                    bindingContext.Model = model;
                }
            }
            return true;
        }
    }
}
