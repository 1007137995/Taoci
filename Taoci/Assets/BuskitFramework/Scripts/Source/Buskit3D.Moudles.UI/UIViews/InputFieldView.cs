/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：InputFieldView
* 创建日期：2019-03-07 10:58:17
* 作者名称：黎特为
* CLR 版本：4.0.30319.42000
* 功能描述：InputField组件的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Slider组件的View
    /// </summary>
    public class InputFieldView : ViewBehaviour<string>,IPointerClickHandler
    {
        /// <summary>
        /// slider组件
        /// </summary>
        public InputField inputField = null;

        string context;

        /// <summary>
        /// 获取InputField组件并添加OnValueChanged回调函数
        /// </summary>
        public virtual void Awake()
        {
            inputField = GetComponent<InputField>();
            if(inputField != null)
            {
                inputField.onEndEdit.AddListener(p => { ComponentCallback(p); });
            }

            if (inputField != null)
            {
                Value = inputField.text;
            }
        }

        /// <summary>
        /// InputField组件回调函数
        /// </summary>
        /// <param id="value"></param>
        public override void ComponentCallback(string text)
        {
            this.Value = text;     
            context = text;
        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param id="value"></param>
        public override void RefreshComponent(string text)
        {
            if(this.inputField != null)
            {
                this.inputField.text = text;
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
