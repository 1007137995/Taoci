using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class ScoreInfo
    {
        public int score;
        public string info;
        public string answer;
        public bool result;
        public int wrong;
        public static bool iskaohe { get; set; }
        public static List<ScoreInfo> scoreList = new List<ScoreInfo>();
        private static bool instack = false;

        public ScoreInfo() { }

        public ScoreInfo(int Score, string Info, string Answer, bool Result, int Wrong)
        {
            this.score = Score;
            this.info = Info;
            this.answer = Answer;
            this.result = Result;
            this.wrong = Wrong;
        }

        public static void AddSocreInfo(ScoreInfo score)
        {
            foreach (ScoreInfo item in scoreList)
            {
                if (item.info == score.info)
                {
                    instack = true;
                }
            }
            if (instack == false)
            {
                scoreList.Add(score);
            }
            else
            {
                instack = false;
            }
        }

        public static void ClearScoreInfo()
        {
            scoreList.Clear();
        }
    }
}
