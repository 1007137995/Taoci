/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ButtonView
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：Button组件的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.Buskit3D.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Button组件的View
    /// </summary>
    public class ButtonView : ViewBehaviour<int>,IPointerClickHandler
    {
        /// <summary>
        /// Button组件
        /// </summary>     
        public Button Button = null;

        /// <summary>
        /// 获取Button组件并添加OnClick回调函数
        /// </summary>
        public virtual void Awake()
        {
            Button = GetComponent<Button>();
            if (Button != null)
            {
                Button.onClick.AddListener(() => { ComponentCallback(); });
            }    
        }

        /// <summary>
        /// Button组件回调函数
        /// </summary>
        public override void ComponentCallback()
        {
            this.Value++;            
        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param id="value"></param>
        public override void RefreshComponent(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 鼠标点击事件触发view改变
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            this.IsViewStateChanged = true;
        }
    }
}
