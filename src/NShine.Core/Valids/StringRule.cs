namespace NShine.Core.Valids
{
    /// <summary>
    /// 字符串合法性校验规则。
    /// </summary>
    public class StringRule : IRequired
    {
        /// <summary>
        /// 是否必须。
        /// </summary>
        public bool IsRequired { get; protected set; }
    }
}
