using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UIAttention : TTUIPage
    {
        public static UIAttention Instance;

        public UIAttention() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Attention";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            transform.Find("Aim/Button").GetComponent<Button>().onClick.AddListener(() => End());
            transform.Find("Aim").gameObject.SetActive(false);
        }

        private void End()
        {
            TTUIPage.ClosePage(this);
        }
    }
}