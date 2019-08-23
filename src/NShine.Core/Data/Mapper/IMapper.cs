using System;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace NShine.Core.Data.Mapper
{
    /// <summary>
    /// 定义数据记录映射接口。
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// 数据库上下文类型。
        /// </summary>
        Type DbContextType { get; }

        /// <summary>
        /// 将数据记录映射对象注册到当前数据访问上下文数据记录映射配置注册器中。
        /// </summary>
        /// <param name="configurations">数据记录映射配置注册器。</param>
        void RegistTo(ConfigurationRegistrar configurations);
    }
}
