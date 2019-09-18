using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using DG.Tweening;
using UnityEngine.UI;

namespace TaoCi
{
    public class Peipin : InObjectBase
    {
        private string info;
        public GameObject[] peipin;
        public Material[] newmaterial;
        public Sprite sprite;
        public bool b = true;

        private void Awake()
        {
            yaoche = transform.parent.parent.Find("DYL/YaoChe");
            oldPos = transform.parent.localPosition;
            oldRot = transform.parent.localEulerAngles;
            parentPos = transform.parent.parent;
            handPos = transform.parent.parent.Find("Hand");
            if (ChuantongStep.Instance != null)
            {
                ChuantongStep.Instance.peipin.Add(this.gameObject);
            }
            if (DianchaiStep.Instance != null)
            {
                DianchaiStep.Instance.peipin.Add(this.gameObject);
            }
            if (YanshaoStep.Instance != null)
            {
                YanshaoStep.Instance.peipin.Add(this.gameObject);
            }
            if (DingdianStep.Instance != null)
            {
                DingdianStep.Instance.peipin.Add(this.gameObject);
            }
        }

        private void Start()
        {
            introduction = "坭兴陶坯品";
            info = "用于烧制成坭兴陶成品";
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region 传统
                case 1001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Peipin");
                    //foreach (GameObject item in ChuantongStep.Instance.peipin)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 1002006:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 1002009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 1002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 1005003:
                    if (layer == TaociLayer.Top)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 1005006:
                    if (layer == TaociLayer.Center)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 1005009:
                    if (layer == TaociLayer.Bottom)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 1005013:
                    foreach (GameObject item in peipin)
                    {
                        item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ShowPage<UIPicture>();
                    UIPicture.Instance.SetImg(sprite);
                    break;
                #endregion
                #region 电柴
                case 2001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Peipin");
                    //foreach (GameObject item in DianchaiStep.Instance.peipin)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 2002007:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 2002010:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 2002012:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 2005003:
                    if (layer == TaociLayer.Top)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 2005006:
                    if (layer == TaociLayer.Center)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 2005009:
                    if (layer == TaociLayer.Bottom)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 2005013:
                    foreach (GameObject item in peipin)
                    {
                        item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ShowPage<UIPicture>();
                    UIPicture.Instance.SetImg(sprite);
                    break;
                #endregion
                #region 盐烧
                case 3001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Peipin");
                    //foreach (GameObject item in ChuantongStep.Instance.peipin)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 3002006:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 3002009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 3002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 3005003:
                    if (layer == TaociLayer.Top)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 3005006:
                    if (layer == TaociLayer.Center)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 3005009:
                    if (layer == TaociLayer.Bottom)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 3005013:
                    foreach (GameObject item in peipin)
                    {
                        item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ShowPage<UIPicture>();
                    UIPicture.Instance.SetImg(sprite);
                    break;
                #endregion
                #region 定点
                case 4001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Peipin");
                    //foreach (GameObject item in ChuantongStep.Instance.peipin)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 4002005:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        Push(0);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 4002009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        Push(1);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 4002012:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        Push(2);
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 4005004:
                    if (layer == TaociLayer.Top)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 4005008:
                    if (layer == TaociLayer.Center)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 4005012:
                    if (layer == TaociLayer.Bottom)
                    {
                        Pull();
                        foreach (GameObject item in peipin)
                        {
                            item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        }
                    }
                    break;
                case 4005015:
                    foreach (GameObject item in peipin)
                    {
                        item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ShowPage<UIPicture>();
                    UIPicture.Instance.SetImg(sprite);
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
                    //foreach (GameObject item in ChuantongStep.Instance.peipin)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 1002006:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1002009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005003:
                    if (layer == TaociLayer.Top)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005006:
                    if (layer == TaociLayer.Center)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1005009:
                    if (layer == TaociLayer.Bottom)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region 电柴
                case 2002001:
                //    foreach (GameObject item in DianchaiStep.Instance.peipin)
                //    {
                //        item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                //    }
                    break;
                case 2002007:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2002010:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2002012:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005003:
                    if (layer == TaociLayer.Top)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005006:
                    if (layer == TaociLayer.Center)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005009:
                    if (layer == TaociLayer.Bottom)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region 盐烧
                case 3002001:
                    //foreach (GameObject item in ChuantongStep.Instance.peipin)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 3002006:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3002009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3002011:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005003:
                    if (layer == TaociLayer.Top)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005006:
                    if (layer == TaociLayer.Center)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005009:
                    if (layer == TaociLayer.Bottom)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                #endregion
                #region 定点
                case 4002001:
                    //foreach (GameObject item in ChuantongStep.Instance.peipin)
                    //{
                    //    item.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    //}
                    break;
                case 4002005:
                    if (layer == TaociLayer.Bottom && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4002009:
                    if (layer == TaociLayer.Center && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4002012:
                    if (layer == TaociLayer.Top && b == true)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005004:
                    if (layer == TaociLayer.Top)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005008:
                    if (layer == TaociLayer.Center)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005012:
                    if (layer == TaociLayer.Bottom)
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
            foreach (GameObject item in peipin)
            {
                item.GetComponent<Peipin>().b = false;
            }
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.parent.DOLocalMove(handPos.localPosition, 1f));
            sequence.Join(transform.parent.DOLocalRotate(handPos.localEulerAngles, 1f));
            sequence.Append(transform.parent.DOLocalMove(aimPos[index], 1f));
            sequence.OnComplete(delegate
            {
                transform.parent.SetParent(yaoche);
                UIManager.Instance.AddStep();
                foreach (GameObject item in peipin)
                {
                    item.GetComponent<Peipin>().b = true;
                }
            });
            
        }

        public void Pull()
        {
            b = false;
            transform.parent.SetParent(parentPos);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.parent.DOLocalMove(handPos.localPosition, 1f));
            sequence.Append(transform.parent.DOLocalMove(oldPos, 1f));
            sequence.Join(transform.parent.DOLocalRotate(oldRot, 1f));
            UIManager.Instance.AddStep();
            b = true;
        }
    }
}
