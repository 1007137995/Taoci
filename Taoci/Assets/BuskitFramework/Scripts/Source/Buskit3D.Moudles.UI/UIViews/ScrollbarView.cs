/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ScrollbarView
* 创建日期：2019-03-11 10:58:17
* 作者名称：黎特为
* CLR 版本：4.0.30319.42000
* 功能描述：Scrollbar组件的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Dropdown组件的View
    /// </summary>
    public class ScrollbarView : ViewBehaviour<float>, IDragHandler
    {
        /// <summary>
        /// Scrollbar组件
        /// </summary>
        public Scrollbar scrollbar = null;

        /// <summary>
        /// 获取Scrollbar组件并添加OnValueChanged回调函数
        /// </summary>
        public virtual void Awake()
        {            
            scrollbar = GetComponent<Scrollbar>();
            if (scrollbar != null)
            {
                Value = scrollbar.value;
            }
            if(scrollbar != null)
            {
                scrollbar.onValueChanged.AddListener(p => { ComponentCallback(p); });
            }
        }

        /// <summary>
        /// Scrollbar组件回调函数
        /// </summary>
        /// <param id="value"></param>
        public override void ComponentCallback(float value)
        {            
            this.Value = value;
            this.IsViewStateChanged = true;
        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param id="value"></param>
        public override void RefreshComponent(float value)
        {
            if(this.scrollbar != null)
            {
                this.scrollbar.value = value;
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
