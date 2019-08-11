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
        public Material jiazi;
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
            Debug.Log(11);
            jiazi.color = Color.red;
            originTaoci.color = Color.red;
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
            sequence.Join(DOTween.To(()=> fireLight.range, x => fireLight.intensity = x, 0, 10));
            sequence.OnComplete(delegate
            {
                UIManager.Instance.AddStep();
            });
        }
    }
}
