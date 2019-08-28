using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace TinyTeam.UI
{
    public class UIAttention : TTUIPage
    {
        public static UIAttention Instance;

        public UIAttention() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "UIPrefab/Attention";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            transform.Find("Aim/Button").GetComponent<Button>().onClick.AddListener(() => End());
            transform.Find("Aim").gameObject.SetActive(false);
        }

        private void End()
        {
            FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = true;
            TTUIPage.ShowPage<UIIntroduceBtn>();
            TTUIPage.ShowPage<UITip>();
            UITip.Instance.SetTip("请点击器材认知。");
            TTUIPage.ClosePage(this);
        }
    }
}