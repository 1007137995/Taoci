using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Com.Rainier.ZC_Frame;

namespace TinyTeam.UI
{
    public class UIEnd : TTUIPage
    {
        public static UIEnd Instance;
        private WebCommunicationSystem webCommunicationSystem;
        private int score = 0;

        public UIEnd() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "UIPrefab/End";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            webCommunicationSystem = WebCommunicationSystem.GetInstance();
#if UNITY_STANDALONE
            webCommunicationSystem.LoginForPC("student", "rainier","test",Listen);
#endif
            transform.Find("Submit").GetComponent<Button>().onClick.AddListener(delegate
            {
                UIManager.Instance.Delay(UpLoadScore());
            });
            transform.Find("Redo").GetComponent<Button>().onClick.AddListener(delegate
            {
                SceneManager.LoadScene("Main");
            });
        }

        public void ShowScore()
        {
            for (int i = 0; i < ScoreInfo.scoreList.Count; i++)
            {
                transform.Find("List").GetChild(i).gameObject.SetActive(true);
                transform.Find("List").GetChild(i).transform.Find("question").GetComponent<Text>().text = ScoreInfo.scoreList[i].info;
                transform.Find("List").GetChild(i).transform.Find("score").GetComponent<Text>().text = ScoreInfo.scoreList[i].wrong.ToString();
                score += ScoreInfo.scoreList[i].score;
            }
        }

        /// <summary>
        /// 上传分数
        /// </summary>
        private IEnumerator UpLoadScore()
        {
            webCommunicationSystem.UpLoadScore(score.ToString(), Listen);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("Main");
        }

        /// <summary>
        /// 回调
        /// </summary>
        /// <param name="value"></param>
        private void Listen(string value)
        {
            switch (value)
            {
                case "000":
                    Debug.Log("成功");
                    //text.text = value + ": 成功";
                    break;
                case "101":
                    Debug.Log("Json数据异常");
                    //text.text = value + ": Json数据异常";
                    break;
                case "102":
                    Debug.Log("不存在此学生");
                    //text.text = value + ": 不存在此学生";
                    break;
                default:
                    break;
            }
        }
    }
}