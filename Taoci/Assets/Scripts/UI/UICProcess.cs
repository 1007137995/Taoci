using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UICProcess : TTUIPage
    {
        public static UICProcess Instance;

        public UICProcess() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/CProcess";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;                        
        }

        public void SetPage(int index)
        {
            this.transform.Find("Step" + index.ToString()).GetComponent<Toggle>().isOn = true;
        }
    }
}
