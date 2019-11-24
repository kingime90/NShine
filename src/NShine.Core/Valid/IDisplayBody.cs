namespace NShine.Core.Valid
{
    /// <summary>
    /// 定义显示主体接口。
    /// </summary>
    public interface IDisplayBody
    {
        /// <summary>
        /// 主体名称。
        /// </summary>
        string Body { get; }

        /// <summary>
        /// 显示名称。
        /// </summary>
        string Display { get; }
    }
}
