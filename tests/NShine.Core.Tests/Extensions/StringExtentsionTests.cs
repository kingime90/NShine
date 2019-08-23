using NShine.Core.Extensions;
using NUnit.Framework;
using System;
using System.Linq;

namespace NShine.Core.Tests.Extensions
{
    /// <summary>
    /// String 扩展方法单元测试。
    /// </summary>
    [TestFixture]
    public class StringExtentsionTests
    {
        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串（默认忽略前后空白字符）。
        /// </summary>
        [Test]
        public void IsEmptyTest()
        {
            string value = null;
            bool condition;

            condition = value.IsEmpty();
            Assert.IsTrue(condition);

            value = string.Empty;
            condition = value.IsEmpty();
            Assert.IsTrue(condition);

            value = " ";
            condition = value.IsEmpty();
            Assert.IsTrue(condition);

            value = " ";
            condition = value.IsEmpty(false);
            Assert.IsFalse(condition);
        }

        /// <summary>
        /// 获取字符串或默认值（默认清除前后空白字符）。
        /// </summary>
        [Test]
        public void GetOrDefaultTest()
        {
            string value = null, result;

            result = value.GetOrDefault();
            Assert.AreEqual(result, string.Empty);

            value = null;
            result = value.GetOrDefault(".Net");
            Assert.AreEqual(result, ".Net");

            value = " ";
            result = value.GetOrDefault();
            Assert.AreEqual(result, string.Empty);

            value = " ";
            result = value.GetOrDefault(false);
            Assert.AreEqual(result, " ");
        }

        /// <summary>
        /// Base64加密解密测试。
        /// </summary>
        [Test]
        public void Base64Test()
        {
            string value, encrypt, decode;

            value = "Hello .Net";
            //加密
            encrypt = value.ToBase64();
            //解密
            decode = encrypt.FromBase64();
            Assert.AreEqual(decode, value);
        }

        /// <summary>
        /// 基于数组中的字符串将字符串拆分为多个子字符串（默认移除空字符串的数组元素）。 
        /// </summary>
        [Test]
        public void SplitTest()
        {
            string value = "Hello,.Net,Java";
            string[] array;
            bool condition;

            array = value.Split(",");
            condition = array.Contains("Hello") && array.Contains(".Net") && array.Contains("Java");
            Assert.True(condition);

            value = "Hello,.Net,,Java";
            array = value.Split(",");
            condition = array.Contains("");
            Assert.False(condition);
        }
    }
}
