using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;

namespace TaoCi
{
    public class Matizhu : DeviceBase
    {
        public TaociLayer layer;
        private Transform handPos;
        private Transform oldPos;
        private Transform[] aimPos;
        private string info;

        private void Start()
        {
            introduction = "马蹄柱";
            info = "用于支撑高温硼板，便于窑内架设更多层次";
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
