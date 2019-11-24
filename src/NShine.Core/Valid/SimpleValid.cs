using NShine.Core.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NShine.Core.Valid
{
    /// <summary>
    /// 简单对象合法性校验。
    /// </summary>
    /// <typeparam name="T">要校验的简单对象的类型。</typeparam>
    public class SimpleValid<T> : ISimpleValid<T> where T : class
    {
        /// <summary>
        /// 属性合法性校验集合。
        /// </summary>
        protected IDictionary<PropertyInfo, Tuple<ValidOption, IValid>> PropertyValidSet { get; }

        /// <summary>
        /// 初始化一个<see cref="SimpleValid{T}"/>类型的新实例。
        /// </summary>
        public SimpleValid()
        {
            PropertyValidSet = new Dictionary<PropertyInfo, Tuple<ValidOption, IValid>>();
        }

        /// <summary>
        /// 字符串类型校验。
        /// </summary>
        /// <param name="propertySelector">选择字符串类型属性函数。</param>
        /// <returns></returns>
        public IStringValid StringType(Expression<Func<T, string>> propertySelector)
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var stringValid = new StringValid();
            AddPropertyValid(propertyInfo, ValidOption.IStringValid, stringValid);
            return stringValid;
        }

        /// <summary>
        /// 添加属性合法性校验。
        /// </summary>
        /// <param name="propertyInfo">属性信息。</param>
        /// <param name="validOption">合法性校验选项。</param>
        /// <param name="valid">合法性校验接口实例。</param>
        protected void AddPropertyValid(PropertyInfo propertyInfo, ValidOption validOption, IValid valid)
        {
            PropertyValidSet.Add(propertyInfo, new Tuple<ValidOption, IValid>(validOption, valid));
        }

        /// <summary>
        /// 检验。
        /// </summary>
        /// <param name="obj">要检验对象的实例。</param>
        /// <returns></returns>
        public CheckResult Check(T obj)
        {
            CheckResult checkResult = null;
            foreach (var propertyValid in PropertyValidSet)
            {
                switch (propertyValid.Value.Item1)
                {
                    case ValidOption.IStringValid:
                        checkResult = (propertyValid.Value.Item2 as IStringValid).Check(propertyValid.Key.GetValue(obj) as string);
                        break;
                    default:
                        break;
                }
                //
                if (!checkResult.Success)
                {
                    break;
                }
            }
            //
            return checkResult ?? new CheckResult();
        }
    }
}
