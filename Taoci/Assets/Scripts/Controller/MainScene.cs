using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TinyTeam.UI;

namespace TaoCi
{
    public class MainScene : MonoBehaviour
    {
        public string scene;
        public static MainScene Instance;

        public GameObject chuantong;
        public GameObject dingdian;
        public GameObject dianchai;
        public GameObject yanshao;

        void Awake()
        {
            Instance = this;
            TTUIPage.ShowPage<UIMain>();
            if (ScoreSave.Instance == null)
            {
                Instantiate(Resources.Load("ScoreSave"));
            }
        }

        public void GoScene()
        {
            SceneManager.LoadScene(scene);
        }
    }
}