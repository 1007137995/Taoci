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
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                default:
                    break;
            }
        }

        private void FixedUpdate()
        {
            switch (UIManager.Instance.step)
            {
                case 1005001:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    break;
                default:
                    break;
            }
        }
    }
}
