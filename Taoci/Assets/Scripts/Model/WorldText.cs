using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class WorldText : MonoBehaviour
    {
        public GameObject cam;

        private void LateUpdate()
        {
            transform.LookAt(cam.transform);
        }
    }
}
