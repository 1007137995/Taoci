﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Fire : MonoBehaviour
    {
        public static Fire Instance;
        private GameObject littleFire;
        private GameObject inFire;
        private GameObject outFire;

        private void Awake()
        {
            Instance = this;
            littleFire = transform.Find("LittleFire").gameObject;
            inFire = transform.Find("Fire").gameObject;
            outFire = transform.Find("FireOut").gameObject;
        }

        public void ChangeLittleFire(bool b)
        {
            littleFire.SetActive(b);
        }

        public void ChangeInFire(bool b)
        {
            inFire.SetActive(b);
        }

        public void ChangeOutFire(bool b)
        {
            outFire.SetActive(b);
        }
    }
}
