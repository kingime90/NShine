using NShine.Core.Extensions;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace NShine.Web.WebApi.Binders
{
    /// <summary>
    /// 模型绑定器，移除字符串的前后空白字符。
    /// </summary>
    public class StringTrimModelBinder : IModelBinder
    {
        public StringTrimModelBinder()
        {

        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType.FullName != "System.String")
            {
                return false;
            }
            //
            var provider = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (provider == null)
            {
                return false;
            }
            //
            bindingContext.Model = (provider.RawValue as string).SafeTrim();
            return true;
        }
    }
}
