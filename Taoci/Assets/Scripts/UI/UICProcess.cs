using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTeam.UI
{
    public class UICProcess : TTUIPage
    {
        public UICProcess() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/CProcess";
        }

        public override void Awake(GameObject go)
        {
            base.Awake(go);
        }
    }
}
