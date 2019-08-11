using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Zhadao : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1003001:
                    OpenEle();
                    break;
                case 1004001:
                    CloseEle();
                    break;
                default:
                    break;
            }
        }

        private void OpenEle()
        {
            transform.DOLocalRotate(new Vector3(0, -90, -235), 1f);
            UIManager.Instance.AddStep();
        }

        private void CloseEle()
        {
            transform.DOLocalRotate(new Vector3(0, -90, -90), 1f);
            UIManager.Instance.AddStep();
        }
    }
}
