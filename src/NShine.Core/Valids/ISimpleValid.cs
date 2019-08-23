using System;
using System.Linq.Expressions;

namespace NShine.Core.Valids
{
    /// <summary>
    /// 定义简单对象合法性校验接口。
    /// </summary>
    /// <typeparam name="T">对象类型。</typeparam>
    public interface ISimpleValid<T> where T : class
    {
        /// <summary>
        /// 字符串类型验证。
        /// </summary>
        /// <param name="propertySelector">选择字符串类型属性函数。</param>
        /// <returns></returns>
        IStringValid StringType(Expression<Func<T, string>> propertySelector);

        /// <summary>
        /// 检验。
        /// </summary>
        /// <param name="obj">要检验对象的实例。</param>
        /// <returns></returns>
        CheckResult Check(T obj);
    }
}
