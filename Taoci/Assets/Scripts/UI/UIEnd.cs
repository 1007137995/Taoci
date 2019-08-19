using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TinyTeam.UI
{
    public class UIEnd : TTUIPage
    {
        public static UIEnd Instance;

        public UIEnd() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "UIPrefab/End";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            transform.Find("Submit").GetComponent<Button>().onClick.AddListener(delegate
            {
                SceneManager.LoadScene("Main");
            });
            transform.Find("Redo").GetComponent<Button>().onClick.AddListener(delegate
            {
                SceneManager.LoadScene("CTDY");
            });
        }

        public void ShowScore()
        {
            for (int i = 0; i < ScoreInfo.scoreList.Count; i++)
            {
                transform.Find("List").GetChild(i).gameObject.SetActive(true);
                transform.Find("List").GetChild(i).transform.Find("question").GetComponent<Text>().text = ScoreInfo.scoreList[i].info;
                transform.Find("List").GetChild(i).transform.Find("score").GetComponent<Text>().text = ScoreInfo.scoreList[i].wrong.ToString();
            }
        }
    }
}