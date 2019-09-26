using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Rainier.Buskit3D.UI
{
    public class ToggleLogic : LogicBehaviour
    {
        /// <summary>
        /// 收到消息，处理旋转事件
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(PropertyMessage evt)
        {
            if (evt.PropertyName.Equals("ToggleIsOn"))
            {
                bool value = (bool)evt.NewValue;
                GetComponent<ToggleRanier>().isOn = value;
            }
        }
    }
}
