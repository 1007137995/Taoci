using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

namespace TaoCi
{
    public class Paiyankou : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1002001:
                    UIQuestion.Instance.OpenQue();
                    UIQuestion.Instance.GetQuestion(3);
                    transform.GetComponent<Collider>().enabled = false;
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                case 2002001:
                    UIQuestion.Instance.OpenQue();
                    UIQuestion.Instance.GetQuestion(3);
                    transform.GetComponent<Collider>().enabled = false;
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                default:
                    break;
            }
        }

        IEnumerator QuestionEnd()
        {
            yield return new WaitUntil(() => !UIQuestion.Instance.gameObject.activeSelf);
            UIManager.Instance.EndView();
        }

        public override void OnMouseOver()
        {
            base.OnMouseOver();
        }

        public override void OnMouseExit()
        {
            base.OnMouseExit();
        }
    }
}

