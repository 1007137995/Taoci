/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IWebGlWebAPIService
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：浏览器调用服务
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 浏览器调用服务
    /// </summary>
    public class WebGLWebAPIService : IWebGlWebAPIService
    {
        /// <summary>
        /// WebAPI具体实现类接口
        /// </summary>
        public IWebGlWebAPIService Wapper = null;

        /// <summary>
        /// 打印消息
        /// </summary>
        /// <param name="str"></param>
        public void PrintInfo(string str)
        {
            if (Wapper != null)
            {
                Wapper.PrintInfo(str);
            }
        }

        /// <summary>
        /// 打印错误
        /// </summary>
        /// <param name="str"></param>
        public void PrintError(string str)
        {
            if(Wapper != null)
            {
                Wapper.PrintError(str);
            }
        }

        /// <summary>
        /// 打印警告
        /// </summary>
        /// <param name="str"></param>
        public void PrintWarring(string str)
        {
            if (Wapper != null)
            {
                Wapper.PrintWarring(str);
            }
        }

        /// <summary>
        /// 将strData数据存放到window[objName]对象
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="objName"></param>
        public void SaveStringToWindowObject(string strData, string objName)
        {
            if (Wapper != null)
            {
                Wapper.SaveStringToWindowObject(strData, objName);
            }
        }

        /// <summary>
        /// 保存字符串到本地文件中
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        public void SaveStringToLocalFile(string data, string fileName)
        {
            if(Wapper != null)
            {
                Wapper.SaveStringToLocalFile(data, fileName);
            }
        }

        /// <summary>
        /// 从本地读取文件内容并传递给GameObject
        /// </summary>
        /// <param name="gameObjectName"></param>
        /// <param name="onLoadedCallback"></param>
        public void ReadFileFromLocal(string gameObjectName, string onLoadedCallback)
        {
            if (Wapper != null)
            {
                Wapper.ReadFileFromLocal(gameObjectName, onLoadedCallback);
            }
        }

        /// <summary>
        /// 初始化浏览器服务
        /// </summary>
        public void Initialize()
        {
            this.Wapper = new WebGLWebAPIServiceWapper();
            Wapper.Initialize();
            //注册服务单利
            if (InjectService.Get<IWebGlWebAPIService>() == null)
            {
                InjectService.RegisterSingleton<IWebGlWebAPIService, WebGLWebAPIService>(this);
            }
        }
    }
}
