using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class ShaderColorController : MonoBehaviour
    {
        public static ShaderColorController Instance;
        public List<GameObject> taoci = new List<GameObject>();
        public List<Sprite> sprites = new List<Sprite>();
        public Material jiazi;
        public Material wall;
        public Material originTaoci;
        public Material newTaoci;
        public Light fireLight;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            //Burn();
            //Cool();
        }

        public void Burn()
        {
            jiazi.color = Color.red;
            originTaoci.color = Color.red;
            wall.color = new Color(1,0.4f,0.4f);
        }

        public void Cool()
        {
            originTaoci.color = Color.white;
            foreach (GameObject item in taoci)
            {
                item.transform.GetComponent<Renderer>().material = newTaoci;
            }
            newTaoci.color = Color.red;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(newTaoci.DOColor(Color.white, 10));
            sequence.Join(jiazi.DOColor(Color.white, 10));
            sequence.Join(wall.DOColor(Color.white, 10));
            sequence.Join(DOTween.To(()=> fireLight.range, x => fireLight.intensity = x, 0, 10));
            sequence.OnComplete(delegate
            {
                UIManager.Instance.AddStep();
            });
        }

        public void Reset()
        {
            jiazi.color = Color.white;
            originTaoci.color = Color.white;
            wall.color = Color.white;
        }
    }
}
