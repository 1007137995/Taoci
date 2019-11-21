﻿/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：DropDownLogic
* 创建日期：2019-02-11 10:03:17
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 功能描述：重写UGUI基本组件，实现UI回放(数据模型)
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Aop;

namespace Com.Rainier.Buskit3D.UI
{
    public class DropDownLogic : LogicBehaviour
    {
        /// <summary>
        /// 逻辑处理
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(PropertyMessage evt)
        {
            if (evt.PropertyName.Equals("DropDownValue"))
            {
                GetComponent<DropdownRainier>().value = (int)evt.NewValue;
            }

            if (evt.PropertyName.Equals("DropDownIsShow"))
            {
                if ((bool)evt.NewValue)
                {
                    GetComponent<DropdownRainier>().Show();
                }
                else
                {
                    GetComponent<DropdownRainier>().Hide();
                }
            }
        }
    }
}