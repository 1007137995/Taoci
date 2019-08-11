using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UITip : TTUIPage
    {
        public static UITip Instance;
        private Text tip;

        public UITip() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Tip";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            tip = this.transform.Find("Tip").GetComponent<Text>();
        }

        public void SetTip(string tt)
        {
            tip.text = tt;
        }
    }
}