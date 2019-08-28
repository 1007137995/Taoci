using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UIMain : TTUIPage
    {
        public UIMain() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Main";
        }

        public override void Awake(GameObject go)
        {
            transform.Find("Chuantong").GetComponent<Button>().onClick.AddListener(() => Chuantong());
        }

        public void Chuantong()
        {
            MainScene.Instance.scene ="CTYB";
            TTUIPage.ClosePage(this);
        }
    }
}
