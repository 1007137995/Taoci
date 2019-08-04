using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UIIntroduce : TTUIPage
    {
        public static UIIntroduce Instance;

        public UIIntroduce() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Introduce";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
        }

        public void ChangeInfo(string name, string info)
        {
            this.transform.Find("Name").GetComponent<Text>().text = name;
            this.transform.Find("Info").GetComponent<Text>().text = info;
        }
    }
}
