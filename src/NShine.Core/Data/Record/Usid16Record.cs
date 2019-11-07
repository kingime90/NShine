using NShine.Core.Utils;

namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 16位长度唯一字符串主键数据记录基类。
    /// </summary>
    public abstract class Usid16Record : IUsidRecord
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
            Id = KeyGeneratorUtil.NewUsid16();
        }

        /// <summary>
        /// 获取主键长度。
        /// </summary>
        /// <returns></returns>
        public int KeyLength()
        {
            return 16;
        }
    }
}
