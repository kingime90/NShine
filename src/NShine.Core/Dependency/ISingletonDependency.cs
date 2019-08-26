﻿using NShine.Core.Options;

namespace NShine.Core.Dependency
{
    /// <summary>
    /// 继承此接口的类型将被注册为<see cref="LifetimeOption.Singleton"/>模式。
    /// </summary>
    public interface ISingletonDependency : IDependency
    {

    }
}
