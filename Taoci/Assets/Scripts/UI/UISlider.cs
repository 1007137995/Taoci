using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UISlider : TTUIPage
    {
        public static UISlider Instance;

        public UISlider() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/Slider";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
        }

        public void Wait(string txt)
        {
            transform.Find("slider/Time").GetComponent<Text>().text = txt;
            UIManager.Instance.Delay(Run(10));
        }

        public IEnumerator Run(float time)
        {
            Slider slider = transform.Find("slider").GetComponent<Slider>();
            slider.value = 0;
            while (slider.value < 100)
            {
                slider.value += 2;
                yield return new WaitForSeconds(time / 50);
            }
            UIManager.Instance.AddStep();
        }
    }
}
