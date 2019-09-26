using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using DG.Tweening;

namespace TaoCi
{
    public class Meikuai : DeviceBase
    {
        public GameObject touliaokou;
        private string info;
        private GameObject aim;
        private Vector3 aimPos;
        private Vector3 aimRot;
        bool b = true;

        private void Start()
        {
            introduction = "煤块";
            info = "用于熏窑，消耗窑内氧气使窑内气氛转换成还原气氛或中性气氛";
            aim = transform.Find("Heap/aim").gameObject;
            aimPos = aim.transform.localPosition;
            aimRot = aim.transform.localEulerAngles;
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Meikuai");
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 1004002:
                    SetInLu();
                    transform.Find("Arrow").gameObject.SetActive(false);
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                #endregion
                #region
                case 4001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Meikuai");
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 4004002:
                    SetInLu();
                    transform.Find("Arrow").gameObject.SetActive(false);
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
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
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 1004002:                    
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1004003:
                    b = true;
                    break;
                #endregion
                #region
                case 4002001:
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 4004002:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 4004003:
                    b = true;
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void SetInLu()
        {
            transform.GetComponent<Collider>().enabled = false;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(2.1406f, -0.7986f, 3.932f), 0.05f).OnComplete(delegate
            {
                Huoqian.Instance.transform.localEulerAngles = new Vector3(-30, 90, 0);
            }));
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(2.25f, -1.1828f, 3.9271f), 1f).OnComplete(delegate
            {
                aim.transform.SetParent(Huoqian.Instance.transform);
            }));
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(1.7063f, 0.0522f, 1.2468f), 1f));
            sequence.Append(touliaokou.GetComponent<Touliaokou>().Open());
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(1.919f, -0.2277f, 1.2468f), 1f).OnComplete(delegate
            {
                aim.transform.SetParent(transform);
                aim.transform.localPosition = aimPos;
                aim.transform.localEulerAngles = aimRot;
                aim.gameObject.SetActive(false);
                Huoqian.Instance.transform.localPosition = Huoqian.Instance.oldPos;
                Huoqian.Instance.transform.localEulerAngles = Huoqian.Instance.oldRot;
            }));
            sequence.Append(touliaokou.GetComponent<Touliaokou>().Close());
            sequence.OnComplete(delegate
            {
                UIManager.Instance.AddStep();
            });
        }
    }
}
