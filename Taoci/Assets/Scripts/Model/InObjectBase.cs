using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class InObjectBase : DeviceBase
    {
        public TaociLayer layer;
        protected Transform handPos;
        protected Vector3 oldPos;
        protected Vector3 oldRot;
        public Vector3[] aimPos = new Vector3[3];
        protected Transform yaoche;
        protected Transform parentPos;
    }
}