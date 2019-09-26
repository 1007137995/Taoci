/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：PrefabLogic
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述： 管理预制体的生成，初始化
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 管理预制体的生成，初始化,如果是还原，需要区分
    /// </summary>
    [DisallowMultipleComponent]
    [DataModelSequence(2)]
    public class ReplayManager : DataModelBehaviour, IStorage
    {
        /// <summary>
        /// 所有需要动态生成的物体
        /// </summary>
        public List<GameObject> allPrefabs = new List<GameObject>();

        /// <summary>
        /// 记录生成过的预制体的所在的场景名字，Id编号，预设名字
        /// </summary>
        private static List<string> _sceneIdNameOfPrefab = new List<string>();

        /// <summary>
        /// 使用键值对存储预制体的名字和实体，方便查找
        /// </summary>
        private  static  Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>();

        /// <summary>
        /// 生成的预制体编号也是DataEntity的编号
        /// </summary>
        private static  int number = 0;

        /// <summary>
        /// Unity Method
        /// </summary>
        private void Awake()
        {
            ReplayEntity data = new ReplayEntity();
            this.DataEntity = data;
            Watch(this);
          
        }

        /// <summary>
        /// Unity Method
        /// </summary>
        protected override void Start()
        {
            base.Start();
            foreach (var item in allPrefabs)
            {
                if (_prefabs.ContainsKey(item.name))
                {
#if UNITY_EDITOR
                    Debug.Log("allPrefabs 预制体有重复");
#endif
                    return;
                }
                _prefabs.Add(item.name, item);
            }
        }

        /// <summary>
        /// 实例化物体
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static GameObject GetInstance(string name,Vector3 position)
        {
            if (!_prefabs.ContainsKey(name))
            {
#if UNITY_EDITOR
                Debug.Log("can't find the name of prefab:["+name+"]");
#endif 
            }
            GameObject go= Instantiate(_prefabs[name],position,Quaternion.identity) as GameObject;
            return go;
        }

        /// <summary>
        /// 将动态生成的物体，注册到回放和还原系统当中
        /// </summary>
        /// <param name="obj"></param>
        public static void RegisterPrefab(GameObject obj)
        {
            number += 1;

            if (obj.GetComponent<DataModelBehaviour>() != null)
            {
                DataModelBehaviour dataModel = obj.GetComponent<DataModelBehaviour>();
                int id = DynamicIds.SetId(dataModel);
            }
            string sceneName = SceneManager.GetActiveScene().name;
           
            _sceneIdNameOfPrefab.Add(sceneName+"="+number.ToString() + "=" + obj.name.Split('(')[0]);
           
        }

        /// <summary>
        /// 场景还原前，预制体准备操作
        /// </summary>
        public override void LoadStorageData()
        {
            ReplayEntity data = (ReplayEntity)DataEntity;

            //多次点击 还原
            if (data.sceneIdNameOfPrefab.Count ==_sceneIdNameOfPrefab.Count)
            {
                return;
            }
            _sceneIdNameOfPrefab.Clear();

            data.sceneIdNameOfPrefab.ForEach(p => _sceneIdNameOfPrefab.Add(p));
          

            string sceneName = SceneManager.GetActiveScene().name;

            //生成所有的预制体
            for (int i = 0; i < data.sceneIdNameOfPrefab.Count; i++)
            {
                
                //生成属于当前场景的预制体
                if (data.sceneIdNameOfPrefab[i].Split('=')[0].Equals(sceneName))
                {
                    string name = data.sceneIdNameOfPrefab[i].Split('=')[2];
                    GameObject go = GetInstance(name, Vector3.zero);
                    RegisterPrefab(go);

                    //DataModelBehaviour dataModel = go.GetComponent<DataModelBehaviour>();
                    //if (dataModel != null)
                    //{
                    //    RestoreSystem.AddDataModel(dataModel.DataEntity.objectID, dataModel);
                    //}
                   
                }     
            }
            
        }
        /// <summary>
        /// 保存
        /// </summary>
        public  override void SaveStorageData()
        {
            //先写入预制体数据
            ReplayEntity data = (ReplayEntity)this.DataEntity;
            data.sceneIdNameOfPrefab.Clear();
            _sceneIdNameOfPrefab.ForEach(p => data.sceneIdNameOfPrefab.Add(p));
            //保存场景信息
            data.sceneName = SceneManager.GetActiveScene().name;

        }
    }

    /// <summary>
    /// 预制体实体
    /// </summary>
    public class ReplayEntity : BaseDataModelEntity
    {
        /// <summary>
        /// 实验中生成过的prefab的id&name
        /// </summary>
        public List<string> sceneIdNameOfPrefab = new List<string>();

        /// <summary>
        /// 场景名
        /// </summary>
        public string sceneName;
    }
}

