using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class ScoreSave : MonoBehaviour
    {
        public static ScoreSave Instance;
        private static int allScore = 0;
        private static bool cdyb = false;
        private static bool ctyb = false;
        private static bool ddyb = false;
        private static bool ysyb = false;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public static int AddScore(string scene, int score)
        {
            switch (scene)
            {
                case "CDYB":
                    if (cdyb == false)
                    {
                        allScore += score;
                        cdyb = true;
                    }
                    break;
                case "CTYB":
                    if (ctyb == false)
                    {
                        allScore += score;
                        ctyb = true;
                    }
                    break;
                case "DDYB":
                    if (ddyb == false)
                    {
                        allScore += score;
                        ddyb = true;
                    }
                    break;
                case "YSYB":
                    if (ysyb == false)
                    {
                        allScore += score;
                        ysyb = true;
                    }
                    break;
                default:
                    break;
            }
            return allScore;
        }
    }
}