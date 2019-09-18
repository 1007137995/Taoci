using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Haiyan : DeviceBase
    {
        public GameObject touliaokou;
        private string info;
        private GameObject aim;
        private Vector3 aimPos;
        bool b = true;

        private void Start()
        {
            introduction = "海盐";
            info = "用于熏窑，消耗窑内氧气使窑内气氛转换成还原气氛或中性气氛";
            aim = transform.Find("Heap/aim").gameObject;
            aimPos = aim.transform.localPosition;
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 3001001:
                    //TTUIPage.ShowPage<UIIntroduce>();
                    //UIIntroduce.Instance.ChangeInfo(introduction, info, "Meikuai");
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 3004003:
                    SetInLu();
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                default:
                    break;
            }
        }

        private void FixedUpdate()
        {
            switch (UIManager.Instance.step)
            {
                case 3002001:
                    //transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    break;
                case 3004003:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 3004004:
                    b = true;
                    break;
                default:
                    break;
            }
        }

        private void SetInLu()
        {
            transform.GetComponent<Collider>().enabled = false;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(Tieqiao.Instance.transform.DOLocalMove(new Vector3(1.884f, -0.972f, 3.392f), 0.05f).OnComplete(delegate
            {
                Tieqiao.Instance.transform.localEulerAngles = new Vector3(-45, 90, 0);
            }));
            sequence.Append(Tieqiao.Instance.transform.DOLocalMove(new Vector3(2.3079f, -1.1549f, 3.392f), 1f).OnComplete(delegate
            {
                aim.transform.SetParent(Tieqiao.Instance.transform);
            }));
            sequence.Join(Tieqiao.Instance.transform.DOLocalRotate(new Vector3(-80, 90, 0), 1f));
            sequence.Append(Tieqiao.Instance.transform.DOLocalMove(new Vector3(1.675f, -0.233f, 1.224f), 1f));
            sequence.Append(touliaokou.GetComponent<Touliaokou>().Open());
            sequence.Append(Tieqiao.Instance.transform.DOLocalMove(new Vector3(1.9924f, -0.338f, 1.224f), 1f));
            sequence.Append(Tieqiao.Instance.transform.DOLocalRotate(new Vector3(-50, 90, 0), 1f).OnComplete(delegate
            {
                aim.transform.SetParent(transform);
                aim.gameObject.SetActive(false);
                Tieqiao.Instance.transform.localPosition = Tieqiao.Instance.oldPos;
                Tieqiao.Instance.transform.localEulerAngles = Tieqiao.Instance.oldRot;
            }));
            sequence.Join(aim.transform.DOMove(new Vector3(2.549f, -0.659f, 1.224f), 1f).OnComplete(delegate 
            {
                aim.transform.localEulerAngles = new Vector3(0, 0, 0);
            }));
            sequence.Append(touliaokou.GetComponent<Touliaokou>().Close());
            sequence.OnComplete(delegate
            {
                UIManager.Instance.AddStep();
            });
        }
    }
}