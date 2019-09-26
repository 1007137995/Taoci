
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LogService
* 创建日期：2019-04-18 09:00:42
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：打印输出
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 开启打印宏的情况下，打印输出
    /// </summary>
	public class LogService  
	{

        public static void Log(object message, Object context)
        {
            Debug.Log(message, context);
        }

        public static void Log(object message)
        {
            Debug.Log(message);
        }

        public static void LogError(object message, Object context)
        {
            Debug.LogError(message, context);
        }

        public static void LogError(object message)
        {
            Debug.LogError(message);
        }
         
        public static void LogErrorFormat(string format, params object[] args)
        {
            Debug.LogErrorFormat(format, args);
        }

        public static void LogErrorFormat(Object context, string format, params object[] args)
        {
            Debug.LogErrorFormat(context, format, args);
        }

        public static void LogFormat(Object context, string format, params object[] args)
        {
            Debug.LogFormat(context, format, args);
        }

        public static void LogFormat(string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        public static void LogWarning(object message)
        {
            Debug.LogWarning(message);
        }

        public static void LogWarning(object message, Object context)
        {
            Debug.LogWarning(message, context);
        }

        public static void LogWarningFormat(string format, params object[] args)
        {
            Debug.LogWarningFormat(format, args);
        }

        public static void LogWarningFormat(Object context, string format, params object[] args)
        {
            Debug.LogWarningFormat(context, format, args);
        }
    }
}

