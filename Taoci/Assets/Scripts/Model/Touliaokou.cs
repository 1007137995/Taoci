using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TinyTeam.UI;

namespace TaoCi {
    public class Touliaokou : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1002001:
                    UIQuestion.Instance.OpenQue();
                    UIQuestion.Instance.GetQuestion(1);
                    transform.GetComponent<Collider>().enabled = false;
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.Delay(QuestionEnd());                    
                    break;
                case 2002001:
                    UIQuestion.Instance.OpenQue();
                    UIQuestion.Instance.GetQuestion(1);
                    transform.GetComponent<Collider>().enabled = false;
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                case 3002001:
                    UIQuestion.Instance.OpenQue();
                    UIQuestion.Instance.GetQuestion(1);
                    transform.GetComponent<Collider>().enabled = false;
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                case 4002001:
                    UIQuestion.Instance.OpenQue();
                    UIQuestion.Instance.GetQuestion(1);
                    transform.GetComponent<Collider>().enabled = false;
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                default:
                    break;
            }
        }

        public override void OnMouseOver()
        {
            base.OnMouseOver();
        }

        public override void OnMouseExit()
        {
            base.OnMouseExit();
        }

        IEnumerator QuestionEnd()
        {
            yield return new WaitUntil(() => !UIQuestion.Instance.gameObject.activeSelf);
            UIManager.Instance.EndView();
        }

        public Tween Open()
        {
            Tween tween = transform.DOLocalMoveX(-0.7f, 1);
            return tween;
        }

        public Tween Close()
        {
            Tween tween = transform.DOLocalMoveX(-0.1677637f, 1);
            return tween;
        }
    }
}