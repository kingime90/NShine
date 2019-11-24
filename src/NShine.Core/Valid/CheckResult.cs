namespace NShine.Core.Valid
{
    /// <summary>
    /// 校验结果。
    /// </summary>
    public class CheckResult
    {
        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的成功实例，默认 成功。
        /// </summary>
        public CheckResult()
        {
            Success = true;
        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的失败实例，默认 不成功。
        /// </summary>
        /// <param name="message">错误消息。</param>
        public CheckResult(string message)
        {
            Message = message;
        }

        /// <summary>
        /// 是否成功。
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// 错误消息。
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 设置成功。
        /// </summary>
        public void SetSuccess()
        {
            if (Success)
            {
                return;
            }
            //
            Success = true;
        }

        /// <summary>
        /// 设置不成功错误消息。
        /// </summary>
        /// <param name="message">错误消息。</param>
        public void SetMessage(string message)
        {
            if (Success)
            {
                Success = false;
            }
            //
            Message = message;
        }
    }
}
