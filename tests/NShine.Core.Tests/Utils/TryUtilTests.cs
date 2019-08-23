using NUnit.Framework;

namespace NShine.Core.Tests.Utils
{
    /// <summary>
    /// 尝试执行方法应用单元测试。
    /// </summary>
    [TestFixture]
    public class TryUtilTests
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
