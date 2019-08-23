using System;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 可创建的全局唯一标识字符串主键数据记录。
    /// </summary>
    public abstract class CreateableGuidRecord : GuidRecord, ICreatedAudited
    {
        /// <summary>
        /// 获取或设置 创建时间。
        /// </summary>
        public virtual DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 创建者Id。
        /// </summary>
        public virtual int CreatorId { get; set; }
    }
}
