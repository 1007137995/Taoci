/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：WorkflowSystemInitializer
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：工作流控制子系统初始化
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    public class WorkflowSystemInitializer
    {
#if UNITY_EDITOR
        /// <summary>
        /// 创建器件选择模型
        /// </summary>
        [MenuItem("GameObject/Rainier/Subsystem/WorkflowSystem", priority = 0)]
        public static void CreateWorkflowSystem()
        {
            GameObject goSystem = GameObject.Find("Subsystem");
            if (goSystem == null)
            {
                goSystem = new GameObject("Subsystem");
            }

            GameObject goWorkflowSystem = GameObject.Find("Subsystem/WorkflowSystem");
            if (goWorkflowSystem == null)
            {
                goWorkflowSystem = new GameObject("WorkflowSystem");
                goWorkflowSystem.transform.parent = goSystem.transform;
            }

            if (goWorkflowSystem.GetComponent<WorkflowDataModel>() == null)
            {
                goWorkflowSystem.AddComponent<WorkflowDataModel>();
            }

            Selection.activeGameObject = goWorkflowSystem;
        }
#endif
    }
}
