using System;

namespace NShine.Core.Utils
{
    /// <summary>
    /// 主键生成器应用。
    /// </summary>
    public static class KeyGeneratorUtil
    {
        /// <summary>
        /// 生成新的唯一字符串Id。
        /// </summary>
        /// <returns></returns>
        public static string NewUsid()
        {
            long result = 1;
            var bytes = Guid.NewGuid().ToByteArray();
            foreach (byte b in bytes)
            {
                result *= b + 1;
            }
            return string.Format("{0:x}", result - DateTime.Now.Ticks);
        }

        /// <summary>
        /// 生成新的全局唯一标识符。
        /// </summary>
        /// <returns></returns>
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString("D");
        }
    }
}
