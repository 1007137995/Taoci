using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi.Chuantong
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        public int step = 0;
        private StepManager stepManager = null;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
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