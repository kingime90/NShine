using NShine.Core.Data.Record;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace NShine.Core.Data.Mapper
{
    /// <summary>
    /// 数据记录映射配置基类。
    /// </summary>
    /// <typeparam name="TKey">主键类型。</typeparam>
    /// <typeparam name="TRecord">数据记录类型。</typeparam>
    /// <typeparam name="TDbContext">数据库上下文类型。</typeparam>
    public abstract class MapperBase<TKey, TRecord, TDbContext> : EntityTypeConfiguration<TRecord>, IMapper
        where TKey : IEquatable<TKey>
        where TRecord : class, IRecord<TKey>, new()
        where TDbContext : DbContext
    {
        private readonly Type _dbContextType = typeof(TDbContext);

        /// <summary>
        /// 数据库上下文类型。
        /// </summary>
        public Type DbContextType
        {
            get
            {
                return _dbContextType;
            }
        }

        /// <summary>
        /// 将数据记录映射对象注册到当前数据访问上下文数据记录映射配置注册器中。
        /// </summary>
        /// <param name="configurations">数据记录映射配置注册器。</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            KeyMapping();
            PropertyMapping();
            configurations.Add(this);
        }
        /// <summary>
        /// 主键映射。
        /// </summary>
        protected virtual void KeyMapping()
        {

        }

        /// <summary>
        /// 属性映射。
        /// </summary>
        protected virtual void PropertyMapping()
        {

        }
    }
}
