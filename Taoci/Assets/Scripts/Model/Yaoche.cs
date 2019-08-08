using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Yaoche : DeviceBase
    {
        private Transform lumen;

        private void Awake()
        {
            lumen = transform.parent.Find("Lumen");
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1002012:
                    lumen.GetComponent<Lumen>().CloseDoor();
                    break;
                case 1005011:
                    lumen.GetComponent<Lumen>().CloseDoor();
                    break;
                default:
                    break;
            }
        }
    }
}
