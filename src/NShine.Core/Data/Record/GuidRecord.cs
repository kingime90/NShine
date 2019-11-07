using NShine.Core.Utils;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 全局唯一标识字符串主键数据记录基类。
    /// </summary>
    public abstract class GuidRecord : IUsidRecord
    {
        /// <summary>
        /// 获取或设置 主键ID。
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 生成主键值。
        /// </summary>
        public virtual void GenerateKey()
        {
            Id = KeyGeneratorUtil.NewGuid();
        }

        /// <summary>
        /// 获取主键长度。
        /// </summary>
        /// <returns></returns>
        public int KeyLength()
        {
            return 32;
        }
    }
}
