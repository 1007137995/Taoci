using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Paiyankou : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1002001:

                    break;
                default:
                    break;
            }
        }

        public override void OnMouseOver()
        {
            base.OnMouseOver();
        }

        public override void OnMouseExit()
        {
            base.OnMouseExit();
        }
    }
}

