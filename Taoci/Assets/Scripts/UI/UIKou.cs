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
            });
            transform.Find("Guanhuokou").GetComponent<Button>().onClick.AddListener(() => {
                UIManager.Instance.transform.Find("Cam").position = UIManager.Instance.transform.Find("Pos/Guanhuokou").position;
                UIManager.Instance.transform.Find("Cam").eulerAngles = UIManager.Instance.transform.Find("Pos/Guanhuokou").eulerAngles;
            });
            transform.Find("Touliaokou").GetComponent<Button>().onClick.AddListener(() => {
                UIManager.Instance.transform.Find("Cam").position = UIManager.Instance.transform.Find("Pos/Touliaokou").position;
                UIManager.Instance.transform.Find("Cam").eulerAngles = UIManager.Instance.transform.Find("Pos/Touliaokou").eulerAngles;
            });
        }
    }
}