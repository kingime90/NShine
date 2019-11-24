namespace NShine.Core.Valid
{
    /// <summary>
    /// 定义字符串合法性校验接口。
    /// </summary>
    public interface IStringValid : IValid<string>
    {
        /// <summary>
        /// 设置必须。 
        /// </summary>
        /// <param name="required">是否必须。</param>
        /// <returns></returns>
        IStringValid SetRequired(bool required = true);

        /// <summary>
        /// 设置最小长度。 
        /// </summary>
        /// <param name="minLength">最小长度。</param>
        /// <returns></returns>
        IStringValid SetMinLength(uint minLength);

        /// <summary>
        /// 设置最大长度。 
        /// </summary>
        /// <param name="maxLength">最大长度。</param>
        /// <returns></returns>
        IStringValid SetMaxLength(uint maxLength);

        /// <summary>
        /// 设置长度范围。 
        /// </summary>
        /// <param name="minLength">最小长度。</param>
        /// <param name="maxLength">最大长度。</param>
        /// <returns></returns>
        IStringValid RangeLength(uint minLength, uint maxLength);
    }
}
