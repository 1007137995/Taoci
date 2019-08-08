using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTeam.UI
{
    public class UISetValue : TTUIPage
    {
        public static UISetValue Instance;

        public UISetValue() : base(UIType.PopUp, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/SetValue";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
        }
    }
}
