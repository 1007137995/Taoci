using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TaoCi
{
    public class QuestionController : MonoBehaviour
    {
        private Text queText;
        private ToggleGroup tg;
        public List<Toggle> toggle = new List<Toggle>();
        private QuestionData.Que qaq;
        private string chooce;
        private ScoreInfo scoreInfo;
        private bool isright = true;

        void Awake()
        {
            QuestionData.AddQuestion();
            queText = transform.Find("QuestionText").GetComponent<Text>();
            tg = transform.Find("ToggleGroup").GetComponent<ToggleGroup>();
            toggle.Clear();
            for (int i = 0; i < tg.transform.childCount; i++)
            {
                toggle.Add(tg.transform.GetChild(i).GetComponent<Toggle>());
            }
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void GetQuestion(int index)
        {
            Time.timeScale = 0;
            qaq = QuestionData.QAQ[index];
            queText.text = qaq.question.ToString();
            foreach (Toggle item in toggle)
            {
                item.gameObject.SetActive(false);
            }
            for (int i = 0; i < qaq.toggle.Count; i++)
            {
                if (qaq.toggle[i] != "" || qaq.toggle[i] != null)
                {
                    toggle[i].gameObject.SetActive(true);
                    toggle[i].transform.Find("Label").GetComponent<Text>().text = qaq.toggle[i];
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
            foreach (Toggle go in toggle)
            {
                if (go.isOn == true)
                {
                    chooce += go.name;
                }
            }
            Debug.Log(chooce);
            if (chooce.CompareTo(qaq.answer) == 0)
            {
                scoreInfo = new ScoreInfo(qaq.score, qaq.question, qaq.answer, true);
            }
            else
            {
                scoreInfo = new ScoreInfo(0, qaq.question, qaq.answer, false);
            }
            return scoreInfo;
            //chooce = "";
            //foreach (Toggle go in toggle)
            //{
            //    if (go.isOn == true)
            //    {
            //        chooce += go.name + ",";
            //    }
            //}
            //scoreInfo = QuestionData.Check(qaq, chooce);
            //return scoreInfo.result;
        }

        public void Clear()
        {
            foreach (Toggle go in toggle)
            {
                go.isOn = false;
            }
        }
    }
}
