using Autofac;
using Autofac.Builder;
using Autofac.Core;
using NShine.Core.Dependency;
using NShine.Core.Options;
using System;
using System.Reflection;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// Autofac 扩展方法。
    /// </summary>
    public static class AutofacExtension
    {
        /// <summary>
        /// 将服务映射信息注册到依赖注入容器中。
        /// </summary>
        /// <param name="builder">Autofac 容器构建器。</param>
        /// <param name="services">服务映射信息集合。</param>
        public static void RegisterServices(this ContainerBuilder builder, IServiceCollection services)
        {
            builder.RegisterType<IocServiceProvider>().As<IServiceProvider>().SingleInstance();
            RegisterServiceTypes(builder, services);
        }

        #region 辅助方法

        /// <summary>
        /// 将服务映射信息注册到依赖注入容器中。
        /// </summary>
        /// <param name="builder">Autofac 容器构建器。</param>
        /// <param name="services">服务映射信息集合。</param>
        private static void RegisterServiceTypes(ContainerBuilder builder, IServiceCollection services)
        {
            TypeInfo serviceTypeInfo;
            IComponentRegistration registration;
            foreach (ServiceDescriptor descriptor in services)
            {
                if (descriptor.ImplementationType != null)
                {
                    serviceTypeInfo = descriptor.ServiceType.GetTypeInfo();
                    if (serviceTypeInfo.IsGenericTypeDefinition)
                    {
                        if (!descriptor.ServiceType.IsGenericAssignableFrom(descriptor.ImplementationType))
                        {
                            throw new InvalidOperationException($"泛型类型“{descriptor.ServiceType}”不能由类型“{descriptor.ImplementationType}”指派");
                        }
                        //
                        builder.RegisterGeneric(descriptor.ImplementationType)
                            .As(descriptor.ServiceType)
                            .AsSelf()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                            .ConfigureLifetime(descriptor.Lifetime);
                    }
                    else
                    {
                        if (!descriptor.ServiceType.IsAssignableFrom(descriptor.ImplementationType))
                        {
                            throw new InvalidOperationException($"类型“{descriptor.ServiceType}”不能由类型“{descriptor.ImplementationType}”指派");
                        }
                        //
                        builder.RegisterType(descriptor.ImplementationType)
                            .As(descriptor.ServiceType)
                            .AsSelf()
                            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                            .ConfigureLifetime(descriptor.Lifetime);
                    }
                }
                else if (descriptor.ImplementationFactory != null)
                {
                    registration = RegistrationBuilder.ForDelegate(descriptor.ServiceType,
                        (context, paramters) =>
                        {
                            var provider = context.Resolve<IServiceProvider>();
                            return descriptor.ImplementationFactory(provider);
                        })
                        .ConfigureLifetime(descriptor.Lifetime)
                        .CreateRegistration();
                    builder.RegisterComponent(registration);
                }
                else if (descriptor.ImplementationInstance != null)
                {
                    builder.RegisterInstance(descriptor.ImplementationInstance)
                        .As(descriptor.ServiceType)
                        .AsSelf()
                        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                        .ConfigureLifetime(descriptor.Lifetime);
                }
            }
        }

        /// <summary>
        /// 注册生命周期。
        /// </summary>
        /// <typeparam name="TActivatorData"></typeparam>
        /// <typeparam name="TRegistrationStyle"></typeparam>
        /// <param name="builder">Autofac 容器构建器。</param>
        /// <param name="lifetime">生命周期选项。</param>
        /// <returns></returns>
        private static IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> ConfigureLifetime<TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> builder,
            LifetimeOption lifetime)
        {
            switch (lifetime)
            {
                case LifetimeOption.Transient:
                    builder.InstancePerDependency();
                    break;
                case LifetimeOption.Scope:
                    builder.InstancePerLifetimeScope();
                    break;
                case LifetimeOption.Singleton:
                    builder.SingleInstance();
                    break;
            }
            return builder;
        }

        #endregion
    }
}