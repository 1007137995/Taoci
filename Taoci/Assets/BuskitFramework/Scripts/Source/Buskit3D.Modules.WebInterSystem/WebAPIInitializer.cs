#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    public class WebInterInitializer
    {
#if UNITY_EDITOR
        /// <summary>
        /// 创建WebInter子系统
        /// </summary>
        [MenuItem("GameObject/Rainier/Subsystem/WebInterSystem", priority = 0)]
        public static void CreateWebInterSystem()
        {
            GameObject goSystem = GameObject.Find("Subsystem");
            if (goSystem == null)
            {
                goSystem = new GameObject("Subsystem");
            }

            GameObject goBrowserSystem = GameObject.Find("Subsystem/WebInterSystem");
            if (goBrowserSystem == null)
            {
                goBrowserSystem = new GameObject("WebInterSystem");
                goBrowserSystem.transform.parent = goSystem.transform;
            }

            goBrowserSystem.transform.position = Vector3.zero;
            if (goBrowserSystem.GetComponent<WebAPIDataBehavior>() == null)
            {
                goBrowserSystem.AddComponent<WebAPIDataBehavior>();
            }

            Selection.activeGameObject = goBrowserSystem;
        }
#endif
    }
}
