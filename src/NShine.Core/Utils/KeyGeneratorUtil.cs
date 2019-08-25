using System;

namespace NShine.Core.Utils
{
    /// <summary>
    /// 主键生成器应用。
    /// </summary>
    public static class KeyGeneratorUtil
    {
        /// <summary>
        /// 生成新的16位长度唯一字符串标识。
        /// </summary>
        /// <returns></returns>
        public static string NewUsid16()
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
        /// 生成新的19位长度唯一标识。
        /// </summary>
        /// <returns></returns>
        public static long NewUsid19()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 生成新的全局唯一标识符（32位长度）。
        /// </summary>
        /// <returns></returns>
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
