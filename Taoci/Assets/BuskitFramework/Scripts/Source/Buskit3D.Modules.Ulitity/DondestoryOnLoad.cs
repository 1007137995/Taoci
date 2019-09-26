/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：RainierUlitity
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：跳转场景不销毁
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/
using UnityEngine;
using System.Collections.Generic;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 跳转场景不销毁
    /// </summary>
    public class DondestoryOnLoad:MonoBehaviour
    {
        //加载场景时不销毁的物体
        public List<GameObject> DontDestroyObjects = new List<GameObject>();

        //是否已经存在DontDestroy的物体
        private static bool isExist;

        /// <summary>
        /// Unity Method
        /// </summary>
        void Awake()
        {
            if (!isExist)
            {
                DontDestroyObjects.Add(gameObject);
                for (int i = 0; i < DontDestroyObjects.Count; i++)
                {
                    //如果第一次加载，将这些物体设为DontDestroy
                    DontDestroyOnLoad(DontDestroyObjects[i]);
                }
                isExist = true;
            }
            else
            {
                for (int i = 0; i < DontDestroyObjects.Count; i++)
                {
                    //如果已经存在，则删除重复的物体
                    DestroyImmediate(DontDestroyObjects[i]);
                }
            }

            
        }
    }
}

