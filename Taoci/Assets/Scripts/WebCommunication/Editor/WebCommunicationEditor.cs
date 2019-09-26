/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： WebCommunicationEditor
* 创建日期：2019-09-23 18:59:23
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：WebCommunicationSystem的面板显示控制
******************************************************************************/

using UnityEngine;
using UnityEditor;

namespace Com.Rainier.ZC_Frame
{
    [CustomEditor(typeof(WebCommunicationSystem))]
	public class WebCommunicationEditor : Editor 
	{
        private SerializedObject webCommunication;
        private SerializedProperty platform, normalURL, simpleURL,simpleID;
        void OnEnable()
        {
            webCommunication = new SerializedObject(target);
            platform = webCommunication.FindProperty("platform");
            normalURL = webCommunication.FindProperty("normalPlatformHostURL");
            simpleURL = webCommunication.FindProperty("simplePlatformHostURL");
            simpleID = webCommunication.FindProperty("simplePlatformHostID");
        }
        public override void OnInspectorGUI()
        {
            webCommunication.Update();
            EditorGUILayout.PropertyField(platform);
            if (platform.enumValueIndex == 0)
            {
                EditorGUILayout.PropertyField(normalURL);
            }
            else if (platform.enumValueIndex == 1)
            {
                EditorGUILayout.PropertyField(simpleURL);
                EditorGUILayout.PropertyField(simpleID);
            }
            webCommunication.ApplyModifiedProperties();
        }
	}
}

