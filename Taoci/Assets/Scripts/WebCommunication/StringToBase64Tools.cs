/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： StringToBase64Tools
* 创建日期：2019-08-06 18:45:56
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：string与base64相互转化
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public static class StringToBase64Tools
	{

        /// <summary>
        /// Base64转String
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string Base64ToString(this string value)
        {
            byte[] tmpData64 = System.Convert.FromBase64String(value);
            string result = System.Text.Encoding.UTF8.GetString(tmpData64);
            return result;
        }

        /// <summary>
        /// String转Base64
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string StringToBase64(this string value)
        {
            byte[] tmpString = System.Text.Encoding.UTF8.GetBytes(value);
            string result = System.Convert.ToBase64String(tmpString);
            return result;
        }
    }
}

