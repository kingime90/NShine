namespace NShine.Core.Data.Record
{
    /// <summary>
    /// 定义唯一字符串主键数据记录接口（New unique string id）。
    /// </summary>
    public interface IUsidRecord : IRecord<string>
    {
        /// <summary>
        /// 生成主键值。
        /// 1、如果手动生成主键，创建数据记录，将不会再次生成主键。
        /// 2、如果没有手动生成主键，创建数据记录，将会生成主键。
        /// </summary>
        void GenerateKey();

        /// <summary>
        /// 获取主键长度。
        /// </summary>
        /// <returns></returns>
        int KeyLength();
    }
}
