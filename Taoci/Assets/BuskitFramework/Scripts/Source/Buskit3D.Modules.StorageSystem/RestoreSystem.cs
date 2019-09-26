/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：RestoreSystem
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：场景恢复逻辑处理
* 修改记录：
* 
******************************************************************************/
using UnityEngine;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using System.Xml;
using Com.Rainier.BusKit.Unity.Modules.DataWatch;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 场景恢复逻辑处理
    /// </summary>
    public class RestoreSystem 
    {
        [Inject]
        IServiceSerializer _serviceSerializer;

        [Inject]
        IServiceCompress _serviceCompress;

        [Inject]
        protected IgcsSystem igcsSystem;

        /// <summary>
        /// 存储所有的DataEntity，并将对应的ObjectID作为key值
        /// </summary>
        private  static Dictionary<int, BaseDataModelEntity> _allEntity = new Dictionary<int, BaseDataModelEntity>();
        protected  static Dictionary<int, BaseDataModelEntity> AllEntity { get { return _allEntity; } private set { _allEntity = value; } }

        /// <summary>
        /// 存储所有的DataModelBehaviour,并将对应的ObjectID作为key值
        /// </summary>
        private static Dictionary<int, DataModelBehaviour> _allDataModel = new Dictionary<int, DataModelBehaviour>();
        protected  static Dictionary<int, DataModelBehaviour> AllDataModel { get { return _allDataModel; } private set { _allDataModel = value; } }


        /// <summary>
        /// 当前状态是否可保存
        /// </summary>
        public static  bool CanSave { get; set; }


#if UNITY_EDITOR
        public string testEntityData=null;
#endif

        /// <summary>
        /// 构造函数
        /// </summary>
        public RestoreSystem()
        {
            CanSave = true;
            InjectService.InjectInto(this);

        }

        /// <summary>
        /// 保存智能批改脚本
        /// </summary>
        public void SaveIgcsData()
        {
            List<BaseDataModelEntity> entities = AllDataModel.Values.Select(p => p.DataEntity).ToList();
            //保持智能批改XML脚本
            XmlElement eleExper = IgcsXmlGenerator.SerializeExprimentInfo(igcsSystem.xmlDocument, igcsSystem.scriptBaseInfo, igcsSystem.experimentInfo);
            XmlElement eleState = IgcsXmlGenerator.SerializeSceneState(igcsSystem.xmlDocument, entities.ToArray());

            eleExper.AppendChild(eleState);
            igcsSystem.xmlDocument.AppendChild(eleExper);

            IgcsXmlGenerator.SaveXmlDocument(igcsSystem.xmlDocument);
        }
    
        /// <summary>
        /// 保存场景
        /// </summary>
        public  void SaveStorageData()
        {     
            //保持实验状态Json
            List<BaseDataModelEntity> entities = new List<BaseDataModelEntity>();
            foreach (var item in AllDataModel)
            {              
                entities.Add(item.Value.DataEntity);
                item.Value.SaveStorageData();
                Save( item.Value.DataEntity);
            }
        }

        /// <summary>
        /// 恢复场景
        /// </summary>
        public  void LoadStorageData() 
        {

            #region 使用标签排序 确定数据恢复的先后顺序,必须等到场景初始化完成之后
            List<DataModelBehaviour> modelWithSequece = new List<DataModelBehaviour>();
            List<DataModelBehaviour> modelNoSequece = new List<DataModelBehaviour>();
            List<int> orderOfId = new List<int>();
            foreach (var item in AllDataModel)
            {
                DataModelSequenceAttribute sequenceAtribute = item.Value.GetType().GetCustomAttribute<DataModelSequenceAttribute>();
                if (sequenceAtribute != null)
                {
                    modelWithSequece.Add(item.Value);
                }
                else
                {
                    modelNoSequece.Add(item.Value);
                }
            }

            IEnumerable<DataModelBehaviour> query = null;
            query = from items in modelWithSequece orderby items.GetType().GetCustomAttribute<DataModelSequenceAttribute>().number select items;
            foreach (var item in query)
            {
                item.OffFireAll();
                Load(item.DataEntity);
                item.LoadStorageData();
                orderOfId.Add(item.DataEntity.objectID);
            }
            foreach (var item in modelNoSequece)
            {
                item.OffFireAll();
                Load(item.DataEntity);
                item.LoadStorageData();
                orderOfId.Add(item.DataEntity.objectID);
            }

            //还原其余的动态生成物体的数据
            foreach (var item in AllDataModel)
            {
                if (orderOfId.Contains(item.Key))
                {
                    continue;
                }
                item.Value.OffFireAll();
      
                Load(item.Value.DataEntity);
              
                item.Value.LoadStorageData();
            }

            #endregion
            #region oldway
            //SceneLoader sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
            //Load(sceneLoader.DataEntity);
            //sceneLoader.LoadStorageData();
            ////先给预制体数据实体赋值，生成对应的预制体
            //ReplayManager prefabManager = GameObject.FindObjectOfType<ReplayManager>();
            //Load(prefabManager.DataEntity);
            //prefabManager.LoadStorageData();

            //foreach (var item in AllDataModel)
            //{

            //    if (item.Key == prefabManager.DataEntity.UniqueId)
            //        continue;
            //    if (item.Key == sceneLoader.DataEntity.UniqueId)
            //        continue;
            //    item.Value.OffFireAll();
            //    Load(item.Value.DataEntity);
            //    item.Value.LoadStorageData();
            //    Debug.Log(item.Value);
            //}
            #endregion
        }

        /// <summary>
        /// 打开属性变化事件侦听
        /// </summary>
        public void OnFireAllEvent()
        {
            List<ViewModelBehaviour> vms = new List<ViewModelBehaviour>();
            foreach (var item in AllDataModel)
            {
                //Vm单独处理一下
                if (item.Value is ViewModelBehaviour)
                {
                    ViewModelBehaviour vm = item.Value as ViewModelBehaviour;
                    vm.ReWatch(vm);
                }
                item.Value.OnFireAll();
            }
        }

        /// <summary>
        /// 将所有的Entity存到字典当中
        /// </summary>
        /// <param name="entity"></param>
        public void Save(BaseDataModelEntity entity)
        {
            //保存ID=DataEntity到字典当中
            if (!AllEntity.ContainsKey(entity.objectID))
            {
                AllEntity.Add(entity.objectID, entity);
            }
        }

        /// <summary>
        /// 还原所有的entity
        /// </summary>
        /// <param name="entity"></param>
        public void Load( BaseDataModelEntity entity)
        {
            
            //如果在字典中查找不到，找不到的一定不是动态创建生成的（动态生成会立刻写入ID）
            if (!AllEntity.ContainsKey(entity.objectID))
            {
                //如果还不包含，则return
                if (!AllEntity.ContainsKey(entity.objectID))
                {
#if UNITY_EDITOR
                    Debug.Log("can't find entity with objectID: [" + entity.objectID +"___"+ entity.GetType()+ "],is not storagedata");
#endif
                    return;
                }

            }
            //深拷贝,进行数据还原

                string str = _serviceSerializer.SerializerObject(AllEntity[entity.objectID]);
                object tmpEntity = _serviceSerializer.DeSerializerObject(str);

                PropertyInfo[] propertyInfos = tmpEntity.GetType().GetProperties();
                FieldInfo[] fieldInfos = tmpEntity.GetType().GetFields();

                PropertyInfo[] propertyInfos1 = entity.GetType().GetProperties();
                FieldInfo[] fieldInfos1 = entity.GetType().GetFields();

                for (int i = 0; i < propertyInfos1.Length; i++)
                {

                    for (int j = 0; j < propertyInfos1.Length; j++)
                    {
                        if (propertyInfos1[i].Name.Equals(propertyInfos[j].Name))
                        {
                             propertyInfos1[i].SetValue(entity, propertyInfos[j].GetValue(tmpEntity));
                        } 
                    }
                }

                for (int i = 0; i < fieldInfos1.Length; i++)
                {

                    for (int j = 0; j < fieldInfos1.Length; j++)
                    {
                        
                        if (fieldInfos1[i].Name.Equals(fieldInfos[j].Name))
                        {
                            fieldInfos1[i].SetValue(entity, fieldInfos[j].GetValue(tmpEntity));
                        }
                       
                    }
                    
                }
            
        }

        /// <summary>
        /// 序列化为字符串
        /// </summary>
        /// <returns></returns>
        public string  DataToString()
        {
            string data = _serviceSerializer.SerializerObject(AllEntity);
            byte[] rawData = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] zipData = _serviceCompress.Compress(rawData);

#if UNITY_EDITOR
            testEntityData = data;
#endif
            return System.Convert.ToBase64String(zipData);
        }

        /// <summary>
        /// 反序列数据
        /// </summary>
        /// <param name="base64String"></param>
        public void StringToData(string base64String)
        {
            byte[] zipData = System.Convert.FromBase64String(base64String);
            byte[] rawData = _serviceCompress.DeCompress(zipData);
            string  data = System.Text.Encoding.UTF8.GetString(rawData);
            AllEntity = _serviceSerializer.DeSerializerObject<Dictionary<int, BaseDataModelEntity>>(data);
        }
    
        /// <summary>
        /// 添加DataModelBehaviour
        /// </summary>
        /// <param name="dataModelBehaviour"></param>
        public static void AddDataModel(int id, DataModelBehaviour dataModelBehaviour)
        {
            if (!AllDataModel.ContainsKey(id))
            {
                AllDataModel.Add(id, dataModelBehaviour);
            }
        }

        /// <summary>
        /// 获取对应ID的数据实体
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public static BaseDataModelEntity GetEntity(int objectID)
        {
            DataModelBehaviour dm = null;
            AllDataModel.TryGetValue(objectID, out dm);
            if(dm != null)
            {
                return dm.DataEntity;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 物体销毁时删除DataModel
        /// </summary>
        /// <param name="objectID"></param>
        public static void RemoveDataModel(int objectID)
        {
            if (AllDataModel.ContainsKey(objectID))
            {
                AllDataModel.Remove(objectID);
            }
           
        }

        /// <summary>
        /// 跳转场景时，删除字典内容
        /// </summary>
        public static void ClearDataModel()
        {
            AllDataModel.Clear();
        }

    }
}
