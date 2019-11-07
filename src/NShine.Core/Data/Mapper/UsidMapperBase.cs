using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using NShine.Core.Data.Record;

namespace NShine.Core.Data.Mapper
{
    /// <summary>
    /// 唯一字符串主键数据记录映射配置基类。
    /// </summary>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    /// <typeparam name="TDbContext">数据库上下文类型。</typeparam>
    public abstract class UsidMapperBase<TRecord, TDbContext> : MapperBase<string, TRecord, TDbContext>
        where TRecord : class, IUsidRecord, new()
        where TDbContext : DbContext
    {
        /// <summary>
        /// 主键映射。
        /// </summary>
        protected override void KeyMapping()
        {
            var usidRecord = (IUsidRecord)Activator.CreateInstance<TRecord>();
            //主键长度 + 10（扩展）
            var keyLength = usidRecord.KeyLength() + 10;
            //主键值手动模式
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsUnicode(false).HasMaxLength(keyLength);
        }
    }
}
