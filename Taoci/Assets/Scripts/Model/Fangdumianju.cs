using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Fangdumianju : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {                
                #region
                case 3004002:
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
                case 3004002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    break;
                #endregion
                default:
                    break;
            }
        }
    }
}