using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Com.Rainier.ZC_Frame;

namespace TaoCi
{
    public class YanshaoStep : StepManager
    {
        public static YanshaoStep Instance;
        public List<GameObject> matizhu = new List<GameObject>();
        public List<GameObject> pengban = new List<GameObject>();
        public List<GameObject> peipin = new List<GameObject>();

        private void Awake()
        {
            Instance = this;
            LocalStepChange += new EventHandler(DoThings);
            setStep = 3001000;
            LocalStep = setStep;
            gameObject.AddComponent<UIManager>();
            UIManager.Instance.GetStepManager(this);
        }

        public override void DoThings(object sender, EventArgs e)
        {
            switch (LocalStep)
            {
                case 3001001:
                    FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = false;
                    TTUIPage.ShowPage<UITitle>();
                    //TTUIPage.ShowPage<UIIntroduceBtn>();
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击墙上高亮的安全守则查看相关内容。");
                    CamOperator.Instance.GetComponent<CamOperator>().enabled = false;
                    break;
                case 3001002:
                    Dianyaolu.Instance.GetComponent<Collider>().enabled = false;
                    Dianyaolu.Instance.GetComponent<HighlightingSystem.Highlighter>().enabled = false;
                    TTUIPage.ClosePage<UIIntroduceBtn>();
                    SetStep(3002001);//1002001
                    break;
                case 3002001:
                    TTUIPage.ShowPage<UICProcess>();
                    TTUIPage.ShowPage<UIKou>();
                    TTUIPage.ClosePage<UIIntroduce>();
                    UITitle.Instance.SetPage(2);
                    UITitle.Instance.transform.Find("StartBtn").gameObject.SetActive(false);
                    FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = false;
                    CamOperator.Instance.GetComponent<CamOperator>().enabled = true;
                    CamOperator.Instance.cam.GetComponent<Camera>().depth = 1;
                    transform.GetComponent<InputListener>().cam = CamOperator.Instance.cam.GetComponent<Camera>();
                    CamOperator.Instance.target.gameObject.SetActive(true);
                    CamOperator.Instance.GetComponent<CamOperator>().enabled = false;
                    break;
                case 3002002:
                    TTUIPage.ClosePage<UIKou>();
                    FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = true;
                    CamOperator.Instance.GetComponent<CamOperator>().enabled = false;
                    UICProcess.Instance.SetPage(2);
                    CamOperator.Instance.target.gameObject.SetActive(false);
                    CamOperator.Instance.cam.GetComponent<Camera>().depth = -1;
                    transform.GetComponent<InputListener>().cam = Camera.main;
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击取下两个阀门，点击打开电窑炉门，拉出窑车。");
                    break;
                case 3002003:
                    //UITip.Instance.SetTip("点击马蹄柱，先在窑车四个角各立一根马蹄柱。");
                    LocalStepAdd();
                    break;
                case 3002004:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在窑车上。");
                    break;
                case 3002005:
                    UITip.Instance.SetTip("点击马蹄柱，先在一层硼板四个角各立一根马蹄柱。");
                    break;
                case 3002006:
                    UITip.Instance.SetTip("点击坭兴陶坯品，将坭兴陶坯品平铺在窑车上，第一层摆放完毕。");
                    break;
                case 3002007:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在四个马蹄柱上。");
                    break;
                case 3002008:
                    UITip.Instance.SetTip("点击马蹄柱，先在二层硼板四个角各立一根马蹄柱。");
                    break;
                case 3002009:
                    UITip.Instance.SetTip("点击坭兴陶坯品，将坭兴陶坯品平铺在窑车上，第二层摆放完毕。");
                    break;
                case 3002010:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在四个马蹄柱上。");
                    break;
                case 3002011:
                    UITip.Instance.SetTip("点击坭兴陶坯品，将坭兴陶坯品平铺在窑车上，第三层摆放完毕。");
                    break;
                case 3002012:
                    UITip.Instance.SetTip("点击窑车，将窑车推回电窑炉，关闭炉门。");
                    break;
                case 3002013:
                    TTUIPage.ClosePage<UITip>();
                    SetStep(3003001);
                    break;
                case 3003001:
                    UICProcess.Instance.SetPage(3);
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("请前往电窑左侧，将墙上开关通电。");
                    break;
                case 3003002:
                    UITip.Instance.SetTip("点击电窑控制面板，设定坭兴陶烧制升温曲线。");
                    break;
                case 3003003:
                    TTUIPage.ClosePage<UITip>();
                    TTUIPage.ShowPage<UISetValue>();
                    break;
                case 3003004:
                    TTUIPage.ClosePage<UISetValue>();
                    SetStep(3004001);
                    break;
                case 3004001:
                    UICProcess.Instance.SetPage(4);
                    //UITip.Instance.SetTip("点击开关，关闭电源");
                    //TTUIPage.ShowPage<UITip>();
                    //UITip.Instance.SetTip("升温过程。");
                    TTUIPage.ShowPage<UISlider>();
                    UISlider.Instance.Wait("升温过程，等待12小时");
                    AudioManager.instance.StopAudio();
                    AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Burn"));
                    break;
                case 3004002:
                    AudioManager.instance.StopAudio();
                    TTUIPage.ClosePage<UISlider>();
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("进入窑变技艺环节，点击带上防毒面具。");
                    break;
                case 3004003:
                    UITip.Instance.SetTip("进入窑变技艺环节，点击海盐，从投料口向炉内投入海盐。");
                    break;
                case 3004004:
                    TTUIPage.ClosePage<UITip>();
                    TTUIPage.ShowPage<UIQuestion>();
                    UIQuestion.Instance.GetQuestion(3004004);
                    UIManager.Instance.Delay(QuestionEnd());
                    break;                
                case 3004005:
                    ShaderColorController.Instance.Burn();
                    ShaderColorController.Instance.fireLight.intensity = 3;
                    TTUIPage.ShowPage<UITip>();
                    TTUIPage.ShowPage<UISingleBtn>();
                    UISingleBtn.Instance.transform.Find("EffectBtn").gameObject.SetActive(true);
                    UISingleBtn.Instance.transform.Find("PaiyankouBtn").gameObject.SetActive(false);
                    UITip.Instance.SetTip("点击炉内效果按钮，可查看窑内陶瓷烧制动态效果。");
                    UIManager.Instance.Delay(Openpaiyankou());
                    break;
                case 3004006:
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("请关闭电源，开启降温环节。");
                    break;
                case 3004007:
                    Fire.Instance.ChangeInFire(false);
                    Fire.Instance.ChangeOutFire(false);
                    //UITip.Instance.SetTip("开启排烟口、观火口、投料口，进入降温环节。");       
                    TTUIPage.ClosePage<UITip>();
                    ShaderColorController.Instance.Cool();
                    TTUIPage.ShowPage<UISlider>();
                    UISlider.Instance.Wait("降温阶段，等待24小时");
                    break;
                case 3004008:
                    TTUIPage.ClosePage<UISingleBtn>();
                    TTUIPage.ClosePage<UISlider>();
                    TTUIPage.ShowPage<UIQuestion>();
                    UIQuestion.Instance.GetQuestion(1004007);
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                case 3004009:
                    Lumen.Instance.gameObject.SetActive(true);
                    SetStep(3005001);
                    break;
                case 3005001:
                    UICProcess.Instance.SetPage(5);
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击戴上手套。");
                    break;
                case 3005002:
                    UITip.Instance.SetTip("点击取下两个阀门，点击打开电窑炉门，拉出窑车。");
                    break;
                case 3005003:
                    UITip.Instance.SetTip("点击取下最上层烧制好的坭兴陶。");
                    break;
                case 3005004:
                    UITip.Instance.SetTip("点击取下最上层硼板。");
                    break;
                case 3005005:
                    UITip.Instance.SetTip("点击取下第二层马蹄柱。");
                    break;
                case 3005006:
                    UITip.Instance.SetTip("点击取下第二层烧制好的坭兴陶。");
                    break;
                case 3005007:
                    UITip.Instance.SetTip("点击取下第二层硼板。");
                    break;
                case 3005008:
                    UITip.Instance.SetTip("点击取下最下层马蹄柱。");
                    break;
                case 3005009:
                    UITip.Instance.SetTip("点击取下最下层烧制好的坭兴陶。");
                    break;
                case 3005010:
                    UITip.Instance.SetTip("点击取下最下层硼板。");
                    break;
                case 3005011:
                    //UITip.Instance.SetTip("点击取下最下层马蹄柱。");
                    LocalStepAdd();
                    break;
                case 3005012:
                    UITip.Instance.SetTip("点击窑车，关闭电窑炉。");
                    break;
                case 3005013:
                    UITitle.Instance.SetPage(3);
                    TTUIPage.ClosePage<UICProcess>();
                    UITip.Instance.SetTip("点击烧制好的坭兴陶，显示要变效果图。");
                    foreach (GameObject item in peipin)
                    {
                        item.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3005014:
                    TTUIPage.ClosePage<UITip>();
                    SetStep(3006001);
                    break;
                case 3006001:
                    UITitle.Instance.SetPage(4);
                    TTUIPage.ClosePage<UIPicture>();
                    TTUIPage.ShowPage<UIEnd>();
                    UIEnd.Instance.transform.GetComponent<Test>().ShowScore();
                    break;
                default:
                    break;
            }
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(10);
            LocalStepAdd();
        }

        IEnumerator QuestionEnd()
        {
            yield return new WaitUntil(() => !UIQuestion.Instance.gameObject.activeSelf);
            LocalStepAdd();
        }

        IEnumerator Openpaiyankou()
        {
            yield return new WaitUntil(() => UISingleBtn.Instance.transform.Find("PaiyankouBtn").gameObject.activeSelf);
            UISingleBtn.Instance.transform.Find("PaiyankouBtn").gameObject.SetActive(false);
            Fire.Instance.ChangeInFire(true);
            UITip.Instance.SetTip("海盐遇高温融化，海盐在高温中分解出的钠化合物与二氧化硅结合形成薄薄釉面，同时也会与胚体中的氧化铝产生排斥现象，造成“桔皮”的玻璃质感的窑变效果。");
            UIManager.Instance.Delay(Wait());
        }
    }
}