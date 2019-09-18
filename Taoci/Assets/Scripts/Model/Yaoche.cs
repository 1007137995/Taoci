using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Yaoche : DeviceBase
    {
        private Transform lumen;
        public bool b = true;

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
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }                    
                    break;
                case 1005012:
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }
                    break;
                #endregion
                #region
                case 2002013:
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }
                    break;
                case 2005012:
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }
                    break;
                #endregion
                #region
                case 3002012:
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }
                    break;
                case 3005012:
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }
                    break;
                #endregion
                #region
                case 4002014:
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }
                    break;
                case 4005014:
                    if (b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        lumen.GetComponent<Lumen>().CloseDoor();
                        b = false;
                    }
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
                    }
                    break;
                case 1003001:
                    b = true;
                    break;
                case 1005012:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
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
                    }
                    break;
                case 2003001:
                    b = true;
                    break;
                case 2005012:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005013:
                    b = true;
                    break;
                #endregion
                #region
                case 3002012:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3003001:
                    b = true;
                    break;
                case 3005012:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005013:
                    b = true;
                    break;
                #endregion
                #region
                case 4002014:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4003001:
                    b = true;
                    break;
                case 4005014:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005015:
                    b = true;
                    break;
                #endregion
                default:
                    break;
            }
        }
    }
}
