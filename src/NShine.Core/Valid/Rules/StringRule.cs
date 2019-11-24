namespace NShine.Core.Valid.Rules
{
    /// <summary>
    /// 字符串合法性校验规则。
    /// </summary>
    public class StringRule : IRequiredRule
    {
        /// <summary>
        /// 是否必须。
        /// </summary>
        public bool IsRequired { get; protected set; }
    }
}
