using System.Web.Mvc;

namespace NShine.Web.Mvc.Binders
{
    /// <summary>
    /// 模型字符串处理类，移除传入字符串的前后空格。
    /// </summary>
    public class StringTrimModelBinder : DefaultModelBinder
    {
        /// <summary>
        /// 通过使用指定的控制器上下文和绑定上下文绑定模型。
        /// </summary>
        /// <param name="controllerContext">控制器操作的上下文。上下文信息包括控制器、HTTP内容、请求上下文和路由数据。</param>
        /// <param name="bindingContext">模型所绑定的上下文。上下文包括模型对象、模型名称、模型类型、属性筛选器和值提供程序等信息。</param>
        /// <returns></returns>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = base.BindModel(controllerContext, bindingContext);
            string str;
            if ((str = (value as string)) != null)
            {
                return str.Trim();
            }
            //
            return value;
        }
    }
}
