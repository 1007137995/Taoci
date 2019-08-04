using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaoCi.Chuantong;
using TinyTeam.UI;

namespace TaoCi
{
    public class Peipin : DeviceBase
    {
        public TaociLayer layer;
        private Transform handPos;
        private Transform oldPos;
        private Transform[] aimPos;
        private string info;

        private void Start()
        {
            introduction = "坭兴陶坯品";
            info = "用于烧制成坭兴陶成品";
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

        public void Put()
        {
            switch (layer)
            {
                case TaociLayer.Top:

                    break;
                case TaociLayer.Center:

                    break;
                case TaociLayer.Bottom:

                    break;
                default:
                    break;
            }
        }
    }
}
