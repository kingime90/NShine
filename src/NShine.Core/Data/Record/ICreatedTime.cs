using System;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义创建时间数据记录接口（在创建数据记录时，将自动设置当前系统时间为创建时间）。
    /// </summary>
    public interface ICreatedTime
    {
        /// <summary>
        /// 获取或设置 创建时间。
        /// </summary>
        DateTime CreatedTime { get; set; }
    }
}
