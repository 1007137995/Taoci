using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UIPicture : TTUIPage
    {
        public static UIPicture Instance;

        public UIPicture() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "UIPrefab/Picture";
        }

        public override void Awake(GameObject go)
        {
            transform.Find("EndBtn").GetComponent<Button>().onClick.AddListener(() => UIManager.Instance.AddStep());
        }
    }
}