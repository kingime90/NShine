using System.ComponentModel;

namespace NShine.Core.Options
{
    /// <summary>
    /// 比较选项。
    /// </summary>
    [Description("比较选项")]
    public enum CompareOption
    {
        /// <summary>
        /// 大于和小于
        /// </summary>
        [Description("大于和小于")]
        GreaterAndLess,

        /// <summary>
        /// 大于等于和小于
        /// </summary>
        [Description("大于等于和小于")]
        GreaterEqAndLess,

        /// <summary>
        /// 大于和小于等于
        /// </summary>
        [Description("大于和小于等于")]
        GreaterAndLessEq,

        /// <summary>
        /// 大于等于和小于等于
        /// </summary>
        [Description("大于等于和小于等于")]
        GreaterEqAndLessEq,
    }
}
