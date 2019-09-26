/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：WebGLWebAPIServiceWapper
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：WebGL WebAIP调用接口包装类
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// WebGL WebAIP调用接口包装类
    /// </summary>
    class WebGLWebAPIServiceWapper : IWebGlWebAPIService
    {
        /// <summary>
        /// js库中的_PrintInfo函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void _PrintInfo(string str);

        /// <summary>
        /// js库中的_PrintError函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void _PrintError(string str);

        /// <summary>
        /// js库中的_PrintWarring函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void _PrintWarring(string str);

        /// <summary>
        /// js库中的_PrintWarring函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void _SaveStringToWindowObject(string strData, string objName);

        /// <summary>
        /// js库中的_PrintWarring函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void _SaveStringToLocalFile(string strData, string fileName);

        /// <summary>
        /// 从本地读取文件内容并传递给GameObject
        /// </summary>
        /// <param name="gameObjectName"></param>
        /// <param name="onLoadedCallback"></param>
        [DllImport("__Internal")]
        private static extern void _ReadFileFromLocal(string gameObjectName, string onLoadedCallback);


        /// <summary>
        /// 调用js库中的_Print函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        public void PrintInfo(string str)
        {
            try
            {
                _PrintInfo(str);
            }
            catch(EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }
        }

        /// <summary>
        /// 调用js库中的_Print函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        public void PrintError(string str)
        {
            try
            {
                _PrintError(str);
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }
        }

        /// <summary>
        /// 调用js库中的_Print函数见：Assets\Plugins\PluginRainier\WebApi.jslib
        /// </summary>
        /// <param name="str"></param>
        public void PrintWarring(string str)
        {
            try
            {
                _PrintWarring(str);
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }
        }

        /// <summary>
        /// 将strData数据存放到window[objName]对象
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="objName"></param>
        public void SaveStringToWindowObject(string strData, string objName)
        {
            try
            {
                _SaveStringToWindowObject(strData,objName);
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }
        }

        /// <summary>
        /// 保存字符串到本地文件中
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        public void SaveStringToLocalFile(string data, string fileName)
        {
            try
            {
                _SaveStringToLocalFile(data, fileName);
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }
        }

        /// <summary>
        /// 从本地读取文件内容并传递给GameObject
        /// </summary>
        /// <param name="gameObjectName"></param>
        /// <param name="onLoadedCallback"></param>
        public void ReadFileFromLocal(string gameObjectName, string onLoadedCallback)
        {
            try
            {
                _ReadFileFromLocal(gameObjectName, onLoadedCallback);
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.Log(e);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize() { }
    }
}
