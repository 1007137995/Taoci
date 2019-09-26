using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UISingleBtn : TTUIPage
    {
        public static UISingleBtn Instance;
        public bool b = true;

        public UISingleBtn() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
        {
            uiPath = "UIPrefab/SingleBtn";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            transform.Find("PaiyankouBtn").GetComponent<Button>().onClick.AddListener(() => UIManager.Instance.AddStep());
            transform.Find("EffectBtn").GetComponent<Button>().onClick.AddListener(() => {
                Lumen.Instance.gameObject.SetActive(!Lumen.Instance.gameObject.activeSelf);
                if (b)
                {
                    b = false;
                    transform.Find("PaiyankouBtn").gameObject.SetActive(true);
                }                
            });
            transform.Find("HelpBtn").GetComponent<Button>().onClick.AddListener(() => transform.Find("Help").gameObject.SetActive(true));
            transform.Find("Help/Close").GetComponent<Button>().onClick.AddListener(() => transform.Find("Help").gameObject.SetActive(false));
            transform.Find("PaiyankouBtn").gameObject.SetActive(false);
            transform.Find("EffectBtn").gameObject.SetActive(false);
            transform.Find("HelpBtn").gameObject.SetActive(false);
        }
    }
}
