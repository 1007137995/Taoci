using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public enum QType
    {
        TEXT,
        TEXTURE,
        VIDEO
    }

    public class QuestionData
    {
        public struct Que
        {
            public int id;
            public QType type;
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
            que.id = 3001001;
            que.type = QType.TEXT;
            que.one = false;
            que.toggle = new List<string>();
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.toggle.Add("");
            que.question = "1.（多选）经评估，您认为该患者存在哪些引起压力性损伤的高危因素？";
            que.toggle[0] = "A.摩擦力";
            que.toggle[1] = "B.大小便失禁";
            que.toggle[2] = "C.自主运动能力下降";
            que.toggle[3] = "D.营养不良";
            que.toggle[4] = "E.高龄";
            que.answer = "ACDE";
            que.shuoming = "【ACDE】根据护理评估结果，该患者不存在大小便失禁的高危因素。";
            que.qaudio = Resources.Load<AudioClip>("ZJW/Audio/3-2-11");
            que.raudio = Resources.Load<AudioClip>("ZJW/Audio/5-1-2");
            que.waudio = Resources.Load<AudioClip>("ZJW/Audio/5-1-3");
            que.score = 4;
            qaq.Add(que.id, que);
        }
    }
}
