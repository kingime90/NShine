namespace NShine.Core.Valid
{
    /// <summary>
    /// 定义字符串合法性校验接口。
    /// </summary>
    public interface IStringValid : IDisplayBody, IValid<string>
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

        /// <summary>
        /// 设置主体和显示名称。
        /// </summary>
        /// <param name="body">主体名称。</param>
        /// <param name="display">显示名称。</param>
        /// <returns></returns>
        IStringValid SetBody(string body, string display = null);
    }
}
