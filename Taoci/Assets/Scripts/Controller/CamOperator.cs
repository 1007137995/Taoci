using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class CamOperator : MonoBehaviour
    {
        public static CamOperator Instance;
        //先确定相机围绕哪个物体进行旋转，缩放，平移;也就是需要确定相机的父物体
        //先写右键旋转（相机）,确定相机旋转的速度
        public Transform target;
        //旋转的初始角度
        private float x = 0.0f;
        private float y = 0.0f;
        //相机旋转的速率
        private float rSpeed = 10.0f;
        //获取相机Transform对象
        public Transform cam;
        //相机距离目标物体的起始距离(距离设置为负值，是因为相机是在目标物体的正后方)
        private float distance = 0;
        //相机距离的物体的最近和最远距离
        private float minDistance = 0;
        private float maxDistance = 0;
        //初始位置
        private float camPostion_x = 0;
        private float camPostion_y = 0;
        void Awake()
        {
            Instance = this;
            //transform.position = target.position + new Vector3(0, 1.2f, 0);
            transform.rotation = Quaternion.Euler(y, x, 0);
            cam = cam = transform.Find("Main Camera"); ;
            cam.localPosition = new Vector3(0, 0, distance);
        }

        void Update()
        {
            //右键按下
            if (Input.GetMouseButton(0))
            {                
                x += Input.GetAxis("Mouse X") * rSpeed;
                y -= Input.GetAxis("Mouse Y") * rSpeed;
                x = ClampAngle(x, -360, 360);
                y = ClampAngle(y, -70, 70);
                var rotation = Quaternion.Euler(y, x, 0);
                transform.rotation = rotation;
            }
            //中键滚动缩放
            //else if (Input.GetAxis("Mouse ScrollWheel") != 0)
            //{                
            //    distance += Input.GetAxis("Mouse ScrollWheel") * 5;
            //    distance = Mathf.Clamp(distance, maxDistance, minDistance);
            //    cam.localPosition = new Vector3(camPostion_x, camPostion_y, distance);
            //}
            ////中键按下平移
            //if (Input.GetMouseButton(2))
            //{
            //    camPostion_x -= Input.GetAxis("Mouse X") * 0.04f;
            //    camPostion_y -= Input.GetAxis("Mouse Y") * 0.04f;
            //    cam.localPosition = new Vector3(camPostion_x, camPostion_y, distance);
            //}
        }

        static float ClampAngle(float angle, float minAngle, float maxAngle)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, minAngle, maxAngle);
        }
    }
}
