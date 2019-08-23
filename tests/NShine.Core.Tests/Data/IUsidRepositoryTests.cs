using NShine.Core.Data;
using NShine.Core.Tests.Data.Records;
using NShine.Core.Valids;
using NUnit.Framework;

namespace NShine.Core.Tests.Data
{
    /// <summary>
    /// 唯一字符串主键数据记录仓储服务接口单元测试。
    /// </summary>
    [TestFixture]
    public class IUsidRepositoryTests
    {
        private static IUsidRepository<UserRecord> repository;

        /// <summary>
        /// 初始化
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            repository = new UsidRepository<UserRecord>();
        }

        /// <summary>
        /// 创建单个数据记录测试。
        /// </summary>
        [Test]
        public void CreateTest()
        {
            var userRecord = new UserRecord
            {
                Username = "test001",
                Nickname = "test001",
                Mobile = "13000000000",
            };
            repository.Create(userRecord);
        }
    }
}
