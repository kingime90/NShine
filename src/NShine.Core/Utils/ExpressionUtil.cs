using System;
using System.Linq.Expressions;

namespace NShine.Core.Utils
{
    /// <summary>
    /// 表达式树应用。
    /// </summary>
    public static class ExpressionUtil
    {
        /// <summary>
        /// 从元素中提取属性的函数。
        /// </summary>
        /// <typeparam name="T">泛型元素类型。</typeparam>
        /// <param name="propertyName">属性名称。</param>
        /// <returns></returns>
        public static Expression<Func<T, object>> PropertySelector<T>(string propertyName)
        {
            //参数 p， p=>p.
            var param = Expression.Parameter(typeof(T), "p");
            var body = Expression.Property(param, propertyName);
            return Expression.Lambda(body, param) as Expression<Func<T, object>>;
        }
    }
}
