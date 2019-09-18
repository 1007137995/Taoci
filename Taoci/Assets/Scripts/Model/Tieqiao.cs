using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class Tieqiao : DeviceBase
    {
        public static Tieqiao Instance;
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