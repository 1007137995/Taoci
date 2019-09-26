/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：TextView
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：Text组件的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.Buskit3D.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Text组件的View
    /// </summary>
    //[UIComponentInit]
    public class TextView : ViewBehaviour<string>
    {
        /// <summary>
        /// Text组件
        /// </summary>
        public Text Text = null;

        /// <summary>
        /// 获取Text组件并添加OnValueChanged回调函数
        /// </summary>
        public virtual void Awake()
        {
            Text = GetComponent<Text>();
            if (Text != null)
            {
                Value = Text.text;
            }
        }

        /// <summary>
        /// Text组件回调函数
        /// </summary>
        /// <param id="value"></param>
        public override void ComponentCallback(string value)
        {
            Text.text = value;
        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param id="value"></param>
        public override void RefreshComponent(string value)
        {
            if (this.Text != null)
            {
                this.Text.text = value;
            }
        }
    }
}