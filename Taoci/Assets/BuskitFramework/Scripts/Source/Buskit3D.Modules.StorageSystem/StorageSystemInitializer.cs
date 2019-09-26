/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：StorageSystemInitializer
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：存储系统初始化
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
    /// <summary>
    /// 存储系统初始化
    /// </summary>
    public class StorageSystemInitializer
    {

#if UNITY_EDITOR
        /// <summary>
        /// 创建存储子系统
        /// </summary>
        [MenuItem("GameObject/Rainier/Subsystem/StorageSystem", priority = 0)]
        public static void CreateStorageSystem()
        {
            GameObject goSystem = GameObject.Find("Subsystem");
            if (goSystem == null)
            {
                goSystem = new GameObject("Subsystem");
                goSystem.AddComponent<DondestoryOnLoad>();
            }

            GameObject goStorageSystem = GameObject.Find("Subsystem/StorageSystem");
            if (goStorageSystem == null)
            {
                goStorageSystem = new GameObject("StorageSystem");
                goStorageSystem.transform.parent = goSystem.transform;
                goStorageSystem.AddComponent<StorageSystem>();
            }
            if (goStorageSystem.GetComponent<ReplayManager>() == null)
            {
                goStorageSystem.AddComponent<ReplayManager>();
            }
            goStorageSystem.transform.position = Vector3.zero;

            if (goStorageSystem.GetComponent<StorageSystem>() == null)
            {
                goStorageSystem.AddComponent<StorageSystem>();
            }
            if (goStorageSystem.GetComponent<StorageGUIController>() == null)
            {
                goStorageSystem.AddComponent<StorageGUIController>();
            }
            if (goStorageSystem.GetComponent<MemoryPlayer>() == null)
            {
                goStorageSystem.AddComponent<MemoryPlayer>();
            }
            if (goStorageSystem.GetComponent<DynamicIds>() == null)
            {
                goStorageSystem.AddComponent<DynamicIds>();
            }
            
            Selection.activeGameObject = goStorageSystem;
        }

        /// <summary>
        /// 菜单栏创建选项
        /// </summary>
        [MenuItem("Rainier/Subsystem")]
        public static void CreatSubSystem()
        {
            CreateStorageSystem();
        }



#endif
    }
}
