/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：DropdownView
* 创建日期：2019-03-11 10:58:17
* 作者名称：黎特为
* CLR 版本：4.0.30319.42000
* 功能描述：Dropdown组件的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Dropdown组件的View
    /// </summary>
    public class DropdownView : ViewBehaviour<int>,IPointerClickHandler
    {
        /// <summary>
        /// Dropdown组件
        /// </summary>
        public Dropdown dropdown = null;

        /// <summary>
        /// 获取Dropdown组件并添加OnValueChanged回调函数
        /// </summary>
        public virtual void Awake()
        {
            dropdown = GetComponent<Dropdown>();
            if(dropdown != null)
            {
                dropdown.onValueChanged.AddListener(p => { ComponentCallback(p); });
            }

            if (dropdown != null)
            {
                Value = dropdown.value;
            }
        }

        /// <summary>
        /// Dropdown组件回调函数
        /// </summary>
        /// <param id="value"></param>
        public override void ComponentCallback(int value)
        {
            Value = dropdown.value;

        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param id="value"></param>
        public override void RefreshComponent(int value)
        {     
            if(this.dropdown != null)
            {
                this.dropdown.value = value;
            }
        }

        /// <summary>
        /// 鼠标点击事件触发View改变
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            this.IsViewStateChanged = true;
        }
    }
}
