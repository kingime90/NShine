using NShine.Core.Data.Record;
using NShine.Core.Utils;
using System;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 数据记录扩展方法。
    /// </summary>
    public static class RecordExtentsion
    {
        /// <summary>
        /// 检查唯一Key（主键为空，将自动创建主键值）。
        /// </summary>
        /// <param name="record">唯一（字符串）主键数据记录接口实例。</param>
        public static void CheckUniqueKey(this IUsidRecord record)
        {
            if (record == null || record.Id.IsNotEmpty())
            {
                return;
            }
            //
            UsidRecord nuidRecord;
            if ((nuidRecord = (record as UsidRecord)) != null)
            {
                nuidRecord.Id = KeyGeneratorUtil.NewUsid();
                return;
            }
            //
            GuidRecord guidRecord;
            if ((guidRecord = (record as GuidRecord)) != null)
            {
                guidRecord.Id = KeyGeneratorUtil.NewGuid();
                return;
            }
        }

        /// <summary>
        /// 检查创建时间数据记录接口。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="record">数据记录接口。</param>
        /// <param name="createdTime">创建时间。</param>
        public static void CheckICreatedTime<TKey>(this IRecord<TKey> record, DateTime createdTime)
        {
            ICreatedTime createdTimeRecord;
            if (record == null || (createdTimeRecord = (record as ICreatedTime)) == null || !createdTimeRecord.CreatedTime.IsDefaultValue())
            {
                return;
            }
            //CreatedTime 无赋值（排除默认最小值）
            createdTimeRecord.CreatedTime = createdTime;
        }

        /// <summary>
        /// 检查创建者数据记录接口。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="record">数据记录接口。</param>
        /// <param name="creatorId">创建者Id。</param>
        public static void CheckICreated<TKey>(this IRecord<TKey> record, int creatorId)
        {
            ICreated created;
            if (record == null || (created = (record as ICreated)) == null || !created.CreatorId.IsDefaultValue())
            {
                return;
            }
            //CreatorId 无赋值（排除默认值）
            created.CreatorId = creatorId;
        }

        /// <summary>
        /// 检查创建时间、创建者数据记录接口。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="record">数据记录实例。</param>
        /// <param name="createdTime">创建时间。</param>
        /// <param name="creatorId">创建者Id。</param>
        public static void CheckICreatedAudited<TKey>(this IRecord<TKey> record, DateTime createdTime, int creatorId)
        {
            CheckICreatedTime(record, createdTime);
            CheckICreated(record, creatorId);
        }

        /// <summary>
        /// 检查最后修改时间、最后修改者数据记录接口。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="record">数据记录接口。</param>
        /// <param name="modifiedTime">最后修改时间。</param>
        /// <param name="modifierId">最后修改者Id。</param>
        public static void CheckIModifiedAutited<TKey>(this IRecord<TKey> record, DateTime modifiedTime, int modifierId)
        {
            IModifiedAutited modifiedAutited;
            if (record == null || (modifiedAutited = (record as IModifiedAutited)) == null)
            {
                return;
            }
            //
            modifiedAutited.ModifiedTime = modifiedTime;
            modifiedAutited.ModifierId = modifierId;
        }

        /// <summary>
        /// 检查创建数据记录。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="record">数据记录实例。</param>
        /// <param name="createdTime">创建时间。</param>
        /// <param name="creatorId">创建者Id。</param>
        public static void CheckCreate<TKey>(this IRecord<TKey> record, DateTime createdTime, int creatorId)
        {
            CheckUniqueKey(record as IUsidRecord);
            CheckICreatedAudited(record, createdTime, creatorId);
            CheckIModifiedAutited(record, createdTime, creatorId);
        }
    }
}
