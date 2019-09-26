/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IWebGlWebAPIService
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：WebApi服务
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// WebApi服务
    /// </summary>
    public interface IWebGlWebAPIService : IService
    {
        /// <summary>
        /// 打印信息
        /// </summary>
        /// <param name="str"></param>
        void PrintInfo(string str);

        /// <summary>
        /// 打印错误
        /// </summary>
        /// <param name="str"></param>
        void PrintError(string str);

        /// <summary>
        /// 打印警告
        /// </summary>
        /// <param name="str"></param>
        void PrintWarring(string str);

        /// <summary>
        /// 将strData数据存放到window[objName]对象
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="objName"></param>
        void SaveStringToWindowObject(string strData, string objName);

        /// <summary>
        /// 保存字符串到本地文件中
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        void SaveStringToLocalFile(string data, string fileName);

        /// <summary>
        /// 从本地读取文件内容并传递给GameObject
        /// </summary>
        /// <param name="gameObjectName"></param>
        /// <param name="onLoadedCallback"></param>
        void ReadFileFromLocal(string gameObjectName, string onLoadedCallback);

    }
}

