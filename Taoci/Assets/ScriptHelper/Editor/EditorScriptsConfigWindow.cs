/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.BusKit.Unity.ScriptHelper.Mvvm
* 类 名 称：EditorConfig
* 创建日期：2017/12/5 18:08:08
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：编辑器配置工具
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

//includes for System
using System.IO;

//includes for Unity
using UnityEditor;
using UnityEngine;

/// <summary>
/// 名称空间定义：Buskit3D.ScriptHelper.Base
/// </summary>
namespace Buskit3D.ScriptHelper
{
    /// <summary>
    /// 脚本配置窗口
    /// </summary>
    public class EditorScriptsConfigWindow : EditorWindow
    {

        /// <summary>
        /// 脚本配置菜单
        /// </summary>
        // Add a new menu item with hotkey CTRL-SHIFT-A
        [MenuItem("Rainier/ScriptsConfig &F")]
        static void ScriptsConfig()
        {
            EditorScriptsConfigWindow configWindow = new EditorScriptsConfigWindow();
            configWindow.minSize = new Vector2(600,300);
            configWindow.maxSize = new Vector2(600, 300);
            configWindow.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnGUI()
        {
            GUILayout.BeginVertical();
            GUILayout.Space(30);
            GUI.skin.label.fontSize = 15;

            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            this.titleContent = new GUIContent("脚本生成配置");

            EditorScriptsConfig.Instance.Author = EditorGUILayout.TextField("作者:", EditorScriptsConfig.Instance.Author);
            GUILayout.Space(10);
            EditorScriptsConfig.Instance.NameSpace = EditorGUILayout.TextField("名称空间:", EditorScriptsConfig.Instance.NameSpace);

            GUILayout.Space(10);
            EditorScriptsConfig.Instance.TemplatePath = EditorGUILayout.TextField("模板路径: ", EditorScriptsConfig.Instance.TemplatePath);

            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUILayout.Space(20);
            GUI.color = Color.green;

        
            if (GUILayout.Button("完成"))
            {
                if (!EditorScriptsConfig.Instance.TemplatePath.EndsWith("/"))
                    EditorScriptsConfig.Instance.TemplatePath += "/";
                EditorUtility.SetDirty(EditorScriptsConfig.Instance);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                this.Close();
                   
            }
            GUILayout.EndVertical();
        }

    }
}