
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
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 唯一ID
    /// </summary>
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
	public class UniqueID : MonoBehaviour 
	{

        [SerializeField]
        private ObjectIdentity objectIdentity = new ObjectIdentity();

        [HideInInspector]
        public int UniqueId
        {
            get
            {
                return objectIdentity.id;
            }
            set
            {
                objectIdentity.id = (short)value;
            }
        }

        private   void Awake()
        {
           ObjectIdentity.RegisterIdentity(this.objectIdentity);
        }

        private void OnDestroy()
        {
            
            ObjectIdentity.UnregisterIdentity(this.objectIdentity);
        }
#if UNITY_EDITOR
        [MenuItem("Rainier/SetUniqueID")]
        public static void SetUniqueID()
        {
            var allDataModels = Resources.FindObjectsOfTypeAll<DataModelBehaviour>();

            foreach (var item in allDataModels)
            {

                if (item.hideFlags != (HideFlags.NotEditable | HideFlags.HideInHierarchy))
                {
                    if (item.GetComponent<UniqueID>() == null)
                    {
                        item.gameObject.AddComponent<UniqueID>();
                    }
                }
            }
        }
#endif
    }
}

