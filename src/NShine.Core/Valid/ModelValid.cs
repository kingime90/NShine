namespace NShine.Core.Valid
{
    /// <summary>
    /// 泛型模型验证。
    /// </summary>
    /// <typeparam name="T">要校验的模型对象的类型。</typeparam>
    public abstract class ModelValid<T> : SimpleValid<T>, IModelValid where T : class
    {
        /// <summary>
        /// 检验。
        /// </summary>
        /// <returns></returns>
        public virtual CheckResult Check()
        {
            return Check(this as T);
        }
    }
}
