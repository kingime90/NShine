namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 唯一字符串主键数据记录基类。
    /// </summary>
    public abstract class UsidRecord : IUsidRecord
    {
        /// <summary>
        /// 获取或设置 主键Id。
        /// </summary>
        public virtual string Id { get; set; }
    }
}
