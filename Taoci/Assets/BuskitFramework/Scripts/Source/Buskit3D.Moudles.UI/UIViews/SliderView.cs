/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：SliderView
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：Slider组件的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Slider组件的View
    /// </summary>
    public class SliderView : ViewBehaviour<float>, IDragHandler
    {
        /// <summary>
        /// slider组件
        /// </summary>
        public Slider slider = null;

        /// <summary>
        /// 获取Slider组件并添加OnValueChanged回调函数
        /// </summary>
        public virtual void Awake()
        {
            slider = GetComponent<Slider>();

            if (slider != null)
            {
                Value = slider.value;
            }

            if(slider != null)
            {
                slider.onValueChanged.AddListener(p => { ComponentCallback(p); });
            }

        }

        /// <summary>
        /// Slider组件回调函数
        /// </summary>
        /// <param id="value"></param>
        public override void ComponentCallback(float value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param id="value"></param>
        public override void RefreshComponent(float value)
        {
            if (this.slider != null)
            {
                this.slider.value = value;
            }
        }        

        /// <summary>
        /// 通过鼠标拖拽改变View
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            this.IsViewStateChanged = true;
        }
    }
}
