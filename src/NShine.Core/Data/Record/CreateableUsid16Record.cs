﻿using System;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 可创建的16位长度唯一字符串主键数据记录。
    /// </summary>
    public abstract class CreateableUsid16Record : Usid16Record, ICreatedAudited
    {
        /// <summary>
        /// 获取或设置 创建时间。
        /// </summary>
        public virtual DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 创建者ID。
        /// </summary>
        public virtual int CreatorId { get; set; }
    }
}
