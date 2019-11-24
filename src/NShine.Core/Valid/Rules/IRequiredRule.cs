namespace NShine.Core.Valid.Rules
{
    /// <summary>
    /// 定义必须接口。
    /// </summary>
    public interface IRequiredRule
    {
        /// <summary>
        /// 是否必须。
        /// </summary>
        bool IsRequired { get; }
    }
}
