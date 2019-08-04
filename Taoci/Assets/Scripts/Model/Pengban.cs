using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;

namespace TaoCi
{
    public class Pengban : DeviceBase
    {
        public TaociLayer layer;
        private Transform handPos;
        private Transform oldPos;
        private Transform[] aimPos;
        private string info;

        private void Start()
        {
            introduction = "高温硼板";
            info = "用于承载铺设坭兴陶坯品";
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