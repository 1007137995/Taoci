/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：DesignSystemInitializer
* 创建日期：2018/11/29  
* 作者名称：王志远
* 功能描述：设计性实验系统初始化程序
* 修改记录：
* 2018/11/29 添加备注
* 
******************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    public class DesignSystemInitializer
    {
#if UNITY_EDITOR
        /// <summary>
        /// 创建命令系统
        /// </summary>
        [MenuItem("GameObject/Rainier/Subsystem/DesignSystem", priority = 0)]
        public static void CreateDesignSystem()
        {
            GameObject goSystem = GameObject.Find("Subsystem");
            if (goSystem == null)
            {
                goSystem = new GameObject("Subsystem");
            }

            GameObject goDesignSystem = GameObject.Find("Subsystem/DesignSystem");
            if (goDesignSystem == null)
            {
                goDesignSystem = new GameObject("DesignSystem");
                goDesignSystem.transform.parent = goSystem.transform;
            }

            //创建命令子系统
            CreateCommandSystem(goDesignSystem);

            //创建器件选择子系统
            CreateSelectionSystem(goDesignSystem);

            //创建必要的服务
            CreateDesignSystemService();

            Selection.activeGameObject = goDesignSystem;
        }
#endif

#if UNITY_EDITOR
        /// <summary>
        /// 创建命令子系统
        /// </summary>
        /// <param name="goParent"></param>
        public static void CreateCommandSystem(GameObject goParent)
        {
            GameObject goCmdSystem = GameObject.Find("Subsystem/DesignSystem/CommandSystem");
            if (goCmdSystem == null)
            {
                goCmdSystem = new GameObject("CommandSystem");
                goCmdSystem.transform.parent = goParent.transform;
            }

            if (goCmdSystem.GetComponent<CommandDataModel>() == null)
            {
                goCmdSystem.AddComponent<CommandDataModel>();
            }

            if (goCmdSystem.GetComponent<CommandLogicCreatePart>() == null)
            {
                goCmdSystem.AddComponent<CommandLogicCreatePart>();
            }

            if (goCmdSystem.GetComponent<CommandLogicMovePart>() == null)
            {
                goCmdSystem.AddComponent<CommandLogicMovePart>();
            }

            if (goCmdSystem.GetComponent<CommandLogicRedoUndo>() == null)
            {
                goCmdSystem.AddComponent<CommandLogicRedoUndo>();
            }
        }
#endif

#if UNITY_EDITOR
        /// <summary>
        /// 创建器件选择模型
        /// </summary>
        public static void CreateSelectionSystem(GameObject goParent)
        {
            GameObject goSelectionSystem = GameObject.Find("Subsystem/DesignSystem/SelectionSystem");
            if (goSelectionSystem == null)
            {
                goSelectionSystem = new GameObject("SelectionSystem");
                goSelectionSystem.transform.parent = goParent.transform;
            }

            if (goSelectionSystem.GetComponent<SelectionDataModel>() == null)
            {
                goSelectionSystem.AddComponent<SelectionDataModel>();
            }
        }
#endif

#if UNITY_EDITOR
        /// <summary>
        /// 创建设计系统必要服务
        /// </summary>
        public static void CreateDesignSystemService()
        {
            if (InjectService.Get<IServiceCommand>() == null)
            {
                ServiceCommand commandService = new ServiceCommand();
                commandService.Initialize();
            }

            if (InjectService.Get<IServiceExperiment>() == null)
            {
                ServiceExperiment exprimentService = new ServiceExperiment();
                exprimentService.Initialize();
            }
        }
#endif

    }
}
