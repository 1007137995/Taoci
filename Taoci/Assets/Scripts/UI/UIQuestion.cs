/************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：压疮
* 类 名 称：UIQuestion
* 创建日期：2018-08-07 09:23:58
* 作者名称：zjw
* CLR 版本：4.0.30319.42000
* 功能描述：问题面板
* 修改记录：
* 日期 描述 更新功能
*  
************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TaoCi;
using UnityStandardAssets.Characters.FirstPerson;

namespace TinyTeam.UI
{
    public class UIQuestion : TTUIPage
    {
        #region
        private Text queText;
        private GameObject shuomingText;
        //private GameObject answerimg;
        private ToggleGroup tg;
        public List<Toggle> toggle = new List<Toggle>();
        private QuestionData.Que qaq;
        private string chooce;
        private ScoreInfo scoreInfo;
        private bool isright = true;
        private bool wait = false;
        #endregion
        public static UIQuestion Instance;
        private int index = 0;

        public UIQuestion() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "UIPrefab/Question";
        }

        public override void Awake(GameObject go)
        {
            #region
            Instance = this;
            queText = transform.Find("QuestionText").GetComponent<Text>();
            shuomingText = transform.Find("Shuoming").gameObject;
            tg = transform.Find("ToggleGroup").GetComponent<ToggleGroup>();
            toggle.Clear();
            for (int i = 0; i < tg.transform.childCount; i++)
            {
                toggle.Add(tg.transform.GetChild(i).GetComponent<Toggle>());
            }
            #endregion
            this.transform.Find("ResetButton").GetComponent<Button>().onClick.AddListener(delegate
            {
                Clear();
            });

            //if (UIManager.Instance.iskaohe)
            //{
            //    this.transform.Find("SubmitBtn").GetComponent<Button>().onClick.AddListener(delegate
            //    {
            //        PlayerController.Instance.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            //        AudioManager.instance.StopAudio();
            //        ScoreInfo score = Check();
            //        TTUIPage.ClosePage(this.name);
            //        ScoreInfo.AddSocreInfo(score);
            //        Clear();
            //        this.transform.FindChild("Answer").GetComponent<Text>().text = "选项内容：";
            //        UIMgr.Instance.AddStep();
            //    });
            //}
            //else
            //{
                this.transform.Find("SubmitButton").GetComponent<Button>().onClick.AddListener(delegate
                {
                    ScoreInfo score = Check();                                      
                    if (score.result)
                    {
                        FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = true;                        
                        score.wrong = index;
                        index = 0;
                        ScoreInfo.AddSocreInfo(score);
                        Clear();
                        CloseQue();
                    }
                    else
                    {                        
                        index++;
                        Clear();
                    }
                });
            //}
        }

        public void OpenQue()
        {
            ShowPage<UIQuestion>();
            Clear();
        }

        public void CloseQue()
        {
            ClosePage<UIQuestion>();
        }

        #region
        public void GetQuestion(int index)
        {
            FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = false;
            qaq = QuestionData.QAQ[index];
            queText.text = qaq.question.ToString();
            //shuomingText.text = "";
            index = 0;
            foreach (Toggle item in toggle)
            {
                item.gameObject.SetActive(true);
                item.group = null;
                item.isOn = false;
                item.gameObject.SetActive(false);
            }
            for (int i = 0; i < qaq.toggle.Count; i++)
            {
                if (qaq.toggle[i] != "" || qaq.toggle[i] != null)
                {
                    toggle[i].gameObject.SetActive(true);
                    toggle[i].transform.Find("Label").GetComponent<Text>().text = qaq.toggle[i];
                    if (qaq.one == true)
                    {
                        toggle[i].group = tg;
                    }
                }
            }
        }

        public string Choose()
        {
            chooce = "";
            foreach (Toggle go in toggle)
            {
                if (go.isOn == true)
                {
                    chooce += go.name;
                }
            }
            return chooce;
        }

        public ScoreInfo Check()
        {
            chooce = "";
            int index = -1;
            //foreach (Toggle go in toggle)
            //{
            //    if (go.isOn == true)
            //    {
            //        chooce += go.name;
            //    }
            //}
            for (int i = 0; i < toggle.Count; i++)
            {
                if (toggle[i].isOn == true)
                {
                    chooce += toggle[i].name;
                    index = i;
                }
            }
            if (chooce.CompareTo(qaq.answer) == 0)
            {
                scoreInfo = new ScoreInfo(qaq.score, qaq.question, qaq.answer, true, 0);
                shuomingText.gameObject.SetActive(false);
            }
            else
            {
                scoreInfo = new ScoreInfo(0, qaq.question, qaq.answer, false, 0);
                shuomingText.gameObject.SetActive(true);
                shuomingText.GetComponent<Text>().text = qaq.error[index];
            }
            return scoreInfo;
        }

        public void Clear()
        {
            foreach (Toggle go in toggle)
            {
                go.isOn = false;
            }
        }
        #endregion
    }
}
