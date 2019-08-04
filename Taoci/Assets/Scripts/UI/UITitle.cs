using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTeam.UI
{
    public class UITitle : TTUIPage
    {
        public UITitle() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Title";
        }

        public override void Awake(GameObject go)
        {
            base.Awake(go);
        }
    }
}