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
        GtAndLt,

        /// <summary>
        /// 大于等于和小于
        /// </summary>
        [Description("大于等于和小于")]
        GeAndLt,

        /// <summary>
        /// 大于和小于等于
        /// </summary>
        [Description("大于和小于等于")]
        GtAndLe,

        /// <summary>
        /// 大于等于和小于等于
        /// </summary>
        [Description("大于等于和小于等于")]
        GeAndLe,
    }
}
