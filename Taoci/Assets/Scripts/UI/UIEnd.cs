using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Com.Rainier.ZC_Frame;

namespace TinyTeam.UI
{
    public class UIEnd : TTUIPage
    {
        public static UIEnd Instance;

        public UIEnd() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "UIPrefab/End";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            transform.Find("Redo").GetComponent<Button>().onClick.AddListener(delegate
            {
                ScoreInfo.ClearScoreInfo();
                SceneManager.LoadScene("Main");
            });
        }
    }
}