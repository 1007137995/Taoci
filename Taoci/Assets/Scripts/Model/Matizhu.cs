﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;
using DG.Tweening;

namespace TaoCi
{
    public class Matizhu : InObjectBase
    {
        private string info;

        private void Awake()
        {
            yaoche = transform.parent.Find("DYL/YaoChe");
            oldPos = transform.localPosition;
            oldRot = transform.localEulerAngles;
            parentPos = transform.parent;
            handPos = transform.parent.Find("Hand");
            aimPos[0] = new Vector3(0.983f, 0.138f, 1.251f);
            aimPos[1] = new Vector3(0.983f, 0.138f, 1.251f);
            aimPos[2] = new Vector3(0.983f, 0.138f, 1.251f);
        }

        private void Start()
        {
            introduction = "马蹄柱";
            info = "用于支撑高温硼板，便于窑内架设更多层次";
        }

        public override void OnMouseLeftClick()
        {
            switch (ChuantongStep.Instance.LocalStep)
            {
                case 1001001:
                    TTUIPage.ShowPage<UIIntroduce>();
                    UIIntroduce.Instance.ChangeInfo(introduction, info);
                    break;
                case 1002003:
                    if (layer == TaociLayer.Bottom)
                    {
                        Push(0);
                    }
                    break;
                case 1002006:
                    if (layer == TaociLayer.Center)
                    {
                        Push(1);
                    }
                    break;
                case 1002009:
                    if (layer == TaociLayer.Top)
                    {
                        Push(2);
                    }
                    break;
                case 1005005:
                    if (layer == TaociLayer.Top)
                    {
                        Pull();
                    }
                    break;
                case 1005008:
                    if (layer == TaociLayer.Center)
                    {
                        Pull();
                    }
                    break;
                case 1005011:
                    if (layer == TaociLayer.Bottom)
                    {
                        Pull();
                    }
                    break;
                default:
                    break;
            }
        }

        public void Push(int index)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(new Vector3(0, 0.2f, -0.5f), 1f));
            sequence.Join(transform.DOLocalRotate(new Vector3(-90, 0, 0), 1f));
            sequence.Append(transform.DOLocalMove(aimPos[index], 1f));
            sequence.OnComplete(delegate
            {
                transform.SetParent(yaoche);                
            });
            UIManager.Instance.AddStep();
        }

        public void Pull()
        {
            transform.SetParent(parentPos);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(handPos.localPosition, 1f));
            sequence.Append(transform.DOLocalMove(oldPos, 1f));
            sequence.Join(transform.DOLocalRotate(oldRot, 1f));
            UIManager.Instance.AddStep();
        }
    }
}
