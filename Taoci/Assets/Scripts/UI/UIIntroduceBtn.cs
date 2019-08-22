using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

namespace TinyTeam.UI
{
    public class UIIntroduceBtn : TTUIPage
    {
        public UIIntroduceBtn() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/IntroduceBtn";
        }

        public override void Awake(GameObject go)
        {
            transform.Find("grid/Dianyaolu").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Dianyaolu").GetComponent<Button>()));
            transform.Find("grid/Meikuai").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Meikuai").GetComponent<Button>()));
            transform.Find("grid/Songxiang").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Songxiang").GetComponent<Button>()));
            transform.Find("grid/Matizhu").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Matizhu").GetComponent<Button>()));
            transform.Find("grid/Pengban").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Pengban").GetComponent<Button>()));
            transform.Find("grid/Peipin").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Peipin").GetComponent<Button>()));
        }

        public void ShowInfo(Button btn)
        {
            TTUIPage.ShowPage<UIIntroduce>();
            UIIntroduce.Instance.ChangeInfo(btn.transform.Find("name").GetComponent<Text>().text, btn.transform.Find("info").GetComponent<Text>().text, btn.name);
        }
    }
}