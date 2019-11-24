using NShine.Core.Extensions;
using NShine.Core.Valid.Rules;

namespace NShine.Core.Valid
{
    /// <summary>
    /// 字符串合法性校验。
    /// </summary>
    public class StringValid : StringRule, IStringValid
    {
        /// <summary>
        /// 初始化一个<see cref="StringValid"/>类型的新实例。
        /// </summary>
        public StringValid()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="StringValid"/>类型的新实例。
        /// </summary>
        /// <param name="rule"></param>
        public StringValid(StringRule rule)
        {
            Required(rule.IsRequired);
        }

        /// <summary>
        /// 设置必须。 
        /// </summary>
        /// <param name="isRequired">是否必须。</param>
        /// <returns></returns>
        public IStringValid Required(bool isRequired = true)
        {
            IsRequired = isRequired;
            return this;
        }

        /// <summary>
        /// 检验。
        /// </summary>
        /// <param name="value">值。</param>
        /// <returns></returns>
        public CheckResult Check(string value)
        {
            CheckResult checkResult = null;
            if (IsRequired)
            {
                if (value.IsEmpty())
                {
                    checkResult = new CheckResult("不能为空");
                }
            }
            return checkResult ?? new CheckResult();
        }
    }
}
