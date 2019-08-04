using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Lumen : DeviceBase
    {
        private bool upFamen = true;
        private bool bottomFamen = true;

        public override void OnMouseLeftClick()
        {
            base.OnMouseLeftClick();
        }

        public void ChangeFamen(string name)
        {
            if (name.Equals("UpFamen"))
            {
                upFamen = !upFamen;
            }
            else if (name.Equals("DownFamen"))
            {
                bottomFamen = !bottomFamen;
            }
        }

        private void OpenDoor()
        {
            if (upFamen == false && bottomFamen == false)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOLocalRotate(new Vector3(0, 0, -135), 1.5f));
            }
        }
    }
}