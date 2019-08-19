﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class ValueControl : DeviceBase
    {
        bool b = true;

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1003002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.AddStep();
                    break;
                #endregion
                #region
                case 2003002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.AddStep();
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
                case 1003002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1003003:
                    b = true;
                    break;
                #endregion
                #region
                case 2003002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 2003003:
                    b = true;
                    break;
                #endregion
                default:
                    break;
            }
        }
    }
}
