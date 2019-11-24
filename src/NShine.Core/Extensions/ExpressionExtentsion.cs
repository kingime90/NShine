using System;
using System.Linq;
using System.Linq.Expressions;
using NShine.Core.Lambda;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// Expression扩展方法。
    /// </summary>
    public static class ExpressionExtentsion
    {
        /// <summary>
        /// 使用指定的条件运算方式组合两个表达式。
        /// </summary>
        /// <typeparam name="T">表达式主体类型。</typeparam>
        /// <param name="first">第一个Expression表达式。</param>
        /// <param name="second">要组合的Expression表达式。</param>
        /// <param name="merge">条件运算方式。</param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var parameterSet = first.Parameters.Select((firstParameter, i) => new { FirstParameter = firstParameter, SecondParameter = second.Parameters[i] })
                                .ToDictionary(p => p.SecondParameter, p => p.FirstParameter);
            var secondBody = ParameterRebinder.ReplaceParameters(parameterSet, second.Body);
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// 以 Expression.AndAlso 运算方式组合两个表达式。
        /// </summary>
        /// <typeparam name="T">表达式主体类型。</typeparam>
        /// <param name="first">第一个表达式。</param>
        /// <param name="second">第二个表达式。</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return Compose(first, second, Expression.AndAlso);
        }

        /// <summary>
        /// 以 Expression.OrElse 运算方式组合两个表达式。
        /// </summary>
        /// <typeparam name="T">表达式主体类型。</typeparam>
        /// <param name="first">第一个表达式。</param>
        /// <param name="second">第二个表达式。</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return Compose(first, second, Expression.OrElse);
        }
    }
}
