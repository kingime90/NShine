namespace NShine.Core.Valid
{
    /// <summary>
    /// 定义模型验证接口。
    /// </summary>
    public interface IModelValid
    {
        /// <summary>
        /// 检验。
        /// </summary>
        /// <returns></returns>
        CheckResult Check();
    }
}
