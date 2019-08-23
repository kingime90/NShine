using System;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义最后修改时间、最后修改者数据记录接口（在更新数据记录时，将自动设置当前系统时间为最后修改时间，当前登录用户Id为最后修改者Id）。
    /// </summary>
    public interface IModifiedAutited
    {
        /// <summary>
        /// 获取或设置 最后修改时间。
        /// </summary>
        DateTime ModifiedTime { get; set; }

        /// <summary>
        /// 获取或设置 最后修改者Id。
        /// </summary>
        int ModifierId { get; set; }
    }
}
