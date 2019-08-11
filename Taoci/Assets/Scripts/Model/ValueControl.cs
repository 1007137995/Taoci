using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class ValueControl : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1003002:
                    UIManager.Instance.AddStep();
                    break;
                default:
                    break;
            }
        }
    }
}
