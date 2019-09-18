using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Xiabo : InObjectBase
    {
        private string info;
        bool b = true;

        private void Awake()
        {
            yaoche = transform.parent.Find("DYL/YaoChe");
            oldPos = transform.localPosition;
            oldRot = transform.localEulerAngles;
            parentPos = transform.parent;
            handPos = transform.parent.Find("Hand");
            if (DingdianStep.Instance != null)
            {
                DingdianStep.Instance.pengban.Add(this.gameObject);
            }
        }

        private void Start()
        {
            introduction = "匣钵";
            info = "用于覆盖在坭兴陶坯品，隔绝碳元素和浓烟";
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region 定点
                case 4001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Pengban");
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 4002006:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4002010:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4002013:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4005003:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4005011:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
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
                case 4002001:
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 4002006:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4002010:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4002013:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005003:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005011:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        public void Push(int index)
        {
            b = false;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(new Vector3(0, 0.2f, -0.5f), 1f));
            sequence.Join(transform.DOLocalRotate(new Vector3(90, 0, 0), 1f));
            sequence.Append(transform.DOLocalMove(aimPos[index], 1f));
            sequence.OnComplete(delegate
            {
                transform.SetParent(yaoche);
                UIManager.Instance.AddStep();
                b = true;
            });
            
        }

        public void Pull()
        {
            b = false;
            transform.SetParent(parentPos);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(handPos.localPosition, 1f));
            sequence.Append(transform.DOLocalMove(oldPos, 1f));
            sequence.Join(transform.DOLocalRotate(oldRot, 1f));
            UIManager.Instance.AddStep();
            b = true;
        }
    }
}