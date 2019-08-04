using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;

namespace TaoCi
{
    public class Songxiang : DeviceBase
    {
        private string info;

        private void Awake()
        {
            introduction = "松香";
            info = "用于熏窑，消耗窑内氧气使窑内气氛转换成还原气氛或中性气氛";
        }

        public override void OnMouseLeftClick()
        {
            switch (ChuantongStep.Instance.LocalStep)
            {
                case 1001001:
                    TTUIPage.ShowPage<UIIntroduce>();
                    UIIntroduce.Instance.ChangeInfo(introduction, info);
                    break;
                default:
                    break;
            }
        }
    }
}
