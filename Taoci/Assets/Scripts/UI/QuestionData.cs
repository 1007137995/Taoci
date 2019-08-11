using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class QuestionData
    {
        public struct Que
        {
            public int id;
            public bool one;
            public string question;
            public List<string> toggle;
            public string answer;
            public string shuoming;
            public AudioClip qaudio;
            public AudioClip raudio;
            public AudioClip waudio;
            public int score;
        }

        private static Dictionary<int, Que> qaq = new Dictionary<int, Que>();

        private static Que que = new Que();

        public static Dictionary<int, Que> QAQ { get { return qaq; } set { qaq = value; } }

        /// <summary>
        /// 添加试题
        /// </summary>
        public static void AddQuestion()
        {
            qaq.Clear();

            //
            que.id = 1;
            que.one = true;
            que.toggle = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.question = "电窑炉投料口用途：";
            que.toggle[0] = "A.用于排除窑内烟气和二氧化碳";
            que.toggle[1] = "B.用于观察窑内温度和火势";
            que.toggle[2] = "C.用于向窑内投放熏窑物品";
            que.answer = "C";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 0;
            qaq.Add(que.id, que);

            que.id = 2;
            que.one = true;
            que.toggle = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.question = "电窑炉观火口用途：";
            que.toggle[0] = "A.用于观察窑内温度和火势";
            que.toggle[1] = "B.用于排除窑内烟气和二氧化碳";
            que.toggle[2] = "C.用于向窑内投放熏窑物品";
            que.answer = "A";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 0;
            qaq.Add(que.id, que);

            que.id = 3;
            que.one = true;
            que.toggle = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.question = "电窑炉排烟口用途：";
            que.toggle[0] = "A.用于排除窑内多余烟气和二氧化碳";
            que.toggle[1] = "B.用于观察窑内温度和火势";
            que.toggle[2] = "C.用于向窑内投放熏窑物品";
            que.answer = "A";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 0;
            qaq.Add(que.id, que);

            que.id = 1004007;
            que.one = true;
            que.toggle = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.question = "当窑温降至__℃以下即可出窑：";
            que.toggle[0] = "A.70℃";
            que.toggle[1] = "B.170℃";
            que.toggle[2] = "C.270℃";
            que.answer = "A";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 0;
            qaq.Add(que.id, que);
        }
    }
}
