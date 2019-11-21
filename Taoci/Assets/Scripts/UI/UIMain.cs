using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UIMain : TTUIPage
    {

        public UIMain() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Main";
        }

        public override void Awake(GameObject go)
        {
            transform.Find("Chuantong").GetComponent<Button>().onClick.AddListener(() => Chuantong());
            transform.Find("Dianchai").GetComponent<Button>().onClick.AddListener(() => Dianchai());
            transform.Find("Dingdian").GetComponent<Button>().onClick.AddListener(() => Dingdian());
            transform.Find("Yanshao").GetComponent<Button>().onClick.AddListener(() => Yanshao());
        }

        public void Chuantong()
        {
            MainScene.Instance.scene ="CTYB";
            MainScene.Instance.chuantong.SetActive(true);
            TTUIPage.ClosePage(this);
            TTUIPage.ShowPage<UISingleBtn>();
            TTUIPage.ShowPage<UITip>();
            UITip.Instance.SetTip("点击帮助按钮，查看操作说明，控制人物进入实验室。");
            UISingleBtn.Instance.transform.Find("HelpBtn").gameObject.SetActive(true);
        }

        public void Dianchai()
        {
            MainScene.Instance.scene = "CDYB";
            MainScene.Instance.dianchai.SetActive(true);
            TTUIPage.ClosePage(this);
            TTUIPage.ShowPage<UISingleBtn>();
            TTUIPage.ShowPage<UITip>();
            UITip.Instance.SetTip("点击帮助按钮，查看操作说明，控制人物进入实验室。");
            UISingleBtn.Instance.transform.Find("HelpBtn").gameObject.SetActive(true);
        }

        public void Dingdian()
        {
            MainScene.Instance.scene = "DDYB";
            MainScene.Instance.dingdian.SetActive(true);
            TTUIPage.ClosePage(this);
            TTUIPage.ShowPage<UISingleBtn>();
            TTUIPage.ShowPage<UITip>();
            UITip.Instance.SetTip("点击帮助按钮，查看操作说明，控制人物进入实验室。");
            UISingleBtn.Instance.transform.Find("HelpBtn").gameObject.SetActive(true);
        }

        public void Yanshao()
        {
            MainScene.Instance.scene = "YSYB";
            MainScene.Instance.yanshao.SetActive(true);
            TTUIPage.ClosePage(this);
            TTUIPage.ShowPage<UISingleBtn>();
            TTUIPage.ShowPage<UITip>();
            UITip.Instance.SetTip("点击帮助按钮，查看操作说明，控制人物进入实验室。");
            UISingleBtn.Instance.transform.Find("HelpBtn").gameObject.SetActive(true);
        }
    }
}
