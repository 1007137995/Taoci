using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Lumen : DeviceBase
    {
        public static Lumen Instance;
        private bool upFamen = true;
        private bool bottomFamen = true;
        private Transform yaoche;

        public delegate void FamenHandler();
        public event FamenHandler FamenClose;

        private void Awake()
        {
            Instance = this;
            yaoche = transform.parent.Find("YaoChe");
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1002002:
                    OpenDoor();
                    break;
                case 1005001:
                    OpenDoor();
                    break;
                default:
                    break;
            }
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
                sequence.Append(yaoche.DOLocalMoveX(-2.9f, 1.5f));
                sequence.OnComplete(delegate
                {
                    UIManager.Instance.AddStep();
                });
            }
        }

        public void CloseDoor()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(yaoche.DOLocalMoveX(-1.039f, 1.5f));
            sequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 0), 1.5f).OnComplete(delegate { FamenClose(); }));
            sequence.OnComplete(delegate
            {
                UIManager.Instance.AddStep();
            });
        }
    }
}