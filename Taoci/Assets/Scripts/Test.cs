/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： Test
* 创建日期：2019-08-07 10:26:30
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：测试上传功能
******************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using TaoCi;
using UnityEngine.SceneManagement;
using TinyTeam.UI;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class Test : MonoBehaviour 
	{
        public Button button;

        public Text text;

        public Text showText;

        private int score = 0;

        private WebCommunicationSystem webCommunicationSystem;

        private void Start()
        {
            webCommunicationSystem = WebCommunicationSystem.GetInstance();
            button.onClick.AddListener(UpLoadScore);
#if UNITY_STANDALONE
            if (LoginInformation.ExpId == string.Empty && LoginInformation.EId == string.Empty)
            {
                //整个实验中只登陆一次即可，不要重复登陆
                webCommunicationSystem.LoginForCloud(Listen);
            }
            
#endif
        }

        private void Update()
        {
            if (webCommunicationSystem.Platform == PlatformSelect.NormalPlatform)
            {
                showText.text = "role:" + LoginInformation.Role +
                            "\nnumberId:" + LoginInformation.NumberId +
                            "\nname:" + LoginInformation.Name +
                            "\neid:" + LoginInformation.EId;
            }
            else
            {
                showText.text = "ExpId:" + LoginInformation.ExpId +
                            "\nUpLoadScoreURLKey:" + LoginInformation.UpLoadScoreURLKey;

            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.F))
            {
                showText.gameObject.SetActive(true);

            }
            else
            {
                showText.gameObject.SetActive(false);
            }
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
            score = ScoreSave.AddScore(SceneManager.GetActiveScene().name, score);
            transform.Find("score").GetComponent<Text>().text = score.ToString();
        }

        /// <summary>
        /// 上传分数
        /// </summary>
        private void UpLoadScore() {
            
            webCommunicationSystem.UpLoadScore(score.ToString(),Listen);
            ScoreInfo.ClearScoreInfo();
            UISingleBtn.Instance.b = true;
        }

        private void Listen(string value) {
            Debug.Log(value);
            //text.text = value;

            SceneManager.LoadSceneAsync("Main");
        }
    }
}

