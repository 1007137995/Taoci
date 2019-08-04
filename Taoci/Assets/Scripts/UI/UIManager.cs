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
        private StepManager stepManager = null;

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
    }
}