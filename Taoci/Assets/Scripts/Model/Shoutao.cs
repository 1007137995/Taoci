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
                #region
                case 1005001:
                    gameObject.SetActive(false);
                    UIManager.Instance.AddStep();
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                #endregion
                #region
                case 2005001:
                    gameObject.SetActive(false);
                    UIManager.Instance.AddStep();
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                #endregion
                #region
                case 3005001:
                    gameObject.SetActive(false);
                    UIManager.Instance.AddStep();
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                #endregion
                #region
                case 4005001:
                    gameObject.SetActive(false);
                    UIManager.Instance.AddStep();
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
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
                case 1005001:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    break;
                #endregion
                #region
                case 2005001:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    break;
                #endregion
                #region
                case 3005001:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    break;
                #endregion
                #region
                case 4005001:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    break;
                #endregion
                default:
                    break;
            }
        }
    }
}
