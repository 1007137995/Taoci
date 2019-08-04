using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

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
                    TTUIPage.ShowPage<UITitle>();
                    break;
                case 1001002:
                    SetStep(1002001);
                    break;
                case 1002001:
                    TTUIPage.ShowPage<UICProcess>();
                    UITitle.Instance.SetPage(2);
                    UITitle.Instance.transform.Find("StartBtn").gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}