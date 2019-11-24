namespace NShine.Core.Valid.Rules
{
    /// <summary>
    /// 字符串合法性校验规则。
    /// </summary>
    public class StringRule : IRequiredRule
    {
        /// <summary>
        /// 初始化一个<see cref="StringRule"/>类型的新实例。
        /// </summary>
        /// <param name="required">是否必须。</param>
        public StringRule(bool required = false)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="StringRule"/>类型的新实例。
        /// </summary>
        /// <param name="required">是否必须。</param>
        /// <param name="minLength">最小长度。</param>
        /// <param name="maxLength">最大长度。</param>
        public StringRule(bool required, uint minLength, uint maxLength)
        {
            Required = required;
            MinLength = minLength;
            MaxLength = maxLength;
        }

        /// <summary>
        /// 是否必须。
        /// </summary>
        public bool Required { get; protected set; }

        /// <summary>
        /// 最小长度。
        /// </summary>
        public uint MinLength { get; protected set; }

        /// <summary>
        /// 最大长度。
        /// </summary>
        public uint MaxLength { get; protected set; }
    }
}
