using NShine.Core.Data.Record;

namespace NShine.Core.Tests.Data.Records
{
    /// <summary>
    /// 用户记录。
    /// </summary>
    public class UserRecord : EditableUsid16Record
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string Nickname { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public virtual string Mobile { get; set; }
    }
}
