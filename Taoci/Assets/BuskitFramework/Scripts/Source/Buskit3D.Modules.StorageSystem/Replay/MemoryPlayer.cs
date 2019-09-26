/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：Player
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：内存实验记录播放器
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using Com.Rainier.BusKit.Unity.Modules.DataWatch;
using Newtonsoft.Json.Linq;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json;
using System.Linq;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 内存实验记录播放器
    /// </summary>
    public class MemoryPlayer : MonoBehaviour
    {
        /// <summary>
        /// 回放结束事件回调
        /// </summary>
        public System.Action PlayOverEvent;

        [Inject]
        IServiceSerializer _serviceSerializer;

        /// <summary>
        /// 帧数
        /// </summary>
        private int frameCount = 0;

        /// <summary>
        /// Unity Method
        /// </summary>
        private void Start()
        {
            InjectService.InjectInto(this);
        }

        /// <summary>
        /// 开始播放
        /// </summary>
        public void StartPlay(System.Action playerOver)
        {
            frameCount = 0;
            StartCoroutine(DoPlayCoroutine());
            Percent = 0;
            PlayOverEvent = playerOver;
        }

        /// <summary>
        /// 播放百分比
        /// </summary>
        private static float percent = 0f;
        public static float Percent {

            get { return percent; }
            protected set {
                percent = value;
            }
        }
        /// <summary>
        /// 播放协成
        /// </summary>
        /// <returns></returns>
        public IEnumerator DoPlayCoroutine()
        {
            //关闭记录业务逻辑
            RecordSystem.EnableRecord = false;

            int chunkCount = RecordSystem.Instance.chunkData.Count;
            for (int i = 0; i < chunkCount; i++)
            {
                yield return StartCoroutine(DoPlayAChunk(RecordSystem.Instance.GetChunkItem(i)));
            }

            //播放完后续空帧（从最后一个操作持续到保存时）
            int length = RecordSystem.TotalFrameCount;
            for (int i = frameCount; i < length; i++)
            {
                frameCount += 1;
                yield return new WaitForFixedUpdate();
                Percent = (float)frameCount / length;
            }

#if UNITY_EDITOR
            Debug.Log("playback  over");
#endif
            if (PlayOverEvent != null)
            {
                PlayOverEvent.Invoke();
            }
            //开启记录业务逻辑
            RecordSystem.EnableRecord = true;
        }

        /// <summary>
        /// 回放一个数据块的内容
        /// </summary>
        /// <param name="recordItem"></param>
        /// <returns></returns>
        public IEnumerator DoPlayAChunk(List<RecordItem> recordItem)
        {
            
            int length = RecordSystem.TotalFrameCount;
            for (int i = 0; i < recordItem.Count; i++)
            {
                while (frameCount <= recordItem[i].FrameCount)
                {
                    //记录的帧 与当前相等
                    if (recordItem[i].FrameCount == frameCount)
                    {

                        UpdateEntityValue(recordItem[i]);
                        break;
                    }
                    yield return new WaitForFixedUpdate();
                    frameCount += 1;
                    Percent = (float)frameCount / length;
                }
            }
        }

        /// <summary>
        /// 回放设置对应的属性值
        /// </summary>
        /// <param name="item"></param>
        public void UpdateEntityValue(RecordItem item)
        {
        
            //获取实体对象实例
            BaseDataModelEntity targetEntity = GetModelEntityByUuid(item.ObjectId);
            if(targetEntity == null)
            {
                targetEntity = RestoreSystem.GetEntity(item.ObjectId);
            }
            if (targetEntity == null)
            {
                return;
            }
            if (item.PropertyPath.Contains("#"))
            {
                UpdateWatchable(targetEntity, item.PropertyPath, item.NewValue);
            }
            //通过Property方式查找属性并设置属性值
            PropertyInfo propertyInfo = null;
            propertyInfo = targetEntity.GetType().GetProperty(item.PropertyPath);
            if (propertyInfo != null)
            {
                if (propertyInfo.PropertyType == typeof(System.Single))
                {
                    System.Single _value = System.Convert.ToSingle(item.NewValue);
                    propertyInfo.SetValue(targetEntity, _value);
                }
                else if (propertyInfo.PropertyType == typeof(System.Int32))
                {
                    System.Int32 _value = System.Convert.ToInt32(item.NewValue);
                    propertyInfo.SetValue(targetEntity, _value);
                }
                else
                {
                    propertyInfo.SetValue(targetEntity, item.NewValue, null);
                }

                return;
            }

            //通过Field方式查找属性并设置属性值            
            FieldInfo fieldInfo = targetEntity.GetType().GetField(item.PropertyPath);
            if (fieldInfo != null)
            {
                if (fieldInfo.FieldType == typeof(System.Single))
                {
                    System.Single _value = System.Convert.ToSingle(item.NewValue);
                    fieldInfo.SetValue(targetEntity, _value);
                }
                else if (fieldInfo.FieldType == typeof(System.Int32))
                {
                    System.Int32 _value = System.Convert.ToInt32(item.NewValue);
                    fieldInfo.SetValue(targetEntity, _value);
                }
                else
                {
                    fieldInfo.SetValue(targetEntity, item.NewValue);
                }
            }
        }

        /// <summary>
        /// 更新容器类数值
        /// </summary>
        /// <param name="targetEntity"></param>
        /// <param name="propertyPath"></param>
        /// <param name="newValue"></param>
        public void UpdateWatchable(BaseDataModelEntity targetEntity, string propertyPath, object newValue)
        {

            string[] nameOfValue = propertyPath.Split('#');
            var fieldInfo = targetEntity.GetType().GetField(nameOfValue[0]);

            if (fieldInfo.FieldType == typeof(WatchableArrayList))
            {
                return;
                //UpdateWatchArrayList(targetEntity, fieldInfo, nameOfValue[1], newValue);
            }
            else if (fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(WatchableList<>))
            {
                UpdateWatchList(targetEntity, fieldInfo, nameOfValue[1], newValue);
            }
            else if (fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(WatchableDictionary<,>))
            {
                UpdateWatchDic(targetEntity, fieldInfo, nameOfValue[1], newValue);
            }
        }

        public void UpdateWatchArrayList(BaseDataModelEntity targetEntity, FieldInfo fieldInfo, string operation, object newValue)
        {
            //获取Remove时没有产生歧义
            var method = fieldInfo.FieldType.GetMethod(operation);
            if (method == null && !operation.Equals("[]"))
            {
                return;
            }

            System.Type tType = fieldInfo.FieldType.GetElementType();

            switch (operation)
            {
                case "Add":               
                    //原值是int32，回放添加进去的默认为int64
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { newValue });
                    break;
                case "Remove":
                    newValue = _serviceSerializer.DeSerializerObject(newValue.ToString(), tType);
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { newValue });
                    break;
                case "RemoveAt":
                    //RemoveAt操作，newValue为Index
                    int removeIndex = System.Convert.ToInt32(newValue);
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { removeIndex });
                    break;
                case "Clear":
                    method.Invoke(fieldInfo.GetValue(targetEntity), null);
                    break;
                case "Insert":
                    JObject insertJObject = (JObject)newValue;
                    int insertIndex = insertJObject["Key"].ToObject<int>();
                    object insertValue = insertJObject["Value"];// _serviceSerializer.DeSerializerObject(insertJObject["Value"].ToString(), tType);
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { insertIndex, insertValue });
                    break;
                case "[]":
                    JObject keyValue = (JObject)newValue;
                    int index = keyValue["Key"].ToObject<int>();
                    object value = _serviceSerializer.DeSerializerObject(keyValue["Value"].ToString(), tType);
                    method = fieldInfo.FieldType.GetMethod("set_Item");
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { index, value });
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 更新list
        /// </summary>
        /// <param name="targetEntity"></param>
        /// <param name="fieldInfo"></param>
        /// <param name="operation"></param>
        /// <param name="newValue"></param>
        public void UpdateWatchList(BaseDataModelEntity targetEntity, FieldInfo fieldInfo,string operation,object newValue)
        {
            //获取Remove时没有产生歧义
            var method = fieldInfo.FieldType.GetMethod(operation);
            if (method == null&& !operation.Equals("[]"))
            {
                return;
            }

#if NET_4_6 || NET_STANDARD_2_0 
            System.Type tType = fieldInfo.FieldType.GenericTypeArguments[0];
#endif
#if NET_2_0_SUBSET || NET_2_0 || UNITY_5
            System.Type tType = fieldInfo.FieldType.GenericTypeArguments()[0];
#endif
            switch (operation)
            {
                case "Add":
                    if(newValue is System.ValueType)
                    {
                        newValue = _serviceSerializer.DeSerializerObject(newValue.ToString(), tType);
                        method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { newValue });
                    }
                    else
                    {
                        method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { newValue });
                    }
                    break;
                case "Remove":
                    if (newValue is System.ValueType)
                    {
                        newValue = _serviceSerializer.DeSerializerObject(newValue.ToString(), tType);
                        method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { newValue });
                    }
                    else
                    {
                        method.Invoke(fieldInfo.GetValue(targetEntity), new object[] {newValue });
                    }
                    break;
                case "RemoveAt":
                    //RemoveAt操作，newValue为Index
                    int removeIndex = System.Convert.ToInt32(newValue);
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { removeIndex });
                    //if (newValue is System.ValueType)
                    //{
                    //    int removeIndex = System.Convert.ToInt32(newValue);
                    //    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { removeIndex });
                    //}
                    //else
                    //{
                    //    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { newValue });
                    //}
                    break;
                case "Clear":
                    method.Invoke(fieldInfo.GetValue(targetEntity), null);
                    break;
                case "Insert":
                    JObject insertJObject = (JObject)newValue;
                    int insertIndex = insertJObject["Key"].ToObject<int>();
                    object insertValue = _serviceSerializer.DeSerializerObject(insertJObject["Value"].ToString(), tType);
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { insertIndex, insertValue });
                    break;
                case "[]":
                    JObject keyValue = (JObject)newValue;
                    int index = keyValue["Key"].ToObject<int>();
                    object value= _serviceSerializer.DeSerializerObject(keyValue["Value"].ToString(), tType);
                    method = fieldInfo.FieldType.GetMethod("set_Item");
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { index, value });
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 更新字典
        /// </summary>
        public void UpdateWatchDic(BaseDataModelEntity targetEntity, FieldInfo fieldInfo, string operation, object newValue)
        {
            MemberInfo[] info = fieldInfo.FieldType.GetMethods();
            foreach (var item in info)
            {
                Debug.Log(item);
            }
            MethodInfo method = null;

#if NET_4_6 || NET_STANDARD_2_0
            System.Type keyType = fieldInfo.FieldType.GenericTypeArguments[0];
            System.Type valueType = fieldInfo.FieldType.GenericTypeArguments[1];
#endif 
#if NET_2_0_SUBSET || NET_2_0 || UNITY_5
            System.Type[] tType = fieldInfo.FieldType.GenericTypeArguments();
            System.Type keyType = tType[0];
            System.Type valueType = tType[1];
#endif
            switch (operation)
            {
                case "Add":
                    method = fieldInfo.FieldType.GetMethod(operation);
                    JObject addJObject = (JObject)newValue;
                    object addKey = _serviceSerializer.DeSerializerObject(addJObject["Key"].ToString(),keyType);
                    object addValue = _serviceSerializer.DeSerializerObject(addJObject["Value"].ToString(), valueType);
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { addKey, addValue });
                    break;
                case "Remove":
                    //获取Remove方法是产生了歧义，采用遍历获取的方式
                    method = fieldInfo.FieldType.GetMethods().Where(p => p.Name == "Remove").Where(p => p.ReturnType == typeof(void)).First();
                    object removeKey = _serviceSerializer.DeSerializerObject(newValue.ToString(), keyType);
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { removeKey });
                    break;
                case "Clear":
                    method = fieldInfo.FieldType.GetMethod(operation);
                    method.Invoke(fieldInfo.GetValue(targetEntity), null);
                    break;
                case "[]":
                    JObject keyValue = (JObject)newValue;
                    object key = _serviceSerializer.DeSerializerObject(keyValue["Key"].ToString(), keyType);
                    object value = _serviceSerializer.DeSerializerObject(keyValue["Value"].ToString(), valueType);
                    method = fieldInfo.FieldType.GetMethod("set_Item");
                    method.Invoke(fieldInfo.GetValue(targetEntity), new object[] { key, value });
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 通过objectID查找实体对象
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public BaseDataModelEntity GetModelEntityByUuid(int objectId)
        {
            DataModelBehaviour[] models = GameObject.FindObjectsOfType<DataModelBehaviour>();
            for (int i = 0; i < models.Length; i++)
            {
                if (models[i].DataEntity.objectID == objectId)
                {
                    
                    return models[i].DataEntity;
                }
            }
            return null;
        }

    }
}
