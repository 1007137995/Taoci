using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Famen : DeviceBase
    {
        private Transform pos;
        private Transform oldPos;

        private void Start()
        {
            pos = transform.parent.Find("Pos");
            oldPos = transform;
        }

        public override void OnMouseLeftClick()
        {
            RotateDown();
        }

        public void RotateDown()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalRotate(new Vector3(0, 450, 0), 1.5f, RotateMode.LocalAxisAdd));
            sequence.Join(transform.DOLocalMoveY(-0.06f, 1.5f));
            sequence.Append(transform.DOLocalMove(pos.localPosition, 2));
            sequence.Join(transform.DOLocalRotate(pos.localEulerAngles, 2));
        }

        public void RotateUp()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(oldPos.localPosition, 2));
            sequence.Join(transform.DOLocalRotate(oldPos.localEulerAngles, 2));
            sequence.Append(transform.DOLocalRotate(new Vector3(0, -450, 0), 1.5f, RotateMode.LocalAxisAdd));
            sequence.Join(transform.DOLocalMoveY(-0.056f, 1.5f));
        }
    }
}
