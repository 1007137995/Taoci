
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ExperimentWindow
* 创建日期：2019-04-17 15:48:13
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 实验信息设置窗口
    /// </summary>
	public class ExpInfoSettingsWindow:EditorWindow
    {
        private const string ExpInfoSettingsAssetFile = "ExperimentInfoSettings";
       
        private const string ExpInfoSettingsAssetPath =  "Assets/BuskitFramework/Scripts/Source/Buskit3D.Modules.StorageSystem/Resources/"+ExpInfoSettingsAssetFile+".asset";

        private  ExperimentInfoSettings ExpInfoSettings;

        private void OnEnable()
        {
            //从磁盘加载
            ExpInfoSettings =(ExperimentInfoSettings)AssetDatabase.LoadAssetAtPath(ExpInfoSettingsAssetPath, typeof(ExperimentInfoSettings));
            if(ExpInfoSettings==null)
            {
                //生成一份
                CreateExpInfoSettingsAsset();
            }
        }

        public void OnGUI()
        {

            GUILayout.Space(10);
            ExpInfoSettings.experimentName = EditorGUILayout.TextField("标准实验名称", ExpInfoSettings.experimentName);
            GUILayout.Space(10);
            ExpInfoSettings.experimentEsid = EditorGUILayout.TextField("Pc版Esid", ExpInfoSettings.experimentEsid);

            //设置Url
            GUILayout.Space(10);
            ExpInfoSettings.loginUrl = EditorGUILayout.TextField("Pc版登录Url", ExpInfoSettings.loginUrl);
            GUILayout.Space(10);
            ExpInfoSettings.uploadIgcsUrl = EditorGUILayout.TextField("智能批改数据上传Url", ExpInfoSettings.uploadIgcsUrl);
            GUILayout.Space(10);
            ExpInfoSettings.uploadReplayUrl = EditorGUILayout.TextField("实验数据上传Url", ExpInfoSettings.uploadReplayUrl);
            GUILayout.Space(10);
            ExpInfoSettings.downloadReplayUrl = EditorGUILayout.TextField("实验数据下载Url", ExpInfoSettings.downloadReplayUrl);

            if (GUILayout.Button("Down"))
            {
                EditorUtility.SetDirty(ExpInfoSettings);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                this.Close();
            }
        }

        /// <summary>
        /// 创建实验信息配置文件
        /// </summary>
        public  void CreateExpInfoSettingsAsset()
        {
            ExperimentInfoSettings instanceField = ScriptableObject.CreateInstance<ExperimentInfoSettings>();
            AssetDatabase.CreateAsset(instanceField, ExpInfoSettingsAssetPath);
            ExpInfoSettings = instanceField;

        }
    }

    /// <summary>
    /// 实验信息设置菜单选项
    /// </summary>
    public class ExpInfoSettingsInit
    {
       
        [MenuItem("Rainier/StorageSystemParams/ExpInfoSettingsWindow")]
        public static void  InitExpInfoWin()
        {
            ExpInfoSettingsWindow win = new ExpInfoSettingsWindow();
            win.name = "实验信息设置窗口";
            win.Show();
        }
    }
}

