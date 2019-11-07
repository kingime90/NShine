using System;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义最后修改者数据记录接口（在更新数据记录时，将自动设置当前登录用户ID为最后修改者ID）。
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        /// 获取或设置 最后修改者ID。
        /// </summary>
        int ModifierId { get; set; }
    }
}
