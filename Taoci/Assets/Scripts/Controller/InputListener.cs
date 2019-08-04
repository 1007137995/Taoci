/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：压疮
* 类 名 称：InputListener
* 创建日期：2018-08-06 10:02:57
* 作者名称：zjw
* CLR 版本：4.0.30319.42000
* 功能描述：输入监听
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TaoCi
{
    public class InputListener : MonoBehaviour
    {

        public Camera cam;
        private Ray _ray;
        private RaycastHit _hitInfo;

        void Start()
        {

        }

        void Update()
        {
            OnMouseLeftClicking();
        }

        /// <summary>
        /// 左键点击
        /// </summary>
        private void OnMouseLeftClicking()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hitInfo))
                {
                    if (_hitInfo.collider.GetComponent<ObjectBase>())
                    {
                        for (int i = 0; i < _hitInfo.collider.GetComponents<ObjectBase>().Length; i++)
                        {
                            //Debug.Log(_hitInfo.collider.name);
                            _hitInfo.collider.GetComponents<ObjectBase>()[i].OnMouseLeftClick();
                        }
                    }
                }
            }
        }
    }
}

