namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义创建者数据记录接口（在创建数据记录时，将自动设置当前登录用户ID为创建者ID）。
    /// </summary>
    public interface ICreated
    {
        /// <summary>
        /// 获取或设置 创建者ID。
        /// </summary>
        int CreatorId { get; set; }
    }
}
