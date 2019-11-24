using NShine.Core.Public;

namespace NShine.Core.Valid
{
    /// <summary>
    /// 校验结果。
    /// </summary>
    public class CheckResult : ActionResult, IDisplayBody
    {
        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的成功实例，默认 成功。
        /// </summary>
        public CheckResult() : this(null, null, true, null)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的失败实例，默认 不成功。
        /// </summary>
        /// <param name="message">消息。</param>
        public CheckResult(string message) : this(null, null, false, message)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的成功实例，默认 成功。
        /// </summary>
        /// <param name="displayBody">显示主体接口。</param>
        public CheckResult(IDisplayBody displayBody) : this(displayBody?.Body, displayBody?.Display, true, null)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的成功实例，默认 成功。
        /// </summary>
        /// <param name="body">主体名称。</param>
        /// <param name="display">显示名称。</param>
        public CheckResult(string body, string display) : this(body, display, true, null)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的成功实例。
        /// </summary>
        /// <param name="body">主体名称。</param>
        /// <param name="display">显示名称。</param>
        /// <param name="success">是否成功。</param>
        /// <param name="message">消息。</param>
        public CheckResult(string body, string display, bool success, string message) : base(success, message)
        {
            Body = body;
            Display = display;
        }

        /// <summary>
        /// 主体名称。
        /// </summary>
        public virtual string Body { get; private set; }

        /// <summary>
        /// 显示名称。
        /// </summary>
        public virtual string Display { get; private set; }

        /// <summary>
        /// 设置主体名称。
        /// </summary>
        /// <param name="body">主体名称。</param>
        public void SetBody(string body)
        {
            Body = body;
        }

        /// <summary>
        /// 设置显示名称。
        /// </summary>
        /// <param name="display">显示名称。</param>
        public void SetDisplay(string display)
        {
            Display = display;
        }
    }
}