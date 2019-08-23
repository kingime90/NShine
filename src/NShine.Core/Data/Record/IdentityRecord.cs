namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 自增唯一整数主键数据记录基类。
    /// </summary>
    public abstract class IdentityRecord : IUiidRecord
    {
        /// <summary>
        /// 获取或设置 主键Id。
        /// </summary>
        public virtual int Id { get; set; }
    }
}
