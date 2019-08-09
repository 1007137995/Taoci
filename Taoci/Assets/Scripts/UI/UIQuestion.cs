///************************************************************
//* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
//* 版本声明：v1.0.0
//* 项目名称：压疮
//* 类 名 称：UIQuestion
//* 创建日期：2018-08-07 09:23:58
//* 作者名称：zjw
//* CLR 版本：4.0.30319.42000
//* 功能描述：问题面板
//* 修改记录：
//* 日期 描述 更新功能
//*  
//************************************************************/
//using UnityEngine;
//using System.Collections;
//using Program;
//using UnityEngine.UI;
//using System.Collections.Generic;
//using TaoCi;

//namespace TinyTeam.UI
//{
//    public class UIQuestion : TTUIPage
//    {
//        #region
//        private Text queText;
//        private Text shuomingText;
//        private GameObject answerimg;
//        private ToggleGroup tg;
//        public List<Toggle> toggle = new List<Toggle>();
//        private QuestionData.Que qaq;
//        private string chooce;
//        private ScoreInfo scoreInfo;
//        private bool isright = true;
//        private bool wait = false;
//        #endregion
//        //private static QuestionController qc;
//        public static UIQuestion Instance;
//        private int index = 0;

//        public UIQuestion() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
//        {
//            uiPath = "ZJW/UIPrefab/Question";
//        }

//        public override void Awake(GameObject go)
//        {
//            #region
//            Instance = this;
//            queText = transform.Find("QuestionText").GetComponent<Text>();
//            shuomingText = transform.Find("AnswerImage/Scroll View/Viewport/Content/ShuomingText").GetComponent<Text>();
//            tg = transform.Find("ToggleGroup").GetComponent<ToggleGroup>();
//            toggle.Clear();
//            for (int i = 0; i < tg.transform.childCount; i++)
//            {
//                toggle.Add(tg.transform.GetChild(i).GetComponent<Toggle>());
//            }
//            #endregion
//            //Debug.Log("question");
//            //qc = this.gameObject.AddComponent<QuestionController>();
//            this.transform.Find("ResetBtn").GetComponent<Button>().onClick.AddListener(delegate
//            {
//                //qc.Clear();
//                Clear();
//                this.transform.Find("Answer").GetComponent<Text>().text = "选项内容：";
//            });

//            if (UIManager.Instance.iskaohe)
//            {
//                this.transform.Find("SubmitBtn").GetComponent<Button>().onClick.AddListener(delegate
//                {
//                    PlayerController.Instance.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
//                    AudioManager.instance.StopAudio();
//                    ScoreInfo score = Check();
//                    TTUIPage.ClosePage(this.name);
//                    ScoreInfo.AddSocreInfo(score);
//                    Clear();
//                    this.transform.FindChild("Answer").GetComponent<Text>().text = "选项内容：";
//                    UIMgr.Instance.AddStep();
//                });
//            }
//            else
//            {
//                this.transform.FindChild("SubmitBtn").GetComponent<Button>().onClick.AddListener(delegate
//                {
//                    ScoreInfo score = Check();
//                    Clear();
//                    if (score.info == "")
//                    {
//                        if (score.result)
//                        {
//                            TTUIPage.ShowPage<UITunbuCheck>();
//                            UITunbuCheck.Instacne.transform.FindChild("CheckBtn").gameObject.SetActive(false);
//                            UITunbuCheck.Instacne.SetPic(Resources.Load<Sprite>("ZJW/Texture/good"));
//                            if (wait == false)
//                            {
//                                UIMgr.Instance.Continue(Wait(qaq.raudio));
//                            }
//                        }
//                        else
//                        {
//                            TTUIPage.ShowPage<UITunbuCheck>();
//                            UITunbuCheck.Instacne.transform.FindChild("CheckBtn").gameObject.SetActive(false);
//                            UITunbuCheck.Instacne.SetPic(Resources.Load<Sprite>("ZJW/Texture/bad"));
//                            if (wait == false)
//                            {
//                                UIMgr.Instance.Continue(Wait(qaq.waudio));
//                            }
//                        }
//                        index = 0;
//                        this.transform.FindChild("Answer").GetComponent<Text>().text = "选项内容：";
//                        TTUIPage.ClosePage(this.name);
//                        return;
//                    }
//                    if (score.result)
//                    {
//                        PlayerController.Instance.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
//                        index = 0;
//                        this.transform.FindChild("Answer").GetComponent<Text>().text = "选项内容：";
//                        transform.FindChild("Bingo").gameObject.SetActive(true);
//                        answerimg.SetActive(true);
//                        shuomingText.text = qaq.shuoming;
//                        //Program.AudioManager.Instance.Play(qaq.raudio, false);
//                        if (wait == false)
//                        {
//                            UIMgr.Instance.Continue(Wait(qaq.raudio));
//                        }
//                    }
//                    else
//                    {
//                        transform.FindChild("Error").gameObject.SetActive(true);
//                        AudioManager.instance.StopAudio();
//                        AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("ZJW/Audio/wrong"));
//                        index++;
//                        if (index >= 3)
//                        {
//                            answerimg.SetActive(true);
//                            shuomingText.text = qaq.shuoming;
//                            index = 0;
//                            //Program.AudioManager.Instance.Play(qaq.waudio, false);
//                            if (wait == false)
//                            {
//                                UIMgr.Instance.Continue(Wait(qaq.waudio));
//                            }
//                        }
//                        else
//                        {
//                            //Program.AudioManager.Instance.Play(Resources.Load<AudioClip>(""), false);
//                        }
//                    }
//                });
//            }

