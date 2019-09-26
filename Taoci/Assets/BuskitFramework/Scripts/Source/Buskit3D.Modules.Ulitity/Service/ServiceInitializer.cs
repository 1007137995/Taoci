
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ServiceIntilia
* 创建日期：2019-01-10 16:20:43
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    public class ServiceInitializer
    {
        /// <summary>
        /// 程序运行时初始化服务单利
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        public static void InitialieService()
        {
            //序列化
            if (InjectService.Get<IServiceSerializer>() == null)
            {
                ServiceJsonDotNet _serializer = new ServiceJsonDotNet();
                _serializer.Initialize();
            }
            //压缩
            if (InjectService.Get<IServiceCompress>() == null)
            {
                ServiceGzip _compress = new ServiceGzip();
                _compress.Initialize();
            }
        }
	}
}

