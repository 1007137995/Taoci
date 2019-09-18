using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using DG.Tweening;

namespace TaoCi
{
    public class Pengban : InObjectBase
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
            if (ChuantongStep.Instance != null)
            {
                ChuantongStep.Instance.pengban.Add(this.gameObject);
            }
            if (DianchaiStep.Instance != null)
            {
                DianchaiStep.Instance.pengban.Add(this.gameObject);
            }
            if (YanshaoStep.Instance != null)
            {
                YanshaoStep.Instance.pengban.Add(this.gameObject);
            }
            if (DingdianStep.Instance != null)
            {
                DingdianStep.Instance.pengban.Add(this.gameObject);
            }
        }

        private void Start()
        {
            introduction = "高温硼板";
            info = "用于承载铺设坭兴陶坯品";
        }

        public override void OnMouseLeftClick()
        {            
            switch (UIManager.Instance.step)
            {
                #region 传统
                case 1001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Pengban");
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 1002004:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 1002007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 1002010:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 1005004:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 1005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 1005010:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                #endregion
                #region
                case 2001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Pengban");
                    //foreach (GameObject item in DianchaiStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 2002005:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 2002008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 2002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 2005004:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 2005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 2005010:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                #endregion
                #region 盐烧
                case 3001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Pengban");
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 3002004:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 3002007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 3002010:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 3005004:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 3005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 3005010:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                #endregion
                #region 定点
                case 4001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Pengban");
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 4002003:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4002007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4005009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Pull();
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4005013:
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
                case 1002001:
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 1002004:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1002007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1002010:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005004:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005010:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region
                case 2002001:
                    //foreach (GameObject item in DianchaiStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 2002005:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2002008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005004:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005010:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region
                case 3002001:
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 3002004:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3002007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3002010:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005004:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005010:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region
                case 4002001:
                    //foreach (GameObject item in ChuantongStep.Instance.pengban)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 4002003:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4002007:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005013:
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
            sequence.Join(transform.DOLocalRotate(new Vector3(-90, 0, 0), 1f));
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