using NShine.Core.Data.Record;
using System;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 数据记录扩展方法。
    /// </summary>
    public static class IRecordExtentsion
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
            record.GenerateKey();
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
            if (record == null || (createdTimeRecord = (record as ICreatedTime)) == null || createdTimeRecord.CreatedTime.IsNotDefault())
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
            ICreated createdRecord;
            if (record == null || (createdRecord = (record as ICreated)) == null || createdRecord.CreatorId.IsNotDefault())
            {
                return;
            }
            //CreatorId 无赋值（排除默认值）
            createdRecord.CreatorId = creatorId;
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
            record.CheckICreatedTime(createdTime);
            record.CheckICreated(creatorId);
        }

        /// <summary>
        /// 检查最后修改时间数据记录接口。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="record">数据记录接口。</param>
        /// <param name="modifiedTime">最后修改时间。</param>
        public static void CheckIModifiedTime<TKey>(this IRecord<TKey> record, DateTime modifiedTime)
        {
            IModifiedTime modifiedTimeRecord;
            if (record == null || (modifiedTimeRecord = (record as IModifiedTime)) == null)
            {
                return;
            }
            //
            modifiedTimeRecord.ModifiedTime = modifiedTime;
        }

        /// <summary>
        /// 检查最后修改者数据记录接口。
        /// </summary>
        /// <typeparam name="TKey">主键类型。</typeparam>
        /// <param name="record">数据记录接口。</param>
        /// <param name="modifierId">最后修改者Id。</param>
        public static void CheckIModifier<TKey>(this IRecord<TKey> record, int modifierId)
        {
            IModifier modifierRecord;
            if (record == null || (modifierRecord = (record as IModifier)) == null)
            {
                return;
            }
            //
            modifierRecord.ModifierId = modifierId;
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
            record.CheckIModifiedTime(modifiedTime);
            record.CheckIModifier(modifierId);
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
            (record as IUsidRecord).CheckUniqueKey();
            record.CheckICreatedAudited(createdTime, creatorId);
            record.CheckIModifiedAutited(createdTime, creatorId);
        }
    }
}