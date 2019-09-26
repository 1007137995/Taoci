/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IgcsSystem
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：智能指导脚本生成服务
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using System;
using System.Xml;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 智能指导脚本生成服务
    /// </summary>
    public class IgcsSystem : MonoBehaviour
    {
        /// <summary>
        /// XML文档对象
        /// </summary>
        public XmlDocument xmlDocument = new XmlDocument();

        /// <summary>
        /// 脚本基本信息
        /// </summary>
        public ScriptBaseInfo scriptBaseInfo = new ScriptBaseInfo();

        /// <summary>
        /// 实验信息
        /// </summary>
        public ExperimentInfo experimentInfo = new ExperimentInfo();


        /// <summary>
        /// 注册为单例
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        public static void InitializeIgcsSystem()
        {
            IgcsSystem igcs = new IgcsSystem();
            if (InjectService.Get<IgcsSystem>() == null)
            {
                InjectService.RegisterSingleton(igcs);
            }
            igcs.scriptBaseInfo.author = "北京润尼尔网络科技有限公司";
            igcs.scriptBaseInfo.copyright = "版权所有@北京润尼尔网络科技有限公司";
            igcs.scriptBaseInfo.scriptVersion = "GB-T-2090319";
            igcs.scriptBaseInfo.lastModifyTime = "";

            igcs.experimentInfo.course  = "";
            igcs.experimentInfo.name    = "";
            igcs.experimentInfo.subject = "";
            igcs.experimentInfo.uuid    = Guid.NewGuid().ToString();
        }
    }
}
