
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ObjectIdentityEditor
* 创建日期：2019-03-20 13:40:55
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 自定义属性绘制
    /// </summary>
    [CustomPropertyDrawer(typeof(ObjectIdentity))]
	public class ObjectIdentityEditor : PropertyDrawer
	{

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
          
            EditorGUI.BeginProperty(position, label, property);
            {
               
                GUI.Box(position, string.Empty, EditorStyles.helpBox);

               
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("UniqueID"));

                GUI.enabled = false;
                EditorGUI.PropertyField(position, property.FindPropertyRelative("id"), GUIContent.none);
                GUI.enabled = true;
            }
            EditorGUI.EndProperty();
        }
    }
}

