using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UISingleBtn : TTUIPage
    {
        public static UISingleBtn Instance;

        public UISingleBtn() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/SingleBtn";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            transform.Find("PaiyankouBtn").GetComponent<Button>().onClick.AddListener(() => UIManager.Instance.AddStep());
        }
    }
}
