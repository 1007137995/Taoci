/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIInterInitializer
* 创建日期：2019-01-22 9:30:17
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 功能描述：Editor添加view组件
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D
{
    public class UIEditor
    {
        [MenuItem("GameObject/Rainier/Mvvm/AddView", priority = 0)]
        public static void AddComPontr()
        {
            GameObject objParent = Selection.activeGameObject;
            if (objParent == null)
            {
                Debug.Log("父节点为空");
                return;
            }
            #region 给Button添加ButtonView            
            var objButton = objParent.transform.GetComponentsInChildren<Button>(true);
            for (int i = 0; i < objButton.Length; i++)
            {
                if (!objButton[i].gameObject.GetComponent<ButtonView>())
                {
                    objButton[i].gameObject.AddComponent<ButtonView>();
                }
            }
            #endregion

            #region 给文本添加TextView
            var objText = objParent.transform.GetComponentsInChildren<Text>(true);
            for (int i = 0; i < objText.Length; i++)
            {
                if (!objText[i].gameObject.GetComponent<TextView>())
                {
                    objText[i].gameObject.AddComponent<TextView>();
                }
            }
            #endregion

            #region 给Toogle添加ToggleView
            var objToggle = objParent.transform.GetComponentsInChildren<Toggle>(true);
            for (int i = 0; i < objToggle.Length; i++)
            {
                if (!objToggle[i].gameObject.GetComponent<ToggleView>())
                {
                    objToggle[i].gameObject.AddComponent<ToggleView>();
                }
            }
            #endregion

            #region 给Slider添加SliderView
            var objSlider = objParent.transform.GetComponentsInChildren<Slider>(true);
            for (int i = 0; i < objSlider.Length; i++)
            {
                if (!objSlider[i].gameObject.GetComponent<SliderView>())
                {
                    objSlider[i].gameObject.AddComponent<SliderView>();
                }
            }
            #endregion

            #region 给InputField添加InputFieldView
            var objInputField = objParent.transform.GetComponentsInChildren<InputField>(true);
            for (int i = 0; i < objInputField.Length; i++)
            {
                if (!objInputField[i].gameObject.GetComponent<InputFieldView>())
                {
                    objInputField[i].gameObject.AddComponent<InputFieldView>();
                }
            }
            #endregion

            #region 给Dropdown添加DropdownView
            var objDropdown = objParent.transform.GetComponentsInChildren<Dropdown>(true);
            for (int i = 0; i < objDropdown.Length; i++)
            {
                if (!objDropdown[i].gameObject.GetComponent<DropdownView>())
                {
                    objDropdown[i].gameObject.AddComponent<DropdownView>();
                }
            }
            #endregion

            #region 给Scrollbar添加ScrollbarView
            var objScrollbar = objParent.transform.GetComponentsInChildren<Scrollbar>(true);
            for (int i = 0; i < objScrollbar.Length; i++)
            {
                if (!objScrollbar[i].gameObject.GetComponent<ScrollbarView>())
                {
                    objScrollbar[i].gameObject.AddComponent<ScrollbarView>();
                }
            }
            #endregion
        }

    }
}