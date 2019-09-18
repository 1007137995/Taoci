﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using DG.Tweening;

namespace TaoCi
{
    public class Matizhu : InObjectBase
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
                ChuantongStep.Instance.matizhu.Add(this.gameObject);
            }
            if (DianchaiStep.Instance != null)
            {
                DianchaiStep.Instance.matizhu.Add(this.gameObject);
            }
            if (YanshaoStep.Instance != null)
            {
                YanshaoStep.Instance.matizhu.Add(this.gameObject);
            }
            if (DingdianStep.Instance != null)
            {
                DingdianStep.Instance.matizhu.Add(this.gameObject);
            }
        }

        private void Start()
        {
            introduction = "马蹄柱";
            info = "用于支撑高温硼板，便于窑内架设更多层次";
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region 传统
                case 1001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Matizhu");
                    //foreach (GameObject item in ChuantongStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}                    
                    break;
                case 1002003:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        //Push(0);
                    }
                    break;
                case 1002005:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(1);
                    }
                    break;
                case 1002008:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(2);
                    }
                    break;
                case 1005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                case 1005008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                case 1005011:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        //Pull();
                    }
                    break;
                #endregion
                #region 电柴
                case 2001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Matizhu");
                    //foreach (GameObject item in DianchaiStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 2002003:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(0);
                    }
                    break;
                case 2002006:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(1);
                    }
                    break;
                case 2002009:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(2);
                    }
                    break;
                case 2005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                case 2005008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                case 2005011:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                #endregion
                #region 盐烧
                case 3001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Matizhu");
                    //foreach (GameObject item in ChuantongStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}                    
                    break;
                case 3002003:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        //Push(0);
                    }
                    break;
                case 3002005:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(1);
                    }
                    break;
                case 3002008:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(2);
                    }
                    break;
                case 3005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                case 3005008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                case 3005011:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        //Pull();
                    }
                    break;
                #endregion
                #region 传统
                case 4001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Matizhu");
                    //foreach (GameObject item in ChuantongStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}                    
                    break;
                case 4002004:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(1);
                    }
                    break;
                case 4002008:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Push(2);
                    }
                    break;
                case 4005006:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
                    }
                    break;
                case 4005010:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        Pull();
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
                #region 传统
                case 1002001:
                    //foreach (GameObject item in ChuantongStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 1002005:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1002008:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region 电柴
                case 2002001:
                    //foreach (GameObject item in DianchaiStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 2002003:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2002006:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2002009:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005011:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region 盐烧
                case 3002001:
                    //foreach (GameObject item in ChuantongStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 3002005:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3002008:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005005:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005008:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region 定点
                case 4002001:
                    //foreach (GameObject item in ChuantongStep.Instance.matizhu)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 4002004:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4002008:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005006:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005010:
                    if (layer == TaociLayer.Center && b == true)
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
