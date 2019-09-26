/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIInterInitializer
* 创建日期：2019-01-22 9:30:17
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 功能描述：Editor初始化
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D.UI
{
    /// <summary>
    /// 编辑器扩展
    /// </summary>
    public class UIInterInitializer
    {
#if UNITY_EDITOR
        #region MvvmEditor
        /// <summary>
        /// 创建InputField
        /// </summary>
        [MenuItem("GameObject/Rainier/Mvvm/UIComponent/InputField", priority = 0)]
        public static void CreateInputFieldMR()
        {
            var obj = AssetDatabase.LoadAssetAtPath("Assets/Artworks/Buskit3D/Prefabs/Mvvm/InputFieldMR.prefab", typeof(GameObject));
            var objPrefab = Object.Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
            objPrefab.name = "InputField";
            if (Selection.activeGameObject != null)
            {
                objPrefab.transform.SetParent(Selection.activeGameObject.transform);
            }
            else
            {
                var _canvas = GameObject.FindObjectOfType<Canvas>();
                if (_canvas)
                {
                    objPrefab.transform.SetParent(_canvas.transform);
                }
                else
                {
                    var _canvasPrefab = AssetDatabase.LoadAssetAtPath("Assets/Artworks/Buskit3D/Prefabs/Mvvm/Canvas.prefab", typeof(GameObject));
                    var canvasObj = Object.Instantiate(_canvasPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                    canvasObj.name = "Canvas";
                    objPrefab.transform.SetParent(canvasObj.transform);
                }
            }
            objPrefab.transform.localPosition = Vector3.zero;
        }
        #endregion
#endif
    }
}