using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;
using DG.Tweening;

namespace TaoCi
{
    public class Songxiang : DeviceBase
    {
        public GameObject touliaokou;
        private string info;
        private GameObject aim;
        private Vector3 aimPos;
        bool b = true;

        private void Awake()
        {
            introduction = "松香";
            info = "用于熏窑，消耗窑内氧气使窑内气氛转换成还原气氛或中性气氛";
            aim = transform.Find("Heap/aim").gameObject;
            aimPos = aim.transform.localPosition;
        }

        public override void OnMouseLeftClick()
        {
            switch (ChuantongStep.Instance.LocalStep)
            {
                case 1001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Songxiang");
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 1004003:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    SetInLu();                    
                    break;
                default:
                    break;
            }
        }

        private void FixedUpdate()
        {
            switch (UIManager.Instance.step)
            {
                case 1002001:
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 1004003:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1004004:
                    b = true;
                    break;
                default:
                    break;
            }
        }

        private void SetInLu()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(2.0834f, -0.7986f, 3.4497f), 0.05f).OnComplete(delegate 
            {
                Huoqian.Instance.transform.localEulerAngles = new Vector3(-30, 90, 0);
            }));
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(2.2156f, -1.3044f, 3.441f), 1f).OnComplete(delegate 
            {
                aim.transform.SetParent(Huoqian.Instance.transform);
            }));
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(1.7063f, 0.0522f, 1.2468f), 1f));
            sequence.Append(touliaokou.GetComponent<Touliaokou>().Open());
            sequence.Append(Huoqian.Instance.transform.DOLocalMove(new Vector3(1.919f, -0.2277f, 1.2468f), 1f).OnComplete(delegate 
            {
                aim.transform.SetParent(transform);
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
