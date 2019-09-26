/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： RainierMenu
* 创建日期：2019-04-29 15:51:39
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public static class UnityBuskitExtension
{
#if NET_2_0_SUBSET || NET_2_0 || UNITY_5

    /// <summary>
	/// 增广利用泛型获取特性，针对类
	/// </summary>
    public static T GetCustomAttribute<T>(this Type type)
    {
        object[] a = type.GetCustomAttributes(true);
        //if (a != null && a.Length > 0)
        //{
        //    return (T)a[0];
        //}
      for (int i = 0; i < a.Length; i++)
        {
            if (a is T)
            {
                return (T)a[i];
            }
        }

        return default(T);
    }

    /// <summary>
	/// 增广利用泛型获取特性，针对成员
	/// </summary>
    public static T GetCustomAttribute<T>(this MemberInfo type)
    {
        object[] a = type.GetCustomAttributes(true);
        if (a != null && a.Length > 0)
        {
            for (int i = 0; i < a.Length; i++)
            {
                //Debug.Log(i.ToString()+".."+ a[i].GetType());
                if (a[i] is T)
                {
                    return (T)a[i];
                }
            }

        }

        return default(T);
    }

    /// <summary>
	/// 增广利用泛型获取Generic参数类型
	/// </summary>
    public static Type[] GenericTypeArguments(this Type type)
    {
        return type.GetGenericArguments();
    }
    
	/// <summary>
	/// 增广属性的GetValue
	/// </summary>
    public static object GetValue(this PropertyInfo pinfo, object obj)
    {
        return pinfo.GetValue(obj, null);
    }

    /// <summary>
	/// 增广属性的SetValue
	/// </summary>
    public static void SetValue(this PropertyInfo pinfo, object obj,object value)
    {
        pinfo.SetValue(obj, value, null);
    }
#endif
}
