namespace NShine.Core.Valid
{
    /// <summary>
    /// 显示主体。
    /// </summary>
    public class DisplayBody : IDisplayBody
    {
        /// <summary>
        /// 初始化一个<see cref="DisplayBody"/>类型的成功实例。
        /// </summary>
        /// <param name="body"></param>
        /// <param name="display"></param>
        public DisplayBody(string body, string display)
        {
            Body = body;
            Display = display;
        }

        /// <summary>
        /// 主体名称。
        /// </summary>
        public virtual string Body { get; }

        /// <summary>
        /// 显示名称。
        /// </summary>
        public virtual string Display { get; }
    }
}
