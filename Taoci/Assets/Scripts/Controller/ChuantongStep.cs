using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi.Chuantong
{
    public class ChuantongStep : StepManager
    {
        public static ChuantongStep Instance;

        private void Awake()
        {
            Instance = this;
            LocalStepChange += new EventHandler(DoThings);
            setStep = 1001000;
            LocalStep = setStep;
            gameObject.AddComponent<UIManager>();
            UIManager.Instance.GetStepManager(this);
        }

        public override void DoThings(object sender, EventArgs e)
        {
            switch (LocalStep)
            {
                case 1001001:
                    break;
                default:
                    break;
            }
        }
    }
}