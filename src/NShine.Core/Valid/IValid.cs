namespace NShine.Core.Valid
{
    /// <summary>
    /// 定义数据合法性校验接口。
    /// </summary>
    public interface IValid
    {

    }

    /// <summary>
    /// 定义数据合法性校验泛型接口。
    /// </summary>
    /// <typeparam name="T">要校验的对象的类型。</typeparam>
    public interface IValid<in T> : IValid
    {
        /// <summary>
        /// 检验。
        /// </summary>
        /// <param name="value">值。</param>
        /// <returns></returns>
        CheckResult Check(T value);
    }
}
