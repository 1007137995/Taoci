/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： TextRainier
* 创建日期：2019-03-19 09:31:35
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Text封装
    /// </summary>
	public class TextMvvmRainier : Text 
	{
        public Action<string> ChangValue = Test;
        public override string text 
        {
            get {
                return base.text;
            }
            set {
                if (!base.text.Equals(value))
                {
                    base.text = value;
                    ChangValue(value);
                }
            }
        }

        public static void Test(string str) {

        }
    }
}

