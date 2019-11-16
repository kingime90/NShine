using System;
using System.Linq;

namespace NShine.Core.Reflection
{
    /// <summary>
    /// 服务类型<see cref="{TServiceType}"/>的实现类型查找器。
    /// </summary>
    /// <typeparam name="TServiceType">服务类型。</typeparam>
    public abstract class ImplementTypeFinderBase<TServiceType> : FinderBase<Type>, ITypeFinder
    {
        /// <summary>
        /// 初始化一个<see cref="ImplementTypeFinderBase"/>类型的新实例。
        /// </summary>
        public ImplementTypeFinderBase()
        {
            AssemblyFinder = new DirectoryAssemblyFinder();
        }

        /// <summary>
        /// 获取或设置 程序集查找器。
        /// </summary>
        public IAssemblyFinder AssemblyFinder { get; private set; }

        /// <summary>
        /// 查找所有项。
        /// </summary>
        /// <returns></returns>
        public override Type[] FindAll()
        {
            var assemblies = AssemblyFinder.FindAll();
            var serviceType = typeof(TServiceType);
            return assemblies.SelectMany(assembly => assembly.GetTypes().Where(type => serviceType.IsAssignableFrom(type))).Distinct().ToArray();
        }
    }
}
