namespace NShine.Core.Public
{
    /// <summary>
    /// 泛型行为结果。
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ActionResult<TResult> : ActionResult
    {
        /// <summary>
        /// 初始化一个<see cref="ActionResult{TResult}"/>类型的失败实例，默认 成功。
        /// </summary>
        /// <param name="result">结果。</param>
        public ActionResult(TResult result) : this(true, null, result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ActionResult{TResult}"/>类型的失败实例，默认 不成功。
        /// </summary>
        /// <param name="message">消息。</param>
        public ActionResult(string message) : this(false, message, default(TResult))
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ActionResult"/>类型的失败实例，默认 不成功。
        /// </summary>
        /// <param name="success">是否成功。</param>
        /// <param name="message">消息。</param>
        /// <param name="result">结果。</param>
        public ActionResult(bool success, string message, TResult result) : base(success, message)
        {
            Result = result;
        }

        /// <summary>
        /// 结果。
        /// </summary>
        public virtual TResult Result { get; private set; }

        /// <summary>
        /// 设置成功结果。
        /// </summary>
        /// <param name="result">结果。</param>
        public void SetResult(TResult result)
        {
            SetSuccess();
            Result = result;
        }
    }

    /// <summary>
    /// 行为结果。
    /// </summary>
    public class ActionResult : IActionResult
    {
        /// <summary>
        /// 初始化一个<see cref="ActionResult"/>类型的成功实例，默认 成功。
        /// </summary>
        public ActionResult() : this(true, null)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ActionResult"/>类型的失败实例，默认 不成功。
        /// </summary>
        /// <param name="message">消息。</param>
        public ActionResult(string message) : this(false, message)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ActionResult"/>类型的失败实例，默认 不成功。
        /// </summary>
        /// <param name="success">是否成功。</param>
        /// <param name="message">消息。</param>
        public ActionResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        /// <summary>
        /// 是否成功。
        /// </summary>
        public virtual bool Success { get; private set; }

        /// <summary>
        /// 消息。
        /// </summary>
        public virtual string Message { get; private set; }

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
        /// 设置不成功消息。
        /// </summary>
        /// <param name="message">消息。</param>
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