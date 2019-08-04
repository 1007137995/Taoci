using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi.Chuantong
{
    public class MeiKuai : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (ChuantongStep.Instance.LocalStep)
            {
                case 1001001:

                    break;
                default:
                    break;
            }
        }
    }
}
