using NShine.Core.Extensions;
using NUnit.Framework;
using System.Collections.Generic;

namespace NShine.Core.Tests.Extensions
{
    /// <summary>
    /// 集合扩展方法单元测试。
    /// </summary>
    [TestFixture]
    public class CollectionExtentsionTests
    {
        /// <summary>
        /// 指示指定的泛型集合是 null 或 集合中的元素为空。
        /// </summary>
        [Test]
        public void IsEmptyTest()
        {
            List<string> value = null;
            bool condition;

            condition = value.IsEmpty();
            Assert.IsTrue(condition);

            value = new List<string>();
            condition = value.IsEmpty();
            Assert.IsTrue(condition);

            value = new List<string>()
            {
                ".Net",
            };
            condition = value.IsEmpty();
            Assert.IsFalse(condition);
        }
    }
}