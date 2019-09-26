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

        private string score = "90";

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
        }

        /// <summary>
        /// 上传分数
        /// </summary>
        private void UpLoadScore() {
            webCommunicationSystem.UpLoadScore(score,Listen);
        }

        private void Listen(string value) {
            text.text = value;
        }
    }
}

