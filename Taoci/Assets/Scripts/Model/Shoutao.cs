using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Shoutao : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1005001:
                    gameObject.SetActive(false);
                    UIManager.Instance.AddStep();
                    break;
                default:
                    break;
            }
        }
    }
}
