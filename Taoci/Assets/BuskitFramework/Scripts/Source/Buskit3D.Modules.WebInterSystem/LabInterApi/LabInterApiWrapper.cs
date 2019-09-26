
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LabInterApiService
* 创建日期：2019-04-16 09:22:40
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 
    /// </summary>
	public class LabInterApiWrapper : ILabInterApiService
    {

        /// <summary>
        /// js库中的GetUserInfo函数见：Assets\Plugins\PluginRainier\LanInterApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void _GetUserInfo();

        /// <summary>
        /// 调用js库函数获取当前登录用户信息
        /// </summary>
        public void GetLabUserInfo()
        {
            try
            {
                _GetUserInfo();
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }
          
        }

        public void Initialize()
        {

        }
    }
}

