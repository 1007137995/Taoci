using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Huoqian : DeviceBase
    {
        public static Huoqian Instance;
        public Vector3 oldPos;
        public Vector3 oldRot;

        private void Awake()
        {
            Instance = this;
            oldPos = transform.localPosition;
            oldRot = transform.localEulerAngles;
        }
    }
}