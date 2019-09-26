/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ModelObject
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：模型对象
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using System.Reflection;
using Com.Rainier.BusKit.Unity.Modules.DataWatch;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 模型对象
    /// </summary>
    [RequireComponent(typeof(UniqueID)),DisallowMultipleComponent]
    public class DataModelBehaviour : MonoBehaviour,IStorage
    {
        /// <summary>
        /// 观察表
        /// </summary>
        protected WatchTable watchTable = new WatchTable();

        /// <summary>
        /// 数据实体对象
        /// </summary>
        public BaseDataModelEntity DataEntity = new EmptyEntity();

        /// <summary>
        /// 分配动态id的唯一实例
        /// </summary>
        protected DynamicIds DynamicIdSupport;
        
    

        /// <summary>
        /// 监视自身，绑定ID 添加自身到Record
        /// </summary>
        protected virtual void Start()
        {
            //如果当前ID是-1，即不是预制体，设置对应的ID
            if (DataEntity.objectID == -1)
            {
                DataEntity.objectID = GetComponent<UniqueID>().UniqueId;
            }

            //取消对TransInfo事件的触发
            OffFire(this.DataEntity,"objectID");
            OffFire(this.DataEntity, "transInfo");
            DynamicIdSupport = GameObject.FindObjectOfType<DynamicIds>();
            if (DynamicIdSupport == null)
            {
                Debug.Log("请在GameObject[StorageSystom]上添加DynamicIds");
            }
        }

        /// <summary>
        /// 当被观察对象发出事件后，通过此函数处理业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public virtual void OnEvent(PropertyMessage evt)
        {
            
            //获取所有Logic组件并执行旋转更新操作
            foreach (LogicBehaviour logic in GetComponents<LogicBehaviour>())
            {
                //分发消息
                logic.ProcessLogic(evt);
            }

            Type type = evt.TargetObject.GetType();
            string[] realProName = evt.PropertyName.Split(new char[1] { '#' });
            if (type.GetField(realProName[0]).GetCustomAttribute<NoStorage>() == null)
            {
                RecordSystem.Instance.Record(evt);
            }
        }

        /// <summary>
        /// 忽略某个属性的事件响应
        /// </summary>
        /// <param name="target"></param>
        /// <param name="propertyName"></param>
        public void OffFire(BaseDataModelEntity target, string propertyName)
        {
            watchTable.OffFire(target, propertyName);
        }

        /// <summary>
        /// 关闭所有已监视属性的事件响应
        /// </summary>
        public void OffFireAll()
        {
            foreach (var item in watchTable.Items)
            {
                FieldInfo fieldInfo= item.Target.GetType().GetField(item.Path);
                PropertyInfo propertyInfo = item.Target.GetType().GetProperty(item.Path);

                if (fieldInfo != null&& fieldInfo.GetCustomAttribute<RestoreFireLogic>() != null)
                {
                    RestoreFireLogic state = fieldInfo.GetCustomAttribute<RestoreFireLogic>();
                    switch (state.state)
                    {
                        case "Self":
                            if (!item.Target.Equals(this.DataEntity))
                            {
                                item.CanFire = false; 
                            }
                            break;
                        case "Other":
                            if (item.Target.Equals(this.DataEntity))
                            {
                                item.CanFire = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (propertyInfo!=null &&propertyInfo.GetCustomAttribute<RestoreFireLogic>()!=null)
                {
                    RestoreFireLogic state = propertyInfo.GetCustomAttribute<RestoreFireLogic>();
                    switch (state.state)
                    {
                        case "Self":
                            if (!item.Target.Equals(this.DataEntity))
                            {
                                item.CanFire = false;
                            }
                            break;
                        case "Other":
                            if (item.Target.Equals(this.DataEntity))
                            {
                                item.CanFire = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    item.CanFire = false;
                }           
            }
        }

        /// <summary>
        /// 打开已忽略的某个属性的事件响应
        /// </summary>
        /// <param name="target"></param>
        /// <param name="propertyName"></param>
        public void OnFire(BaseDataModelEntity target, string propertyName)
        {
            watchTable.OnFire(target, propertyName);
        }

        /// <summary>
        /// 打开所有已忽略的属性的事件响应
        /// </summary>
        public void OnFireAll()
        {
            watchTable.OnFireAll();
            //取消对TransInfo事件的触发
            OffFire(this.DataEntity, "transInfo");
            //取消对ID号的监听
            OffFire(this.DataEntity, "objectID");
        }

        /// <summary>
        /// 观察另外一个对象
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Watch(DataModelBehaviour obj)
        {
            if(obj.DataEntity == null)
            {
                throw new BindingException("The DataEntity is null.");
            }
            watchTable.Watch(obj.DataEntity, "*", OnEvent);
        }

        /// <summary>
        /// 观察另外一个对象
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Watch(BaseDataModelEntity entity)
        {
            if (entity == null)
            {
                throw new BindingException("The DataEntity is null.");
            }
            watchTable.Watch(entity, "*", OnEvent);
        }

        /// <summary>
        /// 观察另外一个对象的指定字段
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyPath"></param>
        public virtual void Watch(BaseDataModelEntity entity,string propertyPath)
        {
            if (entity == null)
            {
                throw new BindingException("The DataEntity is null.");
            }
            watchTable.Watch(entity, propertyPath, OnEvent);
        }

        /// <summary>
        /// 观察另一个对象并指明回调函数
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callback"></param>
        public virtual void Watch(DataModelBehaviour obj,DelOnValueChanged callback)
        {
            if (obj.DataEntity == null)
            {
                throw new BindingException("The DataEntity is null.");
            }
            watchTable.Watch(obj.DataEntity, "*", callback);
        }

        /// <summary>
        /// 重新watch一个数据实体对象
        /// </summary>
        /// <param name="obj"></param>
        public virtual void ReWatch(DataModelBehaviour obj)
        {
            Unwatch(obj);
            Watch(obj);
        }

        /// <summary>
        /// 取消观察另外一个对象
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Unwatch(DataModelBehaviour obj,string propertyName)
        {
            watchTable.Unwatch(obj.DataEntity,propertyName);
        }

        /// <summary>
        /// 取消观察另外一个对象
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Unwatch(BaseDataModelEntity entity, string propertyName)
        {
            watchTable.Unwatch(entity, propertyName);
        }

        /// <summary>
        /// 取消观察另外一个对象
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Unwatch(DataModelBehaviour obj)
        {
            watchTable.Unwatch(obj.DataEntity);
        }

        /// <summary>
        /// 取消观察另外一个对象
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Unwatch(BaseDataModelEntity entity)
        {
            watchTable.Unwatch(entity);
        }

        /// <summary>
        /// 执行事件侦听循环
        /// </summary>
        public virtual void Update()
        {
            watchTable.Trace();
        }

        /// <summary>
        /// 销毁时清理watchTable
        /// </summary>
        private void OnDestroy()
        {
            //如果当前的物体是动态创建，则释放其使用的动态id
            if (DynamicIdSupport != null)
            {
                DynamicIdSupport.ReleaseUsedId(DataEntity.objectID);
            }
            watchTable.Dispose();
            RestoreSystem.RemoveDataModel(DataEntity.objectID);
        }

        /// <summary>
        /// 设置当前状态是否可以保存
        /// </summary>
        /// <param name="state"></param>
        public  virtual void CanSave(bool state)
        {
            RestoreSystem.CanSave = state;
        }

        /// <summary>
        /// 从RecoverSystem中读取数据
        /// </summary>
        public virtual void LoadStorageData()
        {
            //还原位置信息
            transform.localPosition = DataEntity.transInfo.positon;
            transform.localEulerAngles = DataEntity.transInfo.eulerAngles;
            transform.localScale = DataEntity.transInfo.localScale;
            gameObject.SetActive(DataEntity.transInfo.isActive);
        }

        /// <summary>
        /// 将数据写入到RecoverSystem中
        /// </summary>
        public virtual void SaveStorageData()
        {                       
            //赋值Transform信息
            TransInfo transInfo = new TransInfo();
            transInfo.positon = transform.localPosition;
            transInfo.eulerAngles = transform.localEulerAngles;
            transInfo.localScale = transform.localScale;
            transInfo.isActive = gameObject.activeSelf;
            DataEntity.transInfo = transInfo;
        }

    }
}


