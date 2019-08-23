using System;

namespace NShine.Core.Utils
{
    /// <summary>
    /// 尝试执行方法应用。
    /// </summary>
    public static class TryUtil
    {
        /// <summary>
        /// 尝试执行指定的无参数无返回值的方法。
        /// </summary>
        /// <param name="action">要尝试执行的方法。</param>
        public static void Execute(Action action)
        {
            Execute(action, null);
        }

        /// <summary>
        /// 尝试执行指定的无参数无返回值的方法。
        /// </summary>
        /// <param name="action">要尝试执行的方法。</param>
        /// <param name="callback">尝试执行发生异常，回调的方法。</param>
        public static void Execute(Action action, Action<Exception> callback)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
        }

        /// <summary>
        /// 尝试执行指定的有参数无返回值的方法。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <param name="action">要尝试执行的方法。</param>
        /// <param name="param">参数值。</param>
        public static void Execute<TParam>(Action<TParam> action, TParam param)
        {
            Execute(action, param, null);
        }

        /// <summary>
        /// 尝试执行指定的有参数无返回值的方法。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <param name="action">要尝试执行的方法。</param>
        /// <param name="param">参数值。</param>
        /// <param name="callback">尝试执行发生异常，回调的方法。</param>
        public static void Execute<TParam>(Action<TParam> action, TParam param, Action<TParam, Exception> callback)
        {
            try
            {
                action?.Invoke(param);
            }
            catch (Exception ex)
            {
                callback?.Invoke(param, ex);
            }
        }

        /// <summary>
        /// 尝试执行指定的无参数有返回值的方法。
        /// </summary>
        /// <typeparam name="TResult">返回值的类型。</typeparam>
        /// <param name="action">要尝试执行的方法。</param>
        /// <param name="defaultValue">尝试执行发生异常，要返回的默认值。</param>
        /// <returns></returns>
        public static TResult Execute<TResult>(Func<TResult> action, TResult defaultValue)
        {
            var result = defaultValue;
            try
            {
                result = action();
            }
            catch
            {

            }
            return result;
        }

        /// <summary>
        /// 尝试执行指定的无参数有返回值的方法。
        /// </summary>
        /// <typeparam name="TResult">返回值的类型。</typeparam>
        /// <param name="action">要尝试执行的方法。</param>
        /// <param name="callback">尝试执行发生异常，回调的方法。</param>
        /// <returns></returns>
        public static TResult Execute<TResult>(Func<TResult> action, Func<Exception, TResult> callback)
        {
            var result = default(TResult);
            try
            {
                result = action();
            }
            catch (Exception ex)
            {
                if (callback != null)
                {
                    result = callback(ex);
                }
            }
            return result;
        }

        /// <summary>
        /// 尝试执行指定的有参数有返回值的方法。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <typeparam name="TResult">返回值的类型。</typeparam>
        /// <param name="action">要尝试执行的方法。</param>
        /// <param name="param">参数值。</param>
        /// <param name="defaultValue">尝试执行发生异常，要返回的默认值。</param>
        /// <returns></returns>
        public static TResult Execute<TParam, TResult>(Func<TParam, TResult> action, TParam param, TResult defaultValue)
        {
            var result = defaultValue;
            try
            {
                result = action(param);
            }
            catch
            {

            }
            return result;
        }

        /// <summary>
        /// 尝试执行指定的有参数有返回值的方法。
        /// </summary>
        /// <typeparam name="TParam">参数的类型。</typeparam>
        /// <typeparam name="TResult">返回值的类型。</typeparam>
        /// <param name="action">要尝试执行的方法。</param>
        /// <param name="param">参数值。</param>
        /// <param name="callback">尝试执行发生异常，回调的方法。</param>
        /// <returns></returns>
        public static TResult Execute<TParam, TResult>(Func<TParam, TResult> action, TParam param, Func<TParam, Exception, TResult> callback)
        {
            var result = default(TResult);
            try
            {
                result = action(param);
            }
            catch (Exception ex)
            {
                if (callback != null)
                {
                    result = callback(param, ex);
                }
            }
            return result;
        }
    }
}
