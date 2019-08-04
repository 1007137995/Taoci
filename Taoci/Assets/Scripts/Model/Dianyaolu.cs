using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;

namespace TaoCi
{
    public class Dianyaolu : DeviceBase
    {
        private string info;

        private void Start()
        {
            introduction = "电窑炉";
            info = "用于烧制坭兴陶";
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
