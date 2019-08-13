using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;
using DG.Tweening;

namespace TaoCi
{
    public class Peipin : InObjectBase
    {
        private string info;

        private void Awake()
        {
            yaoche = transform.parent.parent.Find("DYL/YaoChe");
            oldPos = transform.parent.localPosition;
            oldRot = transform.parent.localEulerAngles;
            parentPos = transform.parent.parent;
            handPos = transform.parent.parent.Find("Hand");
            aimPos[0] = new Vector3(0.983f, -0.456f, 1.251f);
            aimPos[1] = new Vector3(0.983f, -0.1005f, 1.251f);
            aimPos[2] = new Vector3(0.983f, 0.319f, 1.251f);
        }

        private void Start()
        {
            introduction = "坭兴陶坯品";
            info = "用于烧制成坭兴陶成品";
        }

        public override void OnMouseLeftClick()
        {
            switch (ChuantongStep.Instance.LocalStep)
            {
                case 1001001:
                    TTUIPage.ShowPage<UIIntroduce>();
                    UIIntroduce.Instance.ChangeInfo(introduction, info, "Peipin");
                    break;
                case 1002005:
                    if (layer == TaociLayer.Bottom)
                    {
                        Push(0);
                    }
                    break;
                case 1002008:
                    if (layer == TaociLayer.Center)
                    {
                        Push(1);
                    }
                    break;
                case 1002011:
                    if (layer == TaociLayer.Top)
                    {
                        Push(2);
                    }
                    break;
                case 1005003:
                    if (layer == TaociLayer.Top)
                    {
                        Pull();
                    }
                    break;
                case 1005006:
                    if (layer == TaociLayer.Center)
                    {
                        Pull();
                    }
                    break;
                case 1005009:
                    if (layer == TaociLayer.Bottom)
                    {
                        Pull();
                    }
                    break;
                case 1005013:
                    TTUIPage.ShowPage<UIPicture>();
                    break;
                default:
                    break;                
            }
        }

        public void Push(int index)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.parent.DOLocalMove(handPos.localPosition, 1f));
            sequence.Join(transform.parent.DOLocalRotate(handPos.localEulerAngles, 1f));
            sequence.Append(transform.parent.DOLocalMove(aimPos[index], 1f));
            sequence.OnComplete(delegate
            {
                transform.parent.SetParent(yaoche);
            });
            UIManager.Instance.AddStep();
        }

        public void Pull()
        {
            transform.parent.SetParent(parentPos);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.parent.DOLocalMove(handPos.localPosition, 1f));
            sequence.Append(transform.parent.DOLocalMove(oldPos, 1f));
            sequence.Join(transform.parent.DOLocalRotate(oldRot, 1f));
            UIManager.Instance.AddStep();
        }
    }
}
