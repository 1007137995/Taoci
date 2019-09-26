using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TaoCi
{
    public class SetValue : MonoBehaviour
    {
        //public GameObject burnControl;

        //public GameObject setView;

        //public Sprite buttonHighLight;
        //public Sprite buttonLowLight;

        public GameObject timeShower;
        public GameObject tempShower;

        private bool lightOn;

        private bool isSetting;

        private bool isSettingTimeNorTemp;

        private int isInStep;
        public GameObject[] stepButton;

        public GameObject[] resultTime;
        public float[] resultTimeNumber;
        public GameObject[] resultTemp;
        public int[] resultTempNumber;

        public GameObject SetOverButton;

        public GameObject beginBurnButton;

        public GameObject tipButton;
        public Text tipText;
        private bool tipOn;

        public bool isBurning;


        //后加上去的按钮
        public GameObject[] setTempAndTimeImage;
        public GameObject[] setTimeImage;
        public GameObject[] setTempImage;
        private int index = 0;
        private int errorindex = 0;

        void Awake()
        {
            isSettingTimeNorTemp = true;

            resultTempNumber = new int[5];
            resultTimeNumber = new float[5];

            beginBurnButton.GetComponent<Button>().interactable = false;
        }
        
        private void Start()
        {
            
        }
        
        private void Update()
        {
            //控制数字闪烁开关
            //if (isSetting) {
            //if (isSettingTimeNorTemp) {
            //Invoke ("SetTempShowerAppear", 0.3f);
            //Bling (timeShower);
            //} else {
            //Invoke ("SetTimeShowerAppear", 0.3f);
            //Bling (tempShower);
            //}
            //} else {
            //Invoke ("SetTempShowerAppear", 0.3f);
            //Invoke ("SetTimeShowerAppear", 0.3f);
            //}
            //如果没有设置完成，设置完毕按钮不出现
            for (int i = 0; i < 5; i++)
            {
                if ((resultTempNumber[i] == 0) && (resultTimeNumber[i] == 0f))
                {
                    SetOverButton.GetComponent<Button>().interactable = false;
                    break;
                }
                else
                {
                    SetOverButton.GetComponent<Button>().interactable = true;
                }
            }

            //更改后的触发按钮条件


        }

        public void OnClickStep001()
        {
            index = 0;
            for (int i = 0; i < setTempAndTimeImage.Length; i++)
            {
                if (i != index)
                {

                    setTempAndTimeImage[i].SetActive(false);
                }
                else
                {
                    setTempAndTimeImage[index].SetActive(true);
                }
            }
        }


        public void OnClickStep002()
        {
            index = 1;
            for (int i = 0; i < setTempAndTimeImage.Length; i++)
            {
                if (i != index)
                {

                    setTempAndTimeImage[i].SetActive(false);
                }
                else
                {
                    setTempAndTimeImage[index].SetActive(true);
                }
            }
        }
        public void OnClickStep003()
        {
            index = 2;
            for (int i = 0; i < setTempAndTimeImage.Length; i++)
            {
                if (i != index)
                {

                    setTempAndTimeImage[i].SetActive(false);
                }
                else
                {
                    setTempAndTimeImage[index].SetActive(true);
                }
            }
        }
        public void OnClickStep004()
        {
            index = 3;
            for (int i = 0; i < setTempAndTimeImage.Length; i++)
            {
                if (i != index)
                {
                    setTempAndTimeImage[i].SetActive(false);
                }
                else
                {
                    setTempAndTimeImage[index].SetActive(true);
                }
            }
        }
        public void OnClickStep005()
        {
            index = 4;
            for (int i = 0; i < setTempAndTimeImage.Length; i++)
            {
                if (i != index)
                {
                    setTempAndTimeImage[i].SetActive(false);
                }
                else
                {
                    setTempAndTimeImage[index].SetActive(true);
                }
            }
        }

        public void SetTime()
        {
            setTimeImage[index].SetActive(true);
            setTempImage[index].SetActive(false);
        }
        public void SetTemp()
        {
            setTimeImage[index].SetActive(false);
            setTempImage[index].SetActive(true);
        }
        
        public void SetTimeToText(Text t)
        {
            resultTime[index].GetComponent<Text>().text = "时间：" + t.text + "h";
            timeShower.GetComponent<Text>().text = t.text;
            resultTimeNumber[index] = float.Parse(timeShower.GetComponent<Text>().text);
            CheckTime(index, t.text);
        }
        
        public void SetTempToText(Text t)
        {
            resultTemp[index].GetComponent<Text>().text = "温度：" + t.text + "°C";
            tempShower.GetComponent<Text>().text = t.text;
            resultTempNumber[index] = int.Parse(tempShower.GetComponent<Text>().text);
            CheckTemp(index, t.text);
        }

        public void GetBackImage()
        {
            setTempAndTimeImage[index].SetActive(false);
        }



        //控制调制器上温度及时间的跳跃显示
        void Bling(GameObject shower)
        {
            if (shower == timeShower)
            {
                if (lightOn)
                {
                    Invoke("SetTimeShowerMiss", 0.3f);
                    Invoke("SetLightOnFalse", 0.3f);
                }
                else
                {
                    Invoke("SetTimeShowerAppear", 0.3f);
                    Invoke("SetLightOnTrue", 0.3f);
                }
            }
            else if (shower == tempShower)
            {
                if (lightOn)
                {
                    Invoke("SetTempShowerMiss", 0.3f);
                    Invoke("SetLightOnFalse", 0.3f);
                }
                else
                {
                    Invoke("SetTempShowerAppear", 0.3f);
                    Invoke("SetLightOnTrue", 0.3f);
                }
            }
        }

        void SetTimeShowerMiss()
        {
            timeShower.SetActive(false);
        }

        void SetTimeShowerAppear()
        {
            timeShower.SetActive(true);
        }

        void SetTempShowerMiss()
        {
            tempShower.SetActive(false);
        }

        void SetTempShowerAppear()
        {
            tempShower.SetActive(true);
        }

        void SetLightOnTrue()
        {
            lightOn = true;
        }

        void SetLightOnFalse()
        {
            lightOn = false;
        }

        public void OnClickTipButton()
        {
            if (!tipOn)
            {
                tipText.gameObject.SetActive(true);
                tipOn = true;
            }
            else
            {
                tipText.gameObject.SetActive(false);
                tipOn = false;
            }
        }

        //public void OnClickStep01()
        //{
        //    isInStep = 1;
        //    isSetting = false;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i == isInStep - 1)
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonHighLight;
        //        }
        //        else
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonLowLight;
        //        }
        //    }
        //}

        //public void OnClickStep02()
        //{
        //    isInStep = 2;
        //    isSetting = false;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i == isInStep - 1)
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonHighLight;
        //        }
        //        else
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonLowLight;
        //        }
        //    }
        //}

        //public void OnClickStep03()
        //{
        //    isInStep = 3;
        //    isSetting = false;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i == isInStep - 1)
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonHighLight;
        //        }
        //        else
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonLowLight;
        //        }
        //    }
        //}

        //public void OnClickStep04()
        //{
        //    isInStep = 4;
        //    isSetting = false;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i == isInStep - 1)
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonHighLight;
        //        }
        //        else
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonLowLight;
        //        }
        //    }
        //}

        //public void OnClickStep05()
        //{
        //    isInStep = 5;
        //    isSetting = false;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i == isInStep - 1)
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonHighLight;
        //        }
        //        else
        //        {
        //            stepButton[i].GetComponent<Image>().sprite = buttonLowLight;
        //        }
        //    }
        //}

        public void CheckTime(int i, string t)
        {
            switch (i)
            {
                case 0:
                    switch (t)
                    {
                        case "1":
                            tipText.text = "升温过快，窑内水汽排除不彻底，坭兴陶坯品炸裂，烧窑失败。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        case "2":
                            tipText.text = "升温过快，窑内水汽排除不彻底，坭兴陶坯品炸裂，烧窑失败。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        case "4":
                            if (errorindex == 0)
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(3, "排水阶段时间设置：", "C", true, errorindex));
                            }
                            else
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(0, "排水阶段时间设置：", "C", true, errorindex));
                            }                            
                            stepButton[1].GetComponent<Button>().interactable = true;
                            tipText.text = "选择正确";
                            tipText.color = new Color(0, 130.0f / 255.0f, 10.0f / 255.0f);
                            errorindex = 0;
                            AudioManager.instance.StopAudio();
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    switch (t)
                    {
                        case "1":
                            tipText.text = "升温过快，坭兴陶坯品炸裂，烧窑失败。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        case "2":
                            tipText.text = "升温过快，坭兴陶坯品炸裂，烧窑失败。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        case "3":
                            if (errorindex == 0)
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(3, "低温阶段时间设置：", "C", true, errorindex));
                            }
                            else
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(0, "低温阶段时间设置：", "C", true, errorindex));
                            }
                            stepButton[2].GetComponent<Button>().interactable = true;
                            tipText.text = "选择正确";
                            tipText.color = new Color(0, 130.0f / 255.0f, 10.0f / 255.0f);
                            errorindex = 0;
                            AudioManager.instance.StopAudio();
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (t)
                    {
                        case "1":
                            tipText.text = "升温过快，坭兴陶坯品炸裂，烧窑失败。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        case "2":
                            tipText.text = "升温过快，坭兴陶坯品炸裂，烧窑失败。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        case "3":
                            if (errorindex == 0)
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(3, "中温阶段时间设置：", "C", true, errorindex));
                            }
                            else
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(0, "中温阶段时间设置：", "C", true, errorindex));
                            }                            
                            stepButton[3].GetComponent<Button>().interactable = true;
                            tipText.text = "选择正确";
                            tipText.color = new Color(0, 130.0f / 255.0f, 10.0f / 255.0f);
                            errorindex = 0;
                            AudioManager.instance.StopAudio();                            
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    tipText.text = "";
                    AudioManager.instance.StopAudio();
                    break;
                case 4:
                    tipText.text = "";
                    AudioManager.instance.StopAudio();
                    break;
                default:
                    break;
            }
        }

        public void CheckTemp(int i, string t)
        {
            switch (i)
            {
                case 0:
                    tipText.text = "";
                    AudioManager.instance.StopAudio();
                    break;
                case 1:
                    tipText.text = "";
                    AudioManager.instance.StopAudio();
                    break;
                case 2:
                    tipText.text = "";
                    AudioManager.instance.StopAudio();
                    break;
                case 3:
                    switch (t)
                    {
                        case "1000":
                            tipText.text = "烧制温度不够，造成“生火”，坭兴陶未烧结。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        case "1150":
                            if (errorindex == 0)
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(3, "高温阶段温度设置：", "A", true, errorindex));
                            }
                            else
                            {
                                ScoreInfo.AddSocreInfo(new ScoreInfo(0, "高温阶段温度设置：", "A", true, errorindex));
                            }                            
                            stepButton[4].GetComponent<Button>().interactable = true;
                            tipText.text = "选择正确";
                            tipText.color = new Color(0, 130.0f / 255.0f, 10.0f / 255.0f);
                            errorindex = 0;
                            AudioManager.instance.StopAudio();
                            break;
                        case "1250":
                            tipText.text = "烧制温度过高，造成“过烧”，坭兴陶制品变形坍塌，烧制失败。";
                            tipText.color = Color.red;
                            errorindex++;
                            AudioManager.instance.StopAudio();
                            AudioManager.instance.PlayAudio(Resources.Load<AudioClip>("Audio/Worning"));
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    tipText.text = "";
                    AudioManager.instance.StopAudio();
                    break;
                default:
                    break;
            }
        }

        public void OnClickSetButton()
        {
            if (isInStep != 0)
            {
                if (!isSetting)
                {
                    isSetting = true;
                }
                else
                {
                    isSetting = false;
                    switch (isInStep)
                    {
                        case 1:
                            resultTime[0].GetComponent<Text>().text = "时间：" + timeShower.GetComponent<Text>().text + "h";
                            resultTemp[0].GetComponent<Text>().text = "温度：" + tempShower.GetComponent<Text>().text + "℃";
                            resultTimeNumber[0] = float.Parse(timeShower.GetComponent<Text>().text);
                            resultTempNumber[0] = int.Parse(tempShower.GetComponent<Text>().text);
                            break;
                        case 2:
                            resultTime[1].GetComponent<Text>().text = "时间：" + timeShower.GetComponent<Text>().text + "h";
                            resultTemp[1].GetComponent<Text>().text = "温度：" + tempShower.GetComponent<Text>().text + "℃";
                            resultTimeNumber[1] = float.Parse(timeShower.GetComponent<Text>().text);
                            resultTempNumber[1] = int.Parse(tempShower.GetComponent<Text>().text);
                            break;
                        case 3:
                            resultTime[2].GetComponent<Text>().text = "时间：" + timeShower.GetComponent<Text>().text + "h";
                            resultTemp[2].GetComponent<Text>().text = "温度：" + tempShower.GetComponent<Text>().text + "℃";
                            resultTimeNumber[2] = float.Parse(timeShower.GetComponent<Text>().text);
                            resultTempNumber[2] = int.Parse(tempShower.GetComponent<Text>().text);
                            break;
                        case 4:
                            resultTime[3].GetComponent<Text>().text = "时间：" + timeShower.GetComponent<Text>().text + "h";
                            resultTemp[3].GetComponent<Text>().text = "温度：" + tempShower.GetComponent<Text>().text + "℃";
                            resultTimeNumber[3] = float.Parse(timeShower.GetComponent<Text>().text);
                            resultTempNumber[3] = int.Parse(tempShower.GetComponent<Text>().text);
                            break;
                        case 5:
                            resultTime[4].GetComponent<Text>().text = "时间：" + timeShower.GetComponent<Text>().text + "h";
                            resultTemp[4].GetComponent<Text>().text = "温度：" + tempShower.GetComponent<Text>().text + "℃";
                            resultTimeNumber[4] = float.Parse(timeShower.GetComponent<Text>().text);
                            resultTempNumber[4] = int.Parse(tempShower.GetComponent<Text>().text);
                            break;
                    }
                }
            }
        }

        public void OnClickSwitch()
        {
            isSettingTimeNorTemp = !isSettingTimeNorTemp;
        }


        //向上调温度或者时间
        public void OnClickUp()
        {
            if (isSetting)
            {
                if (isSettingTimeNorTemp)
                {
                    float time = float.Parse(timeShower.GetComponent<Text>().text);
                    time += 0.1f;
                    timeShower.GetComponent<Text>().text = time.ToString();
                }
                else
                {
                    int temp = int.Parse(tempShower.GetComponent<Text>().text);
                    temp += 50;
                    tempShower.GetComponent<Text>().text = temp.ToString();
                }
            }
        }
        //向下调温度或者时间
        public void OnClickDown()
        {
            if (isSetting)
            {
                if (isSettingTimeNorTemp)
                {
                    float time = float.Parse(timeShower.GetComponent<Text>().text);
                    if (time > 0f)
                    {
                        time -= 0.1f;
                    }
                    timeShower.GetComponent<Text>().text = time.ToString();
                }
                else
                {
                    int temp = int.Parse(tempShower.GetComponent<Text>().text);
                    if (temp > 0)
                    {
                        temp -= 50;
                    }
                    tempShower.GetComponent<Text>().text = temp.ToString();
                }
            }
        }

        //开始烧制按钮激活
        public void OnClickSetOver()
        {
            for (int i = 0; i < 5; i++)
            {
                setTempAndTimeImage[i].SetActive(false);
            }
            beginBurnButton.GetComponent<Button>().interactable = true;
        }

        //准备就绪后的烧制开始
        public void OnClickBeginBurn()
        {
            //setView.SetActive(false);
            //isBurning = true;
            ////burnState.allowViewMove = true;
            ////burnState.allowViewRotate = true;
            UIManager.Instance.AddStep();
        }

    }
}