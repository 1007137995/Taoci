using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UIKou : TTUIPage
    {
        public UIKou() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Kou";
        }

        public override void Awake(GameObject go)
        {
            transform.Find("Paiyankou").GetComponent<Button>().onClick.AddListener(()=> {
                UIManager.Instance.transform.Find("Cam").position = UIManager.Instance.transform.Find("Pos/Paiyankou").position;
                UIManager.Instance.transform.Find("Cam").eulerAngles = UIManager.Instance.transform.Find("Pos/Paiyankou").eulerAngles;
                TTUIPage.ShowPage<UITip>();
                UITip.Instance.SetTip("请点击电窑上的排烟口，进入知识点考核");
            });
            transform.Find("Guanhuokou").GetComponent<Button>().onClick.AddListener(() => {
                UIManager.Instance.transform.Find("Cam").position = UIManager.Instance.transform.Find("Pos/Guanhuokou").position;
                UIManager.Instance.transform.Find("Cam").eulerAngles = UIManager.Instance.transform.Find("Pos/Guanhuokou").eulerAngles;
                TTUIPage.ShowPage<UITip>();
                UITip.Instance.SetTip("请点击电窑上的观火口，进入知识点考核");
            });
            transform.Find("Touliaokou").GetComponent<Button>().onClick.AddListener(() => {
                UIManager.Instance.transform.Find("Cam").position = UIManager.Instance.transform.Find("Pos/Touliaokou").position;
                UIManager.Instance.transform.Find("Cam").eulerAngles = UIManager.Instance.transform.Find("Pos/Touliaokou").eulerAngles;
                TTUIPage.ShowPage<UITip>();
                UITip.Instance.SetTip("请点击电窑上的投料口，进入知识点考核");
            });
        }
    }
}