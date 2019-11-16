using NShine.Core.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NShine.Core.Dependency
{
    /// <summary>
    /// 构建依赖注入映射基类。
    /// </summary>
    public abstract class IocBuilderBase : IIocBuilder
    {
        private readonly IServiceCollection _services;

        private bool _isBuilded = false;

        /// <summary>
        /// 初始化一个<see cref="IocBuilderBase"/>类型的新实例。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        public IocBuilderBase(IServiceCollection services)
        {
            _services = services.Clone();
            AssemblyFinder = new DirectoryAssemblyFinder();
        }

        /// <summary>
        /// 获取 服务提供者。
        /// </summary>
        public IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// 获取或设置 程序集查找器。
        /// </summary>
        public IAssemblyFinder AssemblyFinder { get; private set; }

        /// <summary>
        /// 开始构建依赖注入映射。
        /// </summary>
        public void Build()
        {
            if (_isBuilded)
            {
                return;
            }
            //
            AddServices(_services);
            var assemblies = AssemblyFinder.FindAll();
            ServiceProvider = Register(_services, assemblies);
            _isBuilded = true;
        }

        /// <summary>
        /// 添加服务类型。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        public abstract void AddServices(IServiceCollection services);

        /// <summary>
        /// 将服务映射信息注册到依赖注入容器中。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        /// <param name="assemblies">要检索的程序集集合。</param>
        /// <returns></returns>
        public abstract IServiceProvider Register(IServiceCollection services, IEnumerable<Assembly> assemblies);
    }
}
