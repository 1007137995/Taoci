using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Famen : DeviceBase
    {
        private Transform lumen;
        private Transform aimPos;
        private Transform oldPos;

        private void Start()
        {
            aimPos = transform.parent.Find("Pos");
            oldPos = transform;
            lumen = transform.parent.parent.Find("Lumen");            
        }

        public override void OnMouseLeftClick()
        {
            RotateDown();
        }

        public void RotateDown()
        {
            transform.GetComponent<Collider>().enabled = false;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalRotate(new Vector3(0, 450, 0), 1.5f, RotateMode.LocalAxisAdd));
            sequence.Join(transform.DOLocalMoveY(-0.06f, 1.5f));
            sequence.Append(transform.DOLocalMove(aimPos.localPosition, 2));
            sequence.Join(transform.DOLocalRotate(aimPos.localEulerAngles, 2));
            sequence.OnComplete(delegate {
                lumen.GetComponent<Lumen>().ChangeFamen(transform.name);
                transform.GetComponent<Collider>().enabled = true;
            }); 
        }

        public void RotateUp()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(oldPos.localPosition, 2));
            sequence.Join(transform.DOLocalRotate(oldPos.localEulerAngles, 2));
            sequence.Append(transform.DOLocalRotate(new Vector3(0, -450, 0), 1.5f, RotateMode.LocalAxisAdd));
            sequence.Join(transform.DOLocalMoveY(-0.056f, 1.5f));
            sequence.OnComplete(delegate {
                lumen.GetComponent<Lumen>().ChangeFamen(transform.name);
                transform.GetComponent<Collider>().enabled = true;
            });
        }
    }
}
