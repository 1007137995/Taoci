
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UniqueID
* 创建日期：2019-03-20 13:26:57
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 唯一ID
    /// </summary>
    [ExecuteInEditMode]
	public class DynamicIds : MonoBehaviour 
	{

        /// <summary>
        /// 分配的动态id的数量
        /// </summary>
        [Header("动态Id数量,修改之后选择ContentMenu菜单设置")]
        [SerializeField]
        private  int dynamicIdCount = 100;

        public int DynamicIdCount
        {
            get
            {
                return dynamicIdCount;
            }
            set
            {
                if (value == dynamicIdCount)
                {
                    return;
                }
                else
                {
                    dynamicIdCount = value;
                    GenerateDynamicIDs();
                }
            }
        }


        /// <summary>
        /// 每次获取一个Id,便+1
        /// </summary>
        public  static int indexOffect=0;

        [Header("已经使用的动态id数量")]
        public int usedCount = 0;

        /// <summary>
        /// 动态id列表集合
        /// </summary>
       // [HideInInspector]
        [SerializeField]
        private   List<ObjectIdentity> dynamicId = new List<ObjectIdentity>();

        /// <summary>
        /// 获取一个动态Id
        /// </summary>
        private  int this[int offect]
        {
            get
            {
                usedCount = offect + 1;
                if (offect < dynamicId.Count)
                {
                    return dynamicId[offect].id;
                }
                else
                {
                    throw new System.IndexOutOfRangeException("动态ID超出列表数值");
                }
            }
        }

        private static DynamicIds instance;
        /// <summary>
        /// 静态实例
        /// </summary>
        private static DynamicIds Instance
        {
            get
            {
                if (instance == null)
                {
                    //不放在awake里初始化，避免为空
                    instance = GameObject.FindObjectOfType<DynamicIds>();
                    if (instance == null)
                    {
                        Debug.Log("请在GameObject[StorageSystom]上添加DynamicIds");
                    }
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private void Awake()
        {
            if (dynamicId.Count == 0)
            {
                Debug.Log("初始化动态Id列表成功");
                GenerateDynamicIDs();
            }
        }

        /// <summary>
        /// 设置动态物体的唯一ID（同时设置UniqueID和objectID）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="inStorage">是否将生成的DataModel添加到存储系统中</param>
        /// <returns></returns>
        public static  int  SetId(GameObject obj,bool inStorage=true)
        {
            DataModelBehaviour data = obj.GetComponent<DataModelBehaviour>();
            if (data == null)
            {
                Debug.Log("当前gameobject未挂载DataModelBehaviour");
                return 0;
            }
            else
            {
                int id = Instance[indexOffect];
                data.DataEntity.objectID=id;
                data.GetComponent<UniqueID>().UniqueId = Instance[indexOffect];

                //下一id
                indexOffect += 1;

                if (inStorage)
                {
                    RestoreSystem.AddDataModel(id, data);
                }
                return id;
            }
        }

        /// <summary>
        /// 设置动态物体的唯一ID（同时设置UniqueID和objectID）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="inStorage">是否将生成的DataModel添加到存储系统中</param>
        /// <returns></returns>
        public static int  SetId(DataModelBehaviour obj, bool inStorage = true)
        {
            if (obj == null)
            {
                Debug.Log("当前DataModelBehaviour为空");
                return 0;
            }
            else
            {
                int id = Instance[indexOffect];
                obj.DataEntity.objectID = id;
                obj.GetComponent<UniqueID>().UniqueId = id;
                //下一id
                indexOffect += 1;
                if (inStorage)
                {
                    RestoreSystem.AddDataModel(id, obj);
                }
                return id;
            }
        }

        /// <summary>
        /// 生成唯一id列表
        /// </summary>
        private   void GenerateDynamicIDs()
        {
            RemoveDynamicIDs();
            for (int i = 0; i < DynamicIdCount; i++)
            {
                ObjectIdentity objectIdentity = new ObjectIdentity();
                ObjectIdentity.RegisterIdentity(objectIdentity);
                dynamicId.Add(objectIdentity);
            }
            Debug.Log("当前动态Id列表数量为：["+dynamicId.Count+"]");
        }

        /// <summary>
        /// 删除唯一id列表
        /// </summary>
        private   void RemoveDynamicIDs()
        {
            for (int i = 0; i < dynamicId.Count; i++)
            {
                ObjectIdentity.UnregisterIdentity(dynamicId[i]);
            }
            dynamicId.Clear();
        }


        /// <summary>
        /// 物体被删除之后释放已使用的id
        /// </summary>
        /// <param name="id"></param>
        public   void ReleaseUsedId(int id)
        {
            for (int i = 0; i < dynamicId.Count; i++)
            {
                //如果包含这个id，表明当前的id是动态id
                if (dynamicId[i].id == id)
                {
                    if (indexOffect > 0)
                    {
                        indexOffect -= 1;
                    }
                    else if (indexOffect < 0)
                    {
                        Debug.Log("Id有异常：["+id+"]");
                    }
                    break;
                }
            }
            usedCount = indexOffect;
        }

#if UNITY_EDITOR
        [ContextMenu("修改动态Id数量")]
        public void SetDynamicIDCount()
        {
            //  GenerateDynamicIDs();
            int count = dynamicIdCount;
            dynamicIdCount = 0;
            DynamicIdCount = count;
        }

        /// <summary>
        /// 删除组件回调，清空已注册的id
        /// </summary>
        [ContextMenu("Remove Component")]
        public void OnRemoveComponent()
        {
            RemoveDynamicIDs();
            UnityEditor.EditorApplication.delayCall = delegate () {
                DestroyImmediate(this);
            };

        }
#endif
    }
}

