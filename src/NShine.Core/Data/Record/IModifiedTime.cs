using System;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义最后修改时间数据记录接口。（在更新数据记录时，将自动设置当前系统时间为最后修改时间）。
    /// </summary>
    public interface IModifiedTime
    {
        /// <summary>
        /// 获取或设置 最后修改时间。
        /// </summary>
        DateTime ModifiedTime { get; set; }
    }
}
