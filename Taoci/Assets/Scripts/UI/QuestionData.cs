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
            public List<string> error;
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
            que.error = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.error.Add("");
            que.error.Add("");
            que.error.Add("");
            que.question = "电窑炉投料口用途：";
            que.toggle[0] = "A.用于排除窑内烟气和二氧化碳";
            que.toggle[1] = "B.用于观察窑内温度和火势";
            que.toggle[2] = "C.用于向窑内投放熏窑物品";
            que.error[0] = "选择错误";
            que.error[1] = "选择错误";
            que.error[2] = "选择正确";
            que.answer = "C";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 3;
            qaq.Add(que.id, que);

            que.id = 2;
            que.one = true;
            que.toggle = new List<string>();
            que.error = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.error.Add("");
            que.error.Add("");
            que.error.Add("");
            que.question = "电窑炉观火口用途：";
            que.toggle[0] = "A.用于观察窑内温度和火势";
            que.toggle[1] = "B.用于排除窑内烟气和二氧化碳";
            que.toggle[2] = "C.用于向窑内投放熏窑物品";
            que.error[0] = "选择正确";
            que.error[1] = "选择错误";
            que.error[2] = "选择错误";
            que.answer = "A";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 3;
            qaq.Add(que.id, que);

            que.id = 3;
            que.one = true;
            que.toggle = new List<string>();
            que.error = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.error.Add("");
            que.error.Add("");
            que.error.Add("");
            que.question = "电窑炉排烟口用途：";
            que.toggle[0] = "A.用于排除窑内多余烟气和二氧化碳";
            que.toggle[1] = "B.用于观察窑内温度和火势";
            que.toggle[2] = "C.用于向窑内投放熏窑物品";
            que.error[0] = "选择正确";
            que.error[1] = "选择错误";
            que.error[2] = "选择错误";
            que.answer = "A";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 3;
            qaq.Add(que.id, que);

            que.id = 1004007;
            que.one = true;
            que.toggle = new List<string>();
            que.error = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.error.Add("");
            que.error.Add("");
            que.error.Add("");
            que.question = "当窑温降至__℃以下即可出窑：";
            que.toggle[0] = "A.70℃";
            que.toggle[1] = "B.170℃";
            que.toggle[2] = "C.270℃";
            que.error[0] = "选择正确";
            que.error[1] = "出窑温度过高，坭兴陶易发生冷裂，烧制失败。";
            que.error[2] = "出窑温度过高，坭兴陶发生冷裂，烧制失败。";
            que.answer = "A";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 2;
            qaq.Add(que.id, que);

            que.id = 2002004;
            que.one = true;
            que.toggle = new List<string>();
            que.error = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.error.Add("");
            que.error.Add("");
            que.error.Add("");
            que.question = "在立好一层马蹄柱后，应该摆放哪种物品：";
            que.toggle[0] = "A.坭兴陶坯品";
            que.toggle[1] = "B.高温硼板";
            que.toggle[2] = "C.木柴";
            que.error[0] = "此处是火膛，不能放置坭兴陶坯品。";
            que.error[1] = "选择正确";
            que.error[2] = "此时不能放置木柴。";
            que.answer = "B";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 2;
            qaq.Add(que.id, que);
            
            que.id = 3004004;
            que.one = true;
            que.toggle = new List<string>();
            que.error = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.error.Add("");
            que.error.Add("");
            que.error.Add("");
            que.question = "应该放入多少海盐：";
            que.toggle[0] = "A.250g";
            que.toggle[1] = "B.750g";
            que.toggle[2] = "C.1250g";
            que.error[0] = "投量过少，不能产生釉面窑变。";
            que.error[1] = "选择正确";
            que.error[2] = "投量过多，氯化钠腐蚀坭兴陶坯品，导致变形或坍塌。";
            que.answer = "B";
            que.shuoming = "";
            que.qaudio = null;
            que.raudio = null;
            que.waudio = null;
            que.score = 3;
            qaq.Add(que.id, que);
        }
    }
}
