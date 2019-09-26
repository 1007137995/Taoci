/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： WebGLInputField
* 创建日期：2019-03-18 11:29:59
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Com.Rainier.Buskit3D.UI
{
    /// <summary>
    /// 润尼尔下拉框组件
    /// </summary>
    [RequireComponent(typeof(DropDownLogic))]
    [RequireComponent(typeof(DropDownModel))]
    public class DropdownRainier : Dropdown
    {
        public bool AlwaysCallback = false;//是否开启 点击选项按钮总是回调
        /// <summary>
        /// 重写点击下拉框事件
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerClick(PointerEventData eventData)
        {
            Show();
            ((UGUIDataEntity)GetComponent<DataModelBehaviour>().DataEntity).DropDownIsShow = true;
            Transform toggleRoot = transform.Find("Dropdown List/Viewport/Content");
            Toggle[] toggleList = toggleRoot.GetComponentsInChildren<Toggle>(false);
            for (int i = 0; i < toggleList.Length; i++)
            {
                Toggle temp = toggleList[i];
                temp.onValueChanged.RemoveAllListeners();
                temp.isOn = false;
                temp.onValueChanged.AddListener(x => OnSelectItemEx(temp));
            }
        }

        /// <summary>
        /// 选择Item事件
        /// </summary>
        /// <param name="toggle"></param>
        public void OnSelectItemEx(Toggle toggle)
        {
            if (!toggle.isOn)
            {
                toggle.isOn = true;
                return;
            }

            int selectedIndex = -1;
            Transform tr = toggle.transform;
            Transform parent = tr.parent;
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i) == tr)
                {
                    selectedIndex = i - 1;
                    break;
                }
            }
            if (selectedIndex < 0)
                return;
            if (value == selectedIndex && AlwaysCallback)
                onValueChanged.Invoke(value);
            else
                value = selectedIndex;
            Hide();
            ((UGUIDataEntity)GetComponent<DataModelBehaviour>().DataEntity).DropDownIsShow = false;
            ((UGUIDataEntity)GetComponent<DropDownModel>().DataEntity).DropDownValue = value;
        }
    }
}