//            foreach (Toggle item in toggle)//qc.
//            {
//                item.onValueChanged.AddListener(delegate { ChooseToggle(); });
//            }
//        }

//        IEnumerator Wait(AudioClip audio)
//        {
//            wait = true;
//            AudioManager.instance.StopAudio();
//            if (audio) AudioManager.instance.PlayAudio(audio);
//            yield return new WaitForSeconds(0);
//            //yield return new WaitForSeconds(audio.length);
//            //answerimg.SetActive(false);
//            //shuomingText.text = "";
//            //TTUIPage.ClosePage(this.name);
//            TTUIPage.ShowPage<UINextBtn>();
//            wait = false;
//        }

//        private void ChooseToggle()
//        {
//            this.transform.FindChild("Answer").GetComponent<Text>().text = "选项内容：" + Choose();//qc.
//        }

//        public void OpenQue()
//        {
//            ShowPage<UIQuestion>();
//            Clear();
//        }

//        public void CloseQue()
//        {
//            ClosePage<UIQuestion>();
//            //UIError.CloseError();
//        }

//        #region
//        public void GetQuestion(int index)
//        {
//            PlayerController.Instance.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
//            //Time.timeScale = 0;
//            qaq = QuestionData.QAQ[index];
//            AudioManager.instance.StopAudio();
//            AudioManager.instance.PlayAudio(qaq.qaudio);
//            queText.text = qaq.question.ToString();
//            answerimg.SetActive(false);
//            shuomingText.text = "";
//            index = 0;
//            foreach (Toggle item in toggle)
//            {
//                item.gameObject.SetActive(true);
//                item.group = null;
//                item.isOn = false;
//                item.gameObject.SetActive(false);
//            }
//            for (int i = 0; i < qaq.toggle.Count; i++)
//            {
//                if (qaq.toggle[i] != "" || qaq.toggle[i] != null)
//                {
//                    toggle[i].gameObject.SetActive(true);
//                    toggle[i].transform.FindChild("Label").GetComponent<Text>().text = qaq.toggle[i];
//                    if (qaq.one == true)
//                    {
//                        toggle[i].group = tg;
//                    }
//                }
//            }
//        }

//        public string Choose()
//        {
//            chooce = "";
//            foreach (Toggle go in toggle)
//            {
//                if (go.isOn == true)
//                {
//                    chooce += go.name;
//                }
//            }
//            return chooce;
//        }

//        public ScoreInfo Check()
//        {
//            chooce = "";
//            foreach (Toggle go in toggle)
//            {
//                if (go.isOn == true)
//                {
//                    chooce += go.name;
//                }
//            }
//            //Debug.Log(chooce + "----" + qaq.answer);
//            switch (qaq.id)
//            {
//                case 3001004:
//                    Debug.Log(HLStepManager.Instance.tanswer);
//                    if (chooce.CompareTo(HLStepManager.Instance.tanswer) == 0)
//                    {
//                        scoreInfo = new ScoreInfo(qaq.score, qaq.question, qaq.answer, true);
//                    }
//                    else
//                    {
//                        scoreInfo = new ScoreInfo(0, qaq.question, qaq.answer, false);
//                    }
//                    return scoreInfo;
//                case 7001001:
//                    if (chooce.Contains("A") || chooce.Contains("B") || chooce == "" || chooce == null)
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", false);
//                    }
//                    else
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", true);
//                    }
//                    return scoreInfo;
//                case 7001002:
//                    if (chooce.Contains("A") || chooce.Contains("C") || chooce.Contains("E") || chooce == "" || chooce == null)
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", false);
//                    }
//                    else
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", true);
//                    }
//                    return scoreInfo;
//                case 7001003:
//                    if (chooce.Contains("D") || chooce.Contains("E") || chooce == "" || chooce == null)
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", false);
//                    }
//                    else
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", true);
//                    }
//                    return scoreInfo;
//                case 7001004:
//                    if (chooce.Contains("A") || chooce.Contains("D") || chooce == "" || chooce == null)
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", false);
//                    }
//                    else
//                    {
//                        scoreInfo = new ScoreInfo(0, "", "", true);
//                    }
//                    return scoreInfo;
//                default:
//                    break;
//            }

//            if (chooce.CompareTo(qaq.answer) == 0)
//            {
//                scoreInfo = new ScoreInfo(qaq.score, qaq.question, qaq.answer, true);
//            }
//            else
//            {
//                scoreInfo = new ScoreInfo(0, qaq.question, qaq.answer, false);
//            }
//            return scoreInfo;
//        }

//        public void Clear()
//        {
//            foreach (Toggle go in toggle)
//            {
//                go.isOn = false;
//            }
//        }
//        #endregion
//    }
//}
