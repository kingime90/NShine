using NShine.Core.Options;
using System;
using System.Diagnostics;

namespace NShine.Core.Dependency
{
    /// <summary>
    /// 依赖注入映射描述信息。
    /// </summary>
    [DebuggerDisplay("Lifetime = {Lifetime}, ServiceType = {ServiceType}, ImplementationType = {ImplementationType}")]
    public class ServiceDescriptor
    {
        #region 构造函数

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>类型的新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <param name="lifetime">生命周期。</param>
        public ServiceDescriptor(Type serviceType, Type implementationType, LifetimeOption lifetime) : this(serviceType, lifetime)
        {
            ImplementationType = implementationType;
        }

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>类型的新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        public ServiceDescriptor(Type serviceType, object implementationInstance, LifetimeOption lifetime) : this(serviceType, lifetime)
        {
            ImplementationInstance = implementationInstance;
        }

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>类型的新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        public ServiceDescriptor(Type serviceType, Func<IServiceProvider, object> implementationFactory, LifetimeOption lifetime) : this(serviceType, lifetime)
        {
            ImplementationFactory = implementationFactory;
        }

        /// <summary>
        /// 初始化一个<see cref="ServiceDescriptor"/>类型的新实例。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="lifetime">生命周期。</param>
        private ServiceDescriptor(Type serviceType, LifetimeOption lifetime)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 生命周期。
        /// </summary>
        public LifetimeOption Lifetime { get; }

        /// <summary>
        /// 服务类型。
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// 服务实现类型。
        /// </summary>
        public Type ImplementationType { get; }

        /// <summary>
        /// 服务实现实例。
        /// </summary>
        public object ImplementationInstance { get; }

        /// <summary>
        /// 服务实现实例工厂。
        /// </summary>
        public Func<IServiceProvider, object> ImplementationFactory { get; }

        #endregion

        #region 方法

        /// <summary>
        /// 创建实时生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <returns></returns>
        public static ServiceDescriptor Transient<TService, TImplementation>()
            where TService : class
            where TImplementation : TService
        {
            return Descriptor<TService, TImplementation>(LifetimeOption.Transient);
        }

        /// <summary>
        /// 创建实时生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient(Type serviceType, Type implementationType)
        {
            return Descriptor(serviceType, implementationType, LifetimeOption.Transient);
        }

        /// <summary>
        /// 创建实时生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : TService
        {
            return Descriptor(typeof(TService), implementationFactory, LifetimeOption.Transient);
        }

        /// <summary>
        /// 创建实时生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient<TService>(Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            return Descriptor(typeof(TService), implementationFactory, LifetimeOption.Transient);
        }

        /// <summary>
        /// 创建实时生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Transient(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return Descriptor(serviceType, implementationFactory, LifetimeOption.Transient);
        }

        /// <summary>
        /// 创建局部生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <returns></returns>
        public static ServiceDescriptor Scope<TService, TImplementation>()
            where TService : class
            where TImplementation : TService
        {
            return Descriptor<TService, TImplementation>(LifetimeOption.Scope);
        }

        /// <summary>
        /// 创建局部生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scope(Type serviceType, Type implementationType)
        {
            return Descriptor(serviceType, implementationType, LifetimeOption.Scope);
        }

        /// <summary>
        /// 创建局部生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scope<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : TService
        {
            return Descriptor(typeof(TService), implementationFactory, LifetimeOption.Scope);
        }

        /// <summary>
        /// 创建局部生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scope<TService>(Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            return Descriptor(typeof(TService), implementationFactory, LifetimeOption.Scope);
        }

        /// <summary>
        /// 创建局部生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Scope(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return Descriptor(serviceType, implementationFactory, LifetimeOption.Scope);
        }

        /// <summary>
        /// 创建单例生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <returns></returns>
        public static ServiceDescriptor Singleton<TService, TImplementation>()
            where TService : class
            where TImplementation : TService
        {
            return Descriptor<TService, TImplementation>(LifetimeOption.Singleton);
        }

        /// <summary>
        /// 创建单例生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton(Type serviceType, Type implementationType)
        {
            return Descriptor(serviceType, implementationType, LifetimeOption.Singleton);
        }

        /// <summary>
        /// 创建单例生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : TService
        {
            return Descriptor(typeof(TService), implementationFactory, LifetimeOption.Singleton);
        }

        /// <summary>
        /// 创建单例生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton<TService>(Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            return Descriptor(typeof(TService), implementationFactory, LifetimeOption.Singleton);
        }

        /// <summary>
        /// 创建单例生命周期类型的依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <returns></returns>
        public static ServiceDescriptor Singleton(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return Descriptor(serviceType, implementationFactory, LifetimeOption.Singleton);
        }

        /// <summary>
        /// 创建单例生命周期类型实例的依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Instance<TService>(TService implementationInstance)
            where TService : class
        {
            return Descriptor(typeof(TService), implementationInstance, LifetimeOption.Singleton);
        }

        /// <summary>
        /// 创建单例生命周期类型实例的依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <returns></returns>
        public static ServiceDescriptor Instance(Type serviceType, object implementationInstance)
        {
            return Descriptor(serviceType, implementationInstance, LifetimeOption.Singleton);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor<TService, TImplementation>(LifetimeOption lifetime)
            where TService : class
            where TImplementation : TService
        {
            return Descriptor(typeof(TService), typeof(TImplementation), lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor(Type serviceType, Type implementationType, LifetimeOption lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationType, lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor(Type serviceType, object implementationInstance, LifetimeOption lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationInstance, lifetime);
        }

        /// <summary>
        /// 创建依赖注入映射描述信息。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        /// <returns></returns>
        public static ServiceDescriptor Descriptor(Type serviceType, Func<IServiceProvider, object> implementationFactory, LifetimeOption lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationFactory, lifetime);
        }

        #endregion
    }
}
