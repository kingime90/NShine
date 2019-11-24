using NShine.Core.Valid;
using NUnit.Framework;

namespace NShine.Core.Tests.Utils
{
    /// <summary>
    /// 简单对象合法性校验单元测试。
    /// </summary>
    [TestFixture]
    public class ISimpleValidTests
    {
        /// <summary>
        /// 测试检验。
        /// </summary>
        [Test]
        public void TestCheck()
        {
            ISimpleValid<User> simpleValid = new SimpleValid<User>();
            simpleValid.StringType(s => s.Name)
                       .SetRequired()
                       .SetMinLength(2)
                       .SetMaxLength(10);
            User user = new User()
            {
                Name = "张",
            };
            var checkResult = simpleValid.Check(user);
        }
    }

    public class User
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
    }
}
