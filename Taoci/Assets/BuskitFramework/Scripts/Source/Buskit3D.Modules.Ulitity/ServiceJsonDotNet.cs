/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ServiceJsonDotNet
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：JsonDotNet序列化接口封装
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Newtonsoft.Json;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceJsonDotNet : IServiceSerializer
    {
        /// <summary>
        /// 序列化设置
        /// </summary>
        private JsonSerializerSettings _settings;
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ServiceJsonDotNet()
        {
            _settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                

             };

        }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="settings"></param>
        public  ServiceJsonDotNet(JsonSerializerSettings settings)
        {
            this._settings = settings;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public object DeSerializerObject(string json)
        {
           
            return JsonConvert.DeserializeObject(json, _settings);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public object DeSerializerObject(string json,System.Type type)
        {

            return JsonConvert.DeserializeObject(json, type);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T DeSerializerObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }


        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string SerializerObject(object o)
        {
#if UNITY_EDITOR &&  UNITY_STANDALONE_WIN && Local_Mode_Debug
            return JsonConvert.SerializeObject(o, Formatting.Indented, _settings);
#else 
            return JsonConvert.SerializeObject(o,  Formatting.None, _settings);
#endif

        }
        /// <summary>
        /// 初始化服务
        /// </summary>
        public void Initialize()
        {
            //注册服务单利
            if (InjectService.Get<IServiceSerializer>() == null)
            {
                InjectService.RegisterSingleton<IServiceSerializer, ServiceJsonDotNet>(this);
            }
        }

    }
}

