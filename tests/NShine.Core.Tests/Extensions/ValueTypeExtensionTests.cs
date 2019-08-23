using NShine.Core.Extensions;
using NUnit.Framework;
using System;

namespace NShine.Core.Tests.Extensions
{
    /// <summary>
    /// 值类型扩展方法单元测试。
    /// </summary>
    [TestFixture]
    public class ValueTypeExtensionTests
    {
        /// <summary>
        /// 转换为其等效的短日期字符串（默认格式 yyyy-MM-dd）。
        /// </summary>
        [Test]
        public void ToShortDateTest()
        {
            var now = DateTime.Now;
            now = new DateTime(now.Year, 1, 1);
            string result;

            result = now.ToShortDate();
            Assert.AreEqual(result, now.ToString("yyyy-MM-dd"));

            result = now.ToShortDate(true);
            Assert.AreEqual(result, now.ToString("yyyy-M-d"));
        }

        /// <summary>
        /// 转换为其等效的长日期字符串（yyyy年M月d日）。
        /// </summary>
        [Test]
        public void ToLongDateTest()
        {
            var now = DateTime.Now;
            now = new DateTime(now.Year, 1, 1);
            string result;

            result = now.ToLongDate();
            Assert.AreEqual(result, now.ToString("yyyy年M月d日"));

            result = now.ToLongDate(false);
            Assert.AreEqual(result, now.ToString("yyyy年MM月dd日"));
        }
    }
}
