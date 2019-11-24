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
            if (rule == null)
            {
                return;
            }
            //
            SetRequired(rule.Required);
            RangeLength(rule.MinLength, rule.MaxLength);
        }

        /// <summary>
        /// 主体名称。
        /// </summary>
        public string Body { get; private set; }

        /// <summary>
        /// 显示名称。
        /// </summary>
        public string Display { get; private set; }

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
        /// 设置主体名称和显示名称。
        /// </summary>
        /// <param name="body">主体名称。</param>
        /// <param name="display">显示名称。</param>
        /// <returns></returns>
        public IStringValid SetBody(string body, string display = null)
        {
            Body = body;
            Display = display;
            return this;
        }

        /// <summary>
        /// 检验。
        /// </summary>
        /// <param name="value">值。</param>
        /// <returns></returns>
        public CheckResult Check(string value)
        {
            //成功
            var result = new CheckResult(this);
            var hasValue = value.IsNotEmpty();
            if (Required && !hasValue)
            {
                result.SetMessage("不能为空");
                return result;
            }
            //
            if (hasValue)
            {
                //最小字符串长度
                if (MinLength > 0 && MaxLength == 0 && MinLength > value.Length)
                {
                    result.SetMessage($"不能少于{MinLength}个字符");
                    return result;
                }
                //最大字符串长度
                if (MinLength == 0 && MaxLength > 0 && MaxLength < value.Length)
                {
                    result.SetMessage($"不能超过{MaxLength}个字符");
                    return result;
                }
                //字符串长度范围
                if (MinLength > 0 && MinLength < MaxLength &&
                    !((uint)value.Length).IsRange(MinLength, MaxLength, CompareOption.GeAndLe))
                {
                    result.SetMessage($"字符长度必须在{MinLength}到{MaxLength}之间");
                    return result;
                }
            }
            //
            return result;
        }
    }
}