using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TaoCi;
using UnityEngine.SceneManagement;

namespace TinyTeam.UI
{
    public class UITitle : TTUIPage
    {
        public static UITitle Instance;

        public UITitle() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Title";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            transform.Find("StartBtn").GetComponent<Button>().onClick.AddListener(() => UIManager.Instance.AddStep());
            transform.Find("BackBtn").GetComponent<Button>().onClick.AddListener(delegate
            {
                ShaderColorController.Instance.Reset();
                ScoreInfo.ClearScoreInfo();
                UISingleBtn.Instance.b = true;
                SceneManager.LoadScene("Main");
            });
            transform.Find("HelpBtn").GetComponent<Button>().onClick.AddListener(() => transform.Find("Help").gameObject.SetActive(true));
            transform.Find("Help/Close").GetComponent<Button>().onClick.AddListener(() => transform.Find("Help").gameObject.SetActive(false));
        }

        public void SetPage(int index)
        {
            this.transform.Find("Step" + index.ToString()).GetComponent<Toggle>().isOn = true;
        }
    }
}