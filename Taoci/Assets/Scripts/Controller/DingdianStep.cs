using Com.Rainier.ZC_Frame;
using System;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace TaoCi
{
    public class DingdianStep : StepManager
    {
        public static DingdianStep Instance;
        public List<GameObject> matizhu = new List<GameObject>();
        public List<GameObject> pengban = new List<GameObject>();
        public List<GameObject> peipin = new List<GameObject>();
        public List<GameObject> xiabo = new List<GameObject>();

        private void Awake()
        {
            Instance = this;
            LocalStepChange += new EventHandler(DoThings);
            setStep = 4001000;
            LocalStep = setStep;
            gameObject.AddComponent<UIManager>();
            UIManager.Instance.GetStepManager(this);
        }

        public override void DoThings(object sender, EventArgs e)
        {
            switch (LocalStep)
            {
                case 4001001:
                    FirstPersonController.Instance.GetComponent<FirstPersonController>().enabled = false;
                    TTUIPage.ShowPage<UITitle>();
                    //TTUIPage.ShowPage<UIIntroduceBtn>();
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击墙上高亮的安全守则查看相关内容。");
                    CamOperator.Instance.GetComponent<CamOperator>().enabled = false;
                    break;
                case 4001002:
                    Dianyaolu.Instance.GetComponent<Collider>().enabled = false;
                    Dianyaolu.Instance.GetComponent<HighlightingSystem.Highlighter>().enabled = false;
                    TTUIPage.ClosePage<UIIntroduceBtn>();
                    SetStep(4002001);//1002001
                    break;
                case 4002001:
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
                case 4002002:
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
                case 4002003:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在窑车上。");
                    break;
                case 4002004:
                    UITip.Instance.SetTip("点击马蹄柱，先在一层硼板四个角各立一根马蹄柱。");
                    break;
                case 4002005:
                    UITip.Instance.SetTip("点击坭兴陶挂盘坯品，将坭兴陶坯品平铺在窑车上。");
                    break;
                case 4002006:
                    UITip.Instance.SetTip("点击匣钵，将匣钵反扣住覆盖挂盘上的图案，第一层摆放完毕。");
                    break;
                case 4002007:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在四个马蹄柱上。");
                    break;
                case 4002008:
                    UITip.Instance.SetTip("点击马蹄柱，先在二层硼板四个角各立一根马蹄柱。");
                    break;
                case 4002009:
                    UITip.Instance.SetTip("点击坭兴陶挂盘坯品，将坭兴陶坯品平铺在窑车上。");
                    break;
                case 4002010:
                    UITip.Instance.SetTip("点击匣钵，将匣钵反扣住覆盖挂盘上的图案，第二层摆放完毕。");
                    break;
                case 4002011:
                    UITip.Instance.SetTip("点击硼板，将硼板平铺在四个马蹄柱上。");
                    break;
                case 4002012:
                    UITip.Instance.SetTip("点击坭兴陶挂盘坯品，将坭兴陶坯品平铺在窑车上。");
                    break;
                case 4002013:
                    UITip.Instance.SetTip("点击匣钵，将匣钵反扣住覆盖挂盘上的图案，第三层摆放完毕。");
                    break;
                case 4002014:
                    UITip.Instance.SetTip("点击窑车，将窑车推回电窑炉，关闭炉门。");
                    break;
                case 4002015:
                    TTUIPage.ClosePage<UITip>();
                    SetStep(4003001);
                    break;
                case 4003001:
                    UICProcess.Instance.SetPage(3);
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("请前往电窑左侧，将墙上开关通电。");
                    break;
                case 4003002:
                    UITip.Instance.SetTip("点击电窑控制面板，设定坭兴陶烧制升温曲线。");
                    break;
                case 4003003:
                    TTUIPage.ClosePage<UITip>();
                    TTUIPage.ShowPage<UISetValue>();
                    break;
                case 4003004:
                    TTUIPage.ClosePage<UISetValue>();
                    SetStep(4004001);
                    break;
                case 4004001:
                    UICProcess.Instance.SetPage(4);
                    //UITip.Instance.SetTip("点击开关，关闭电源");
                    //TTUIPage.ShowPage<UITip>();
                    //UITip.Instance.SetTip("升温过程。");
                    TTUIPage.ShowPage<UISlider>();
                    UISlider.Instance.Wait("升温过程，等待12小时");
                    AudioManager.instance.StopAudio();
                    AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Burn"));
                    break;
                case 4004002:
                    AudioManager.instance.StopAudio();
                    TTUIPage.ClosePage<UISlider>();
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("进入窑变技艺环节，点击煤块，从投料口向炉内投入0.5kg煤块。");
                    break;
                case 4004003:
                    UITip.Instance.SetTip("进入窑变技艺环节，点击松香，从投料口向炉内投入0.5kg松香。");
                    break;
                case 4004004:                    
                    ShaderColorController.Instance.Burn();
                    ShaderColorController.Instance.fireLight.intensity = 3;
                    Fire.Instance.ChangeLittleFire(true);
                    TTUIPage.ShowPage<UISingleBtn>();
                    UISingleBtn.Instance.transform.Find("EffectBtn").gameObject.SetActive(true);
                    UISingleBtn.Instance.transform.Find("PaiyankouBtn").gameObject.SetActive(false);
                    UITip.Instance.SetTip("点击炉内效果按钮，可查看窑内陶瓷烧制动态效果。");
                    UIManager.Instance.Delay(Openpaiyankou());                    
                    break;
                case 4004005:
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("请关闭电源，开启降温环节。");
                    break;
                case 4004006:
                    Fire.Instance.ChangeLittleFire(false);
                    Fire.Instance.ChangeOutFire(false);
                    //UITip.Instance.SetTip("开启排烟口、观火口、投料口，进入降温环节。");       
                    TTUIPage.ClosePage<UITip>();
                    ShaderColorController.Instance.Cool();
                    TTUIPage.ShowPage<UISlider>();
                    UISlider.Instance.Wait("降温阶段，等待24小时");
                    break;
                case 4004007:
                    TTUIPage.ClosePage<UISingleBtn>();
                    TTUIPage.ClosePage<UISlider>();
                    TTUIPage.ShowPage<UIQuestion>();
                    UIQuestion.Instance.GetQuestion(1004007);
                    UIManager.Instance.Delay(QuestionEnd());
                    break;
                case 4004008:
                    Lumen.Instance.gameObject.SetActive(true);
                    SetStep(4005001);
                    break;
                case 4005001:
                    UICProcess.Instance.SetPage(5);
                    TTUIPage.ShowPage<UITip>();
                    UITip.Instance.SetTip("点击戴上手套。");
                    break;
                case 4005002:
                    UITip.Instance.SetTip("点击取下两个阀门，点击打开电窑炉门，拉出窑车。");
                    break;
                case 4005003:
                    UITip.Instance.SetTip("点击取下最上层的匣钵。");
                    break;
                case 4005004:
                    UITip.Instance.SetTip("点击取下最上层烧制好的坭兴陶。");
                    break;
                case 4005005:
                    UITip.Instance.SetTip("点击取下最上层硼板。");
                    break;
                case 4005006:
                    UITip.Instance.SetTip("点击取下第二层马蹄柱。");
                    break;
                case 4005007:
                    UITip.Instance.SetTip("点击取下第二层的匣钵。");
                    break;
                case 4005008:
                    UITip.Instance.SetTip("点击取下第二层烧制好的坭兴陶。");
                    break;
                case 4005009:
                    UITip.Instance.SetTip("点击取下第二层硼板。");
                    break;
                case 4005010:
                    UITip.Instance.SetTip("点击取下最下层马蹄柱。");
                    break;
                case 4005011:
                    UITip.Instance.SetTip("点击取下最下层的匣钵。");
                    break;
                case 4005012:
                    UITip.Instance.SetTip("点击取下最下层烧制好的坭兴陶。");
                    break;
                case 4005013:
                    UITip.Instance.SetTip("点击取下最下层硼板。");
                    break;
                case 4005014:
                    UITip.Instance.SetTip("点击窑车，关闭电窑炉。");
                    break;
                case 4005015:
                    UITitle.Instance.SetPage(3);
                    TTUIPage.ClosePage<UICProcess>();
                    UITip.Instance.SetTip("点击烧制好的坭兴陶，显示要变效果图。");
                    foreach (GameObject item in peipin)
                    {
                        item.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4005016:
                    TTUIPage.ClosePage<UITip>();
                    SetStep(4006001);
                    break;
                case 4006001:
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
            UITip.Instance.SetTip("煤块和松香燃烧消耗窑内氧气，产生少量火焰和大量浓烟，形成还原气氛，坭兴陶坯体中的高价铁会还原变成氧化亚铁，浓烟中的碳元素会吸附到坭兴陶表面，形成黑灰色、深青色或深蓝色等暗色调，而有匣钵覆盖的地方遮挡而无法被碳元素附着，形成古铜色或深红色。");
            UIManager.Instance.Delay(Wait());
        }
    }
}