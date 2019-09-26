/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：SliderView
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：Toggle组件的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Toggle组件的View
    /// </summary>
    public class ToggleView : ViewBehaviour<bool>,IPointerClickHandler
    {
        /// <summary>
        /// Toggle组件
        /// </summary>
        public Toggle toggle = null;

        /// <summary>
        /// 获取Toggle组件并添加OnValueChanged回调函数
        /// </summary>
        public virtual void Awake()
        {
            toggle = GetComponent<Toggle>();

            if(toggle != null)
            {
                toggle.onValueChanged.AddListener(p => { ComponentCallback(p); });
                Value = toggle.isOn;
            }
        }

        /// <summary>
        /// Toggle组件回调函数
        /// </summary>
        /// <param id="value"></param>
        public override void ComponentCallback(bool value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param id="value"></param>
        public override void RefreshComponent(bool value)
        {
            if(this.toggle != null)
            {
                this.toggle.isOn = value;
            }
        }

        /// <summary>
        ///鼠标点击事件触发View改变
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            this.IsViewStateChanged = true;
        }
    }
}
