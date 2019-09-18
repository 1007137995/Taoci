using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using HighlightingSystem;

namespace TaoCi {
    public class Attention : DeviceBase
    {
        public GameObject[] att;

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1001001:
                    TTUIPage.ShowPage<UIAttention>();                    
                    foreach (GameObject item in att)
                    {
                        item.GetComponent<Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ClosePage<UITip>();
                    break;
                #endregion
                #region
                case 2001001:
                    TTUIPage.ShowPage<UIAttention>();
                    foreach (GameObject item in att)
                    {
                        item.GetComponent<Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ClosePage<UITip>();
                    break;
                #endregion
                #region
                case 3001001:
                    TTUIPage.ShowPage<UIAttention>();
                    foreach (GameObject item in att)
                    {
                        item.GetComponent<Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ClosePage<UITip>();
                    break;
                #endregion
                #region
                case 4001001:
                    TTUIPage.ShowPage<UIAttention>();
                    foreach (GameObject item in att)
                    {
                        item.GetComponent<Highlighter>().tween = false;
                        item.GetComponent<Collider>().enabled = false;
                    }
                    TTUIPage.ClosePage<UITip>();
                    break;
                #endregion
                default:
                    break;
            }
        }
    }
}