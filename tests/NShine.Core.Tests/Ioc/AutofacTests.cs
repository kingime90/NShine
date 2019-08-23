using System.Collections.Generic;
using Autofac;
using NUnit.Framework;

namespace NShine.Core.Tests.Ioc
{
    [TestFixture]
    public class AutofacTests
    {
        private static IContainer Container;

        /// <summary>
        /// 初始化
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            //1、注册类型，自身
            //builder.RegisterType<Cat>();

            //2、注册类型，自身
            //builder.RegisterType<Cat>().AsSelf();

            //将Component封装成服务使用
            builder.RegisterType<Cat>().AsSelf().As<IAnimal>();
            Container = builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ResolveTest()
        {
            //检索单个实现
            var cat = Container.Resolve<Cat>();
            var animal = Container.Resolve<IAnimal>();
            string catSay = cat.Say();
            string animalSay = animal.Say();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void LifetimeScopeResolveTest()
        {
            //开始一个新的嵌套范围。通过新范围创建的组件实例将与它一起处理。
            using (var scope = Container.BeginLifetimeScope())
            {
                var cat = scope.Resolve<Cat>();
                var animal = scope.Resolve<IAnimal>();
                string catSay = cat.Say();
                string animalSay = animal.Say();
                //检索集合的实现
                var animals = scope.Resolve<IEnumerable<IAnimal>>();
            }
        }
    }
}
