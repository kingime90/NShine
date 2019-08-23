namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义创建者数据记录接口（在创建数据记录时，将自动设置当前登录用户Id为创建者Id）。
    /// </summary>
    public interface ICreated
    {
        /// <summary>
        /// 获取或设置 创建者Id。
        /// </summary>
        int CreatorId { get; set; }
    }
}
