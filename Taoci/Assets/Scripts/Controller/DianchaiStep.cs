using System;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace TaoCi
{
    public class DianchaiStep : StepManager
    {
        public static DianchaiStep Instance;
        public List<GameObject> matizhu = new List<GameObject>();
        public List<GameObject> pengban = new List<GameObject>();
        public List<GameObject> peipin = new List<GameObject>();

        private void Awake()
        {
            Instance = this;
            LocalStepChange += new EventHandler(DoThings);
            setStep = 2001000;
            LocalStep = setStep;
            gameObject.AddComponent<UIManager>();
            UIManager.Instance.GetStepManager(this);
        }

        public override void DoThings(object sender, EventArgs e)
        {
            switch (LocalStep)
            {
                case 2001001:
                    FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = false;
                    TTUIPage.ShowPage<UITitle>();
                    //TTUIPage.ShowPage<UIIntroduceBtn>();
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击墙上高亮的安全守则查看相关内容。");
                    CamOperator.Instance.GetComponent<CamOperator>().enabled = false;
                    break;
                case 2001002:
                    Dianyaolu.Instance.GetComponent<Collider>().enabled = false;
                    Dianyaolu.Instance.GetComponent<HighlightingSystem.Highlighter>().enabled = false;
                    TTUIPage.ClosePage<UIIntroduceBtn>();
                    SetStep(2002001);//1002001
                    break;
                case 2002001:
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
                case 2002002:
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
                case 2002003:
                    UITip.Instance.SetTip("点击马蹄柱，先在窑车四个角各立一根马蹄柱。");
                    break;
                case 2002004:
                    TTUIPage.ClosePage<UITip>();
                    TTUIPage.ShowPage<UIQuestion>();
                    UIQuestion.Instance.GetQuestion(2002004);
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                case 2002005:
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在窑车上。");
                    break;
                case 2002006:
                    UITip.Instance.SetTip("点击马蹄柱，先在一层硼板四个角各立一根马蹄柱。");
                    break;
                case 2002007:
                    UITip.Instance.SetTip("点击坭兴陶坯品，将坭兴陶坯品平铺在窑车上，第一层摆放完毕。");
                    break;
                case 2002008:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在四个马蹄柱上。");
                    break;
                case 2002009:
                    UITip.Instance.SetTip("点击马蹄柱，先在二层硼板四个角各立一根马蹄柱。");
                    break;
                case 2002010:
                    UITip.Instance.SetTip("点击坭兴陶坯品，将坭兴陶坯品平铺在窑车上，第二层摆放完毕。");
                    break;
                case 2002011:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在四个马蹄柱上。");
                    break;
                case 2002012:
                    UITip.Instance.SetTip("点击坭兴陶坯品，将坭兴陶坯品平铺在窑车上，第三层摆放完毕。");
                    break;
                case 2002013:
                    UITip.Instance.SetTip("点击窑车，将窑车推回电窑炉，关闭炉门。");
                    break;
                case 2002014:
                    TTUIPage.ClosePage<UITip>();
                    SetStep(2003001);
                    break;
                case 2003001:
                    UICProcess.Instance.SetPage(3);
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("请前往电窑左侧，将墙上开关通电。");
                    break;
                case 2003002:
                    UITip.Instance.SetTip("点击电窑控制面板，设定坭兴陶烧制升温曲线。");
                    break;
                case 2003003:
                    TTUIPage.ClosePage<UITip>();
                    TTUIPage.ShowPage<UISetValue>();
                    break;
                case 2003004:
                    TTUIPage.ClosePage<UISetValue>();
                    SetStep(2004001);
                    break;
                case 2004001:
                    UICProcess.Instance.SetPage(4);
                    //TTUIPage.ShowPage<UITip>();
                    //UITip.Instance.SetTip("点击开关，关闭电源");
                    TTUIPage.ShowPage<UISlider>();
                    UISlider.Instance.Wait("升温过程，等待12小时");
                    AudioManager.instance.StopAudio();
                    AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Burn"));
                    break;
                case 2004002:
                    AudioManager.instance.StopAudio();
                    TTUIPage.ClosePage<UISlider>();
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("进入窑变技艺环节，点击木柴，持续不断从投料口放入窑内给窑内升温。");
                    break;
                case 2004003:
                    LocalStepAdd();
                    break;
                case 2004004:
                    //UITip.Instance.SetTip("开启排烟口，使窑内上下通气，煤块、松香接触氧气火焰升高，窜出排烟口，而浓烟滞留在窑内两侧，此时窑内既有氧化气氛又有还原气氛，即中性气氛。");
                    ShaderColorController.Instance.Burn();
                    ShaderColorController.Instance.fireLight.intensity = 3;
                    //Fire.Instance.ChangeLittleFire(true);
                    TTUIPage.ShowPage<UISingleBtn>();
                    UISingleBtn.Instance.transform.Find("EffectBtn").gameObject.SetActive(true);
                    UITip.Instance.SetTip("点击炉内效果按钮，可查看窑内陶瓷烧制动态效果。");
                    UIManager.Instance.Delay(Openpaiyankou());
                    break;
                case 2004005:
                    UISingleBtn.Instance.transform.Find("PaiyankouBtn").gameObject.SetActive(false);
                    //Fire.Instance.ChangeLittleFire(false);
                    ShaderColorController.Instance.fireLight.intensity = 5;
                    Fire.Instance.ChangeInFire(true);
                    //Fire.Instance.ChangeOutFire(true);
                    UITip.Instance.SetTip("木柴在窑内燃烧，形成草木灰和变幻莫测的落灰釉，至此，窑变形成。");
                    UIManager.Instance.Delay(Wait());
                    break;
                case 2004006:
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("请关闭电源，开启降温环节。");
                    break;
                case 2004007:
                    Fire.Instance.ChangeInFire(false);
                    Fire.Instance.ChangeOutFire(false);
                    //UITip.Instance.SetTip("开启排烟口、观火口、投料口，进入降温环节。");       
                    TTUIPage.ClosePage<UITip>();
                    ShaderColorController.Instance.Cool();
                    TTUIPage.ShowPage<UISlider>();
                    UISlider.Instance.Wait("降温阶段，等待24小时");
                    break;
                case 2004008:
                    TTUIPage.ClosePage<UISingleBtn>();
                    TTUIPage.ClosePage<UISlider>();
                    TTUIPage.ShowPage<UIQuestion>();
                    UIQuestion.Instance.GetQuestion(1004007);
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                case 2004009:
                    Lumen.Instance.gameObject.SetActive(true);
                    SetStep(2005001);
                    break;
                case 2005001:
                    UICProcess.Instance.SetPage(5);
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击戴上手套。");
                    break;
                case 2005002:
                    UITip.Instance.SetTip("点击取下两个阀门，点击打开电窑炉门，拉出窑车。");
                    break;
                case 2005003:
                    UITip.Instance.SetTip("点击取下最上层烧制好的坭兴陶。");
                    break;
                case 2005004:
                    UITip.Instance.SetTip("点击取下最上层硼板。");
                    break;
                case 2005005:
                    UITip.Instance.SetTip("点击取下最上层马蹄柱。");
                    break;
                case 2005006:
                    UITip.Instance.SetTip("点击取下第二层烧制好的坭兴陶。");
                    break;
                case 2005007:
                    UITip.Instance.SetTip("点击取下第二层硼板。");
                    break;
                case 2005008:
                    UITip.Instance.SetTip("点击取下第二层马蹄柱。");
                    break;
                case 2005009:
                    UITip.Instance.SetTip("点击取下最下层烧制好的坭兴陶。");
                    break;
                case 2005010:
                    UITip.Instance.SetTip("点击取下最下层硼板。");
                    break;
                case 2005011:
                    UITip.Instance.SetTip("点击取下最下层马蹄柱。");
                    break;
                case 2005012:
                    UITip.Instance.SetTip("点击窑车，关闭电窑炉。");
                    break;
                case 2005013:
                    UITitle.Instance.SetPage(3);
                    TTUIPage.ClosePage<UICProcess>();
                    UITip.Instance.SetTip("点击烧制好的坭兴陶，显示要变效果图。");
                    foreach (GameObject item in peipin)
                    {
                        item.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2005014:
                    TTUIPage.ClosePage<UITip>();
                    SetStep(2006001);
                    break;
                case 2006001:
                    UITitle.Instance.SetPage(4);
                    TTUIPage.ClosePage<UIPicture>();
                    TTUIPage.ShowPage<UIEnd>();
                    UIEnd.Instance.ShowScore();
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
            LocalStepAdd();
        }
    }
}