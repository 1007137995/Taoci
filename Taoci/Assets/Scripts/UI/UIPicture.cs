using System.Collections;
using System.Collections.Generic;
using TaoCi;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTeam.UI
{
    public class UIPicture : TTUIPage
    {
        public static UIPicture Instance;
        private int index;

        public UIPicture() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "UIPrefab/Picture";
        }

        public override void Awake(GameObject go)
        {
            Instance = this;
            index = 0;
            transform.Find("EndBtn").GetComponent<Button>().onClick.AddListener(() => {
                if (index == 3)
                {
                    UIManager.Instance.AddStep();
                }
                TTUIPage.ClosePage(this);
            });
            
            //transform.Find("LastBtn").GetComponent<Button>().onClick.AddListener(() => Last());
            //transform.Find("NextBtn").GetComponent<Button>().onClick.AddListener(() => Next());
        }

        public void SetImg(Sprite sprite)
        {
            transform.Find("Image").GetComponent<Image>().overrideSprite = sprite;
            index++;
        }

        //public void Last()
        //{
        //    if (index > 0)
        //    {
        //        index--;
        //        transform.Find("Image").GetComponent<Image>().overrideSprite = ShaderColorController.Instance.sprites[index];
        //    }            
        //}

        //public void Next()
        //{
        //    if (index < ShaderColorController.Instance.sprites.Count - 1)
        //    {
        //        index++;
        //        transform.Find("Image").GetComponent<Image>().overrideSprite = ShaderColorController.Instance.sprites[index];
        //    }            
        //}
    }
}