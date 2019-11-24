namespace NShine.Core.Public
{
    /// <summary>
    /// 定义行为结果接口。
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        /// 是否成功。
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// 消息。
        /// </summary>
        string Message { get; }
    }
}
