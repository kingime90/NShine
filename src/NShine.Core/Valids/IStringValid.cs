namespace NShine.Core.Valids
{
    /// <summary>
    /// 定义字符串合法性校验接口。
    /// </summary>
    public interface IStringValid : IValid<string>
    {
        /// <summary>
        /// 设置必须。 
        /// </summary>
        /// <param name="isRequired">是否必须。</param>
        /// <returns></returns>
        IStringValid Required(bool isRequired = true);
    }
}
