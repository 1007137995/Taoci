using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTeam.UI
{
    public class UICProcess : TTUIPage
    {
        public static UICProcess Instance;

        public UICProcess() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/CProcess";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;                        
        }
    }
}
