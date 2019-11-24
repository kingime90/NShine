using NShine.Core.Extensions;
using NShine.Core.Options;
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
            SetRequired(rule.Required);
        }

        /// <summary>
        /// 设置必须。 
        /// </summary>
        /// <param name="required">是否必须。</param>
        /// <returns></returns>
        public IStringValid SetRequired(bool required = true)
        {
            Required = required;
            return this;
        }

        /// <summary>
        /// 设置最小长度。 
        /// </summary>
        /// <param name="minLength">最小长度。</param>
        /// <returns></returns>
        public IStringValid SetMinLength(uint minLength)
        {
            MinLength = minLength;
            return this;
        }

        /// <summary>
        /// 设置最大长度。 
        /// </summary>
        /// <param name="maxLength">最大长度。</param>
        /// <returns></returns>
        public IStringValid SetMaxLength(uint maxLength)
        {
            MaxLength = maxLength;
            return this;
        }

        /// <summary>
        /// 设置长度范围。 
        /// </summary>
        /// <param name="minLength">最小长度。</param>
        /// <param name="maxLength">最大长度。</param>
        /// <returns></returns>
        public IStringValid RangeLength(uint minLength, uint maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            return this;
        }

        /// <summary>
        /// 检验。
        /// </summary>
        /// <param name="value">值。</param>
        /// <returns></returns>
        public CheckResult Check(string value)
        {
            var hasValue = value.IsNotEmpty();
            if (Required && !hasValue)
            {
                return new CheckResult("不能为空");
            }
            //
            if (hasValue)
            {
                //最小字符串长度
                if (MinLength > 0 && MaxLength == 0 && MinLength > value.Length)
                {
                    return new CheckResult($"不能少于{MinLength}个字符");
                }
                //最大字符串长度
                if (MinLength == 0 && MaxLength > 0 && MaxLength < value.Length)
                {
                    return new CheckResult($"不能超过{MaxLength}个字符");
                }
                //字符串长度范围
                if (MinLength > 0 && MinLength < MaxLength &&
                    !((uint)value.Length).IsRange(MinLength, MaxLength, CompareOption.GeAndLe))
                {
                    return new CheckResult($"字符长度必须在{MinLength}到{MaxLength}之间");
                }
            }
            return new CheckResult();
        }
    }
}