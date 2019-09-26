
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： StorageWindow
* 创建日期：2019-03-27 14:30:24
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 设置相关属性
    /// </summary>
	public class StorageWindow : EditorWindow
    {

        private string url1 = string.Empty;
        private string url2 = string.Empty;
        private string url3 = string.Empty;

        /// <summary>
        /// 绘制窗口条目.
        /// </summary>
        private void OnGUI()
        {

            //绘制URL信息 
            url1 = EditorGUILayout.TextField("URL1", url1);
            url2 = EditorGUILayout.TextField("URL2", url2);
            url3 = EditorGUILayout.TextField("URL3", url3);
            GUILayout.Space(20);
            if (GUILayout.Button("Ok"))
            {
                Close();
            }
        }
    }

    /// <summary>
    /// 设置相关宏.
    /// </summary>
    public class DefineMenu
    {
        /// <summary>
        /// 本地存储模式
        /// </summary>
        private const string LocalReleaseMode = "Local_Mode";

        /// <summary>
        /// 本地存储带有测试文件
        /// </summary>
        private const string LocalDebugMode = "Local_Mode_Debug";

        /// <summary>
        /// 平台存储模式
        /// </summary>
        private const string LabMode = "Lab_Mode";

        /// <summary>
        /// 设置宏定义
        /// </summary>
        /// <param name="defineStr"></param>
        public static void SaveMacro(string defineStr)
        {

            string Macro = "";
            List<string> macro = GetMacro();
            if (macro.Count > 0)
            {
                if (macro.Contains(LocalDebugMode))
                {
                    macro.Remove(LocalDebugMode);
                }
                if (macro.Contains(LabMode))
                {
                    macro.Remove(LabMode);
                }
                if (macro.Contains(LocalReleaseMode))
                {
                    macro.Remove(LocalReleaseMode);
                }
            }
            macro.Add(defineStr);

            foreach (var item in macro)
            {
                Macro += string.Format("{0};", item);
            }

#if UNITY_STANDALONE
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, Macro);
#endif
#if UNITY_WEBGL
             PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL,Macro);
#endif
#if UNITY_WEBPLAYER
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebPlayer, Macro);
#endif
        }

        /// <summary>
        /// 设置宏定义
        /// </summary>
        /// <param name="defineStr"></param>
        public static void SaveMacro(string[] defineStr)
        {

            string Macro = "";
            List<string> macro = GetMacro();
            if (macro.Count > 0)
            {
                if (macro.Contains(LocalDebugMode))
                {
                    macro.Remove(LocalDebugMode);
                }
                if (macro.Contains(LabMode))
                {
                    macro.Remove(LabMode);
                }
                if (macro.Contains(LocalReleaseMode))
                {
                    macro.Remove(LocalReleaseMode);
                }
            }
            foreach (var item in defineStr)
            {
                macro.Add(item);
            }


            foreach (var item in macro)
            {
                Macro += string.Format("{0};", item);
            }
#if UNITY_STANDALONE
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, Macro);
#endif
#if UNITY_WEBGL
             PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL,Macro);
#endif
#if UNITY_WEBPLAYER
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebPlayer, Macro);
#endif
        }

        /// <summary>
        /// 获取当前宏定义
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMacro()
        {
            string macro = "";

#if UNITY_STANDALONE
            macro = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
#endif
#if UNITY_WEBGL
            macro= PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL);
#endif
#if UNITY_WEBPLAYER
             macro= PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebPlayer);
#endif
            if (string.IsNullOrEmpty(macro))
            {
                return new List<string>();
            }
            if (macro.Contains(";"))
            {
                return new List<string>(macro.Split(';'));
            }
            return new List<string>() { macro };
        }

        #region 设置存储宏定义
        [MenuItem("Rainier/StorageSystemParams/FileSaveMode/ToLocalMode")]
        public static void ToLocalModeRelease()
        {

            SaveMacro(LocalReleaseMode);
        }
        [MenuItem("Rainier/StorageSystemParams/FileSaveMode/ToLocalModeDebug")]
        public static void ToLocalModeDebug()
        {
            SaveMacro(new string[] { LocalReleaseMode, LocalDebugMode });
        }
        [MenuItem("Rainier/StorageSystemParams/FileSaveMode/ToLabMode")]
        public static void ToLabMode()
        {
            SaveMacro(LabMode);
        }
        #endregion

        /// <summary>
        /// 设置平台交互的URL
        /// </summary>
        //[MenuItem("Rainier/StorageSystemParams/StorageUrl")]
        //public static void StorageSettings()
        //{
        //    StorageWindow macroSetting = new StorageWindow();
        //    macroSetting.name = "SetStorageUrl";
        //    macroSetting.Show();
        //}
    }
}

