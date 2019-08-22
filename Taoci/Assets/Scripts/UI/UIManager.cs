using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

namespace TaoCi
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        public int step = 0;
        public StepManager stepManager = null;
        private int index = 0;

        private void Awake()
        {
            Instance = this;
            QuestionData.AddQuestion();
        }

        private void OnEnable()
        {
            TTUIPage.ShowPage<UITitle>();
            TTUIPage.ClosePage<UITitle>();
            TTUIPage.ShowPage<UICProcess>();
            TTUIPage.ClosePage<UICProcess>();
            TTUIPage.ShowPage<UIIntroduce>();
            TTUIPage.ClosePage<UIIntroduce>();
            TTUIPage.ShowPage<UIIntroduceBtn>();
            TTUIPage.ClosePage<UIIntroduceBtn>();
            TTUIPage.ShowPage<UITip>();
            TTUIPage.ClosePage<UITip>();
            TTUIPage.ShowPage<UISetValue>();
            TTUIPage.ClosePage<UISetValue>();
            TTUIPage.ShowPage<UIQuestion>();
            TTUIPage.ClosePage<UIQuestion>();
            TTUIPage.ShowPage<UISingleBtn>();
            TTUIPage.ClosePage<UISingleBtn>();
            TTUIPage.ShowPage<UIPicture>();
            TTUIPage.ClosePage<UIPicture>();
            TTUIPage.ShowPage<UISlider>();
            TTUIPage.ClosePage<UISlider>();
            TTUIPage.ShowPage<UIEnd>();
            TTUIPage.ClosePage<UIEnd>();
        }

        private void Start()
        {
            AddStep();
        }

        private void LateUpdate()
        {
            step = stepManager.LocalStep;
        }

        public void GetStepManager(StepManager sm)
        {
            stepManager = sm;
        }

        public void AddStep()
        {
            stepManager.LocalStepAdd(); 
        }

        public void SetStep(int stepIndex)
        {
            stepManager.SetStep(stepIndex);
        } 

        public Coroutine Delay(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void EndView()
        {
            index++;
            if (index == 3)
            {
                index = 0;
                AddStep();
            }
        }
    }
}