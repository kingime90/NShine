using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace NShine.Core.Extensions
{
    /// <summary>
    /// 反射扩展方法。
    /// </summary>
    public static class ReflectionExtension
    {
        #region Type

        /// <summary>
        /// 指示指定的泛型类型是否可由指定类型的实例填充。
        /// </summary>
        /// <param name="genericType">泛型类型。</param>
        /// <param name="type">指定类型。</param>
        /// <returns></returns>
        public static bool IsGenericAssignableFrom(this Type genericType, Type type)
        {
            if (!genericType.IsGenericType)
            {
                return false;
            }
            //
            var types = new List<Type> { type };
            if (genericType.IsInterface)
            {
                types.AddRange(type.GetInterfaces());
            }
            //
            Type current;
            foreach (var item in types)
            {
                current = item;
                while (current != null)
                {
                    if (current.IsGenericType)
                    {
                        current = current.GetGenericTypeDefinition();
                    }
                    //
                    if (current.IsSubclassOf(genericType) || current == genericType)
                    {
                        return true;
                    }
                    //
                    current = current.BaseType;
                }
            }
            return false;
        }

        #endregion

        #region MemberInfo

        /// <summary>
        /// 获取成员信息的描述。
        /// </summary>
        /// <param name="memberInfo">成员信息。</param>
        /// <param name="attributeType">描述特性的类型信息。</param>
        /// <returns></returns>
        public static string GetDescription(this MemberInfo memberInfo, Type attributeType = null)
        {
            if (attributeType == null)
            {
                attributeType = typeof(DescriptionAttribute);
            }
            var attribute = memberInfo.GetCustomAttribute(attributeType) as DescriptionAttribute;
            return attribute?.Description;
        }

        #endregion
    }
}
