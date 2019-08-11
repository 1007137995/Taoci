using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine;

namespace TaoCi
{
    public class Guanhuokou : DeviceBase
    {
        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                case 1002001:
                    UIQuestion.Instance.OpenQue();
                    UIQuestion.Instance.GetQuestion(2);
                    transform.GetComponent<Collider>().enabled = false;
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
