using System;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 可编辑的19位长度唯一字符串主键数据记录。
    /// </summary>
    public abstract class EditableUsid19Record : Usid19Record, ICreatedAudited, IModifiedAutited
    {
        /// <summary>
        /// 获取或设置 创建时间。
        /// </summary>
        public virtual DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 创建者ID。
        /// </summary>
        public virtual int CreatorId { get; set; }

        /// <summary>
        /// 获取或设置 最后修改时间。
        /// </summary>
        public virtual DateTime ModifiedTime { get; set; }

        /// <summary>
        /// 获取或设置 最后修改者ID。
        /// </summary>
        public virtual int ModifierId { get; set; }
    }
}
