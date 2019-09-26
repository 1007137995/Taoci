
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
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 
    /// </summary>
	public class LabInterApiService : ILabInterApiService
    {

        public ILabInterApiService wrapper = null;


        /// <summary>
        /// 获取当前登录的用户和操作的实验信息
        /// </summary>
        public void GetLabUserInfo()
        {
            wrapper.GetLabUserInfo();
        }


        public void Initialize()
        {
            wrapper = new LabInterApiWrapper();
            wrapper.Initialize();

            //注册服务单利
            if (InjectService.Get<ILabInterApiService>() == null)
            {
                InjectService.RegisterSingleton<ILabInterApiService, LabInterApiService>(this);
            }
        }
    }
}

