
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： RecordSystem
* 创建日期：2019-03-07 19:01:18
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Com.Rainier.Buskit3D
{

    /// <summary>
    /// 数据记录条目
    /// </summary>
    [System.Serializable]
    public struct RecordItem
    {
        public int FrameCount;       //帧ID
        public int ObjectId;         //DataEntity的标识ID
        public string PropertyPath;     //属性名称
        public object NewValue;         //新属性值
    }
    /// <summary>
    /// 记录实验过程中的数据实体变化
    /// </summary>
	public class RecordSystem  
	{


        [Inject]
        IServiceSerializer _serviceSerializer;

        [Inject]
        IServiceCompress _serviceCompress;

        /// <summary>
        /// 是否可以记录
        /// </summary>
        public static bool EnableRecord = true;

        /// <summary>
        /// 实验记录的总帧数
        /// </summary>
        public static int TotalFrameCount = 0;

        /// <summary>
        /// 开始记录实验时，当前的Time.frameCout
        /// </summary>
        public static int StartRecordFrame = 0;

        /// <summary>
        /// 代表当前的写入状态
        /// </summary>
        private int _writeState = 1;

        /// <summary>
        /// 数据块长度
        /// </summary>
        private int _bufferLength = 200;
        /// <summary>
        /// 记录的属性变化列表
        /// </summary>
        public  List<RecordItem> recordBufferA = new List<RecordItem>();
        public  List<RecordItem> recordBufferB = new List<RecordItem>();

        /// <summary>
        /// 压缩过后的zip字符串
        /// </summary>
        public List<string> chunkData = new List<string>();

#if UNITY_EDITOR
        public List<string> testChunkData = new List<string>();
#endif
        /// <summary>
        /// 注入序列化接口
        /// </summary>
        public RecordSystem()
        {
            InjectService.InjectInto(this);
        }

        /// <summary>
        /// 单利
        /// </summary>
        private  static RecordSystem instance=null;

        /// <summary>
        /// 获取当前单利
        /// </summary>
        /// <returns></returns>
        public static RecordSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecordSystem();
                }
                return instance;
            }
        }

        /// <summary>
        /// 数据记录
        /// </summary>
        /// <param name="evt"></param>
        public void Record(PropertyMessage evt)
        {
            if (!EnableRecord)
            {
                return; 
            }
            RecordItem item = new RecordItem();
            item.ObjectId = ((BaseDataModelEntity)evt.TargetObject).objectID;
            item.PropertyPath = evt.PropertyName;
            item.NewValue = evt.NewValue;
            item.FrameCount = Time.frameCount- StartRecordFrame;
            AddRecordItem(item);
        }

        /// <summary>
        /// 添加数据到对应列表中
        /// </summary>
        /// <param name="item"></param>
        public void AddRecordItem(RecordItem item)
        {
            if (_writeState == 1)
            {
                recordBufferA.Add(item);
                if (recordBufferA.Count == _bufferLength)
                {
                    ChunkToString();
                    recordBufferA.Clear();
                    _writeState = 2;
                }
            }
            else if (_writeState == 2)
            {
                recordBufferB.Add(item);
                if (recordBufferB.Count == _bufferLength)
                {
                    ChunkToString();
                    recordBufferB.Clear();
                    _writeState = 1;
                }
            }
        }


        /// <summary>
        /// 将数据转为字符串
        /// </summary>
        public void ChunkToString()
        {
            string chunk = "";
            if (_writeState == 1)
            {
               chunk=  _serviceSerializer.SerializerObject(recordBufferA);
            }
            else if (_writeState == 2)
            {
                chunk = _serviceSerializer.SerializerObject(recordBufferB);
            }

            byte[] rawData = System.Text.Encoding.UTF8.GetBytes(chunk);
            byte[] zipData = _serviceCompress.Compress(rawData);
            chunkData.Add(System.Convert.ToBase64String(zipData));
#if UNITY_EDITOR
            testChunkData.Add(chunk);
#endif
        }

        public void StringToChunk(string base64String)
        {
            chunkData.Clear();
            JObject jo = (JObject)_serviceSerializer.DeSerializerObject(base64String);
            int number = jo["TotalChunk"].ToObject<int>();
            TotalFrameCount = jo["FrameCount"].ToObject<int>();

            for (int i = 0; i < number; i++)
            {
                chunkData.Add(jo[i.ToString()].ToString());
            } 
        }

        /// <summary>
        /// 获取一段发序列化后的回放数据块内容
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<RecordItem> GetChunkItem(int index)
        {
            byte[] zipData = System.Convert.FromBase64String(chunkData[index]);
            byte[] rawData = _serviceCompress.DeCompress(zipData);
            string chunk = System.Text.Encoding.UTF8.GetString(rawData);

            return _serviceSerializer.DeSerializerObject<List<RecordItem>>(chunk);
        }


    }
}

