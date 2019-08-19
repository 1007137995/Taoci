using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Yaoche : DeviceBase
    {
        private Transform lumen;
        bool b = true;

        private void Awake()
        {
            lumen = transform.parent.Find("Lumen");
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1002012:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    lumen.GetComponent<Lumen>().CloseDoor();
                    break;
                case 1005012:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    lumen.GetComponent<Lumen>().CloseDoor();
                    break;
                #endregion
                #region
                case 2002013:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    lumen.GetComponent<Lumen>().CloseDoor();
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void FixedUpdate()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1002012:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1003001:
                    b = true;
                    break;
                case 1005012:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1005013:
                    b = true;
                    break;
                #endregion
                #region
                case 2002013:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }
    }
}
