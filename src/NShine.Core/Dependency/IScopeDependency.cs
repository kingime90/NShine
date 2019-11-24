using NShine.Core.Dependency;
using NShine.Core.Options;

namespace NShine
{
    /// <summary>
    /// 继承此接口的类型将被注册为<see cref="LifetimeOption.Scope"/>模式。
    /// </summary>
    public interface IScopeDependency : IDependency
    {

    }
}
