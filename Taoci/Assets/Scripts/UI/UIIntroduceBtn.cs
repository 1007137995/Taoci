using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using UnityEngine.SceneManagement;

namespace TinyTeam.UI
{
    public class UIIntroduceBtn : TTUIPage
    {
        public List<Button> buttons = new List<Button>();

        public UIIntroduceBtn() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/IntroduceBtn";
        }

        public override void Awake(GameObject go)
        {
            transform.Find("ShowBtn").GetComponent<Button>().onClick.AddListener(() => {
                transform.Find("grid").gameObject.SetActive(true);
                TTUIPage.ClosePage<UITip>();
                });
            buttons.Add(transform.Find("grid/Dianyaolu").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Meikuai").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Songxiang").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Muchai").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Haiyan").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Matizhu").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Pengban").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Peipin").GetComponent<Button>());
            buttons.Add(transform.Find("grid/Xiabo").GetComponent<Button>());
            transform.Find("grid/Dianyaolu").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Dianyaolu").GetComponent<Button>()));
            transform.Find("grid/Meikuai").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Meikuai").GetComponent<Button>()));
            transform.Find("grid/Songxiang").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Songxiang").GetComponent<Button>()));
            transform.Find("grid/Muchai").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Muchai").GetComponent<Button>()));
            transform.Find("grid/Haiyan").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Haiyan").GetComponent<Button>()));
            transform.Find("grid/Matizhu").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Matizhu").GetComponent<Button>()));
            transform.Find("grid/Pengban").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Pengban").GetComponent<Button>()));
            transform.Find("grid/Peipin").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Peipin").GetComponent<Button>()));
            transform.Find("grid/Xiabo").GetComponent<Button>().onClick.AddListener(() => ShowInfo(transform.Find("grid/Xiabo").GetComponent<Button>()));
            transform.Find("grid").gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().name == "CTYB")
            {
                transform.Find("grid/Muchai").gameObject.SetActive(false);
                transform.Find("grid/Muchai").GetComponent<Button>().interactable = false;
                transform.Find("grid/Haiyan").gameObject.SetActive(false);
                transform.Find("grid/Haiyan").GetComponent<Button>().interactable = false;
                transform.Find("grid/Xiabo").gameObject.SetActive(false);
                transform.Find("grid/Xiabo").GetComponent<Button>().interactable = false;
            }
            else if (SceneManager.GetActiveScene().name == "CDYB")
            {
                transform.Find("grid/Meikuai").gameObject.SetActive(false);
                transform.Find("grid/Meikuai").GetComponent<Button>().interactable = false;
                transform.Find("grid/Songxiang").gameObject.SetActive(false);
                transform.Find("grid/Songxiang").GetComponent<Button>().interactable = false;
                transform.Find("grid/Haiyan").gameObject.SetActive(false);
                transform.Find("grid/Haiyan").GetComponent<Button>().interactable = false;
                transform.Find("grid/Xiabo").gameObject.SetActive(false);
                transform.Find("grid/Xiabo").GetComponent<Button>().interactable = false;
            }
            else if (SceneManager.GetActiveScene().name == "YSYB")
            {
                transform.Find("grid/Meikuai").gameObject.SetActive(false);
                transform.Find("grid/Meikuai").GetComponent<Button>().interactable = false;
                transform.Find("grid/Songxiang").gameObject.SetActive(false);
                transform.Find("grid/Songxiang").GetComponent<Button>().interactable = false;
                transform.Find("grid/Muchai").gameObject.SetActive(false);
                transform.Find("grid/Muchai").GetComponent<Button>().interactable = false;
                transform.Find("grid/Xiabo").gameObject.SetActive(false);
                transform.Find("grid/Xiabo").GetComponent<Button>().interactable = false;
            }
            else if (SceneManager.GetActiveScene().name == "DDYB")
            {
                transform.Find("grid/Muchai").gameObject.SetActive(false);
                transform.Find("grid/Muchai").GetComponent<Button>().interactable = false;
                transform.Find("grid/Haiyan").gameObject.SetActive(false);
                transform.Find("grid/Haiyan").GetComponent<Button>().interactable = false;
            }
        }

        public void ShowInfo(Button btn)
        {
            TTUIPage.ShowPage<UIIntroduce>();
            btn.interactable = false;
            UIIntroduce.Instance.ChangeInfo(btn.transform.Find("name").GetComponent<Text>().text, btn.transform.Find("info").GetComponent<Text>().text, btn.name);
            foreach (Button item in buttons)
            {
                if (item.interactable == true)
                {
                    return;
                }
            }
            UITitle.Instance.transform.Find("StartBtn").gameObject.SetActive(true);
            btn.interactable = false;
        }
    }
}