/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：StorageSystem
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：存储系统功能，包含weggl和windows
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using UnityEngine.Networking;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 存储系统功能，包含weggl和windows
    /// </summary>
    public class StorageSystem :MonoBehaviour,IStorage
    {   
        /// <summary>
        /// 测试文件路径
        /// </summary>
        public string testFilePath =  "TestExperiment.txt";
        /// <summary>
        /// 存储数据文件路径
        /// </summary>
        public string filePath =  "Experiment.txt";

        /// <summary>
        /// 国标脚本路劲
        /// </summary>
        public string igcsPath = "IgcsExperiment.xml";

        /// <summary>
        /// webApi接口实例
        /// </summary>
        [Inject]
        IWebGlWebAPIService _webApiService = null;

        [Inject]
        IServiceSerializer _serviceSerializer = null;

        [Inject]
        LabInterSystem labInterSystem=null;

        /// <summary>
        /// 保存恢复实例
        /// </summary>
        RestoreSystem _restoreSystem;

        /// <summary>
        /// 数据转化实例
        /// </summary>
        StorgaeDataWrapper _storgaeDataWrapper;

        /// <summary>
        /// 标志开始记录
        /// </summary>
        private static bool StartRecord = false;

        /// <summary>
        /// Unity Method
        /// </summary>
        private void Awake()
        {
            //初始化实验室管理交互接口
            LabInterSystem.Init();

            //当存储系统初始化时，即开始记录，设置开始记录时的当前帧数
            if (!StartRecord)
            {
                RecordSystem.StartRecordFrame = Time.frameCount;
                StartRecord = true;
            }
            RestoreSystem.ClearDataModel();
            //场景初始化是，将场景中当前的DataModel保存起来
            var allDataModels = Resources.FindObjectsOfTypeAll<DataModelBehaviour>();
            foreach (var item in allDataModels)
            {
               
                if (item.hideFlags != (HideFlags.NotEditable|HideFlags.HideInHierarchy))
                {
                    if (item.GetComponent<UniqueID>() == null)
                    {
                        Debug.Log("当前挂有DataModel的物体：[+" + item.name + "] 未添加 [UniqueID]");
                    }
                    else
                    {
                        //报空对象，检查预制体问题
                        RestoreSystem.AddDataModel(item.GetComponent<UniqueID>().UniqueId, item);
                    }
                }
            }
        }
        /// <summary>
        /// Unity Method
        /// </summary>
        private void Start()
        {
            _restoreSystem = new RestoreSystem();
            testFilePath = Path.Combine(Application.dataPath, testFilePath);
            filePath = Path.Combine(Application.dataPath, filePath);
            igcsPath = Path.Combine(Application.dataPath, igcsPath);
            _storgaeDataWrapper = new StorgaeDataWrapper();
            InjectService.InjectInto(this);
        }

        #region storage chunk

        /// <summary>
        /// 处理回放数据格式
        /// </summary>
        /// <returns></returns>
        public JObject ReplayData()
        {
            //保存记录的数据
            RecordSystem.Instance.ChunkToString();


            JObject replayJObject = new JObject();
            int index = 0;
            foreach (string _item in RecordSystem.Instance.chunkData)
            {
                replayJObject.Add(index.ToString(), _item);
                index += 1;
            }
            replayJObject.Add("FrameCount", new JValue(Time.frameCount));
            replayJObject.Add("TotalChunk", new JValue(index));
            return replayJObject;
        }

        /// <summary>
        /// 处理还原数据格式
        /// </summary>
        /// <returns></returns>
        public string RestoreData()
        {
            //保存还原数据
            _restoreSystem.SaveStorageData();
            return _restoreSystem.DataToString(); 
        }

        /// <summary>
        /// 保存智能批改脚本
        /// </summary>
        public void SaveIgcsData()
        {
            _restoreSystem.SaveIgcsData();

#if Local_Mode
#if UNITY_WEBGL
                _webApiService.SaveStringToLocalFile(IgcsXmlGenerator.SavedXml, "IgcsXmlGenerator.Xml");
#elif UNITY_STANDALONE_WIN
                _storgaeDataWrapper.DataToFile(igcsPath, IgcsXmlGenerator.SavedXml);
#endif
#endif

#if Lab_Mode
            //平台模式
            JObject jo = labInterSystem.SetRequestInfo();
            jo.Add("intelligentGuidanceInitScript", IgcsXmlGenerator.SavedXml);
            labInterSystem.LabRequest(LabInterType.uploadIgcs, jo.ToString());
#endif
        }

        /// <summary>
        /// 将回放还原数据合并写入文本
        /// </summary>
        /// <param name="t"></param>
        public void SaveStorageData()
        {
            //判断当前是否可保存
            if (!RestoreSystem.CanSave)
            {
#if UNITY_EDITOR
                Debug.Log("current state can not save");
#endif
                return;
            }

            JObject targetJObject = new JObject();
            targetJObject.Add("ReplayData", ReplayData());
            targetJObject.Add("RestoreData", RestoreData());

#if Local_Mode
#if UNITY_WEBGL
            //保存文件到本地
            _webApiService.SaveStringToLocalFile(targetJObject.ToString(), "Experiment.json");
#elif UNITY_STANDALONE_WIN
                //保存文件到本地
                _storgaeDataWrapper.DataToFile(filePath, targetJObject.ToString());
#endif
#if UNITY_EDITOR && UNITY_STANDALONE_WIN && Local_Mode_Debug
            //编辑器下生成测试数据
            string testReplay = _serviceSerializer.SerializerObject((RecordSystem.Instance.testChunkData));
            string allstr = "";
            foreach (var item in RecordSystem.Instance.testChunkData)
            {
                allstr += item;
            }
            targetJObject["ReplayData"] = allstr;
            targetJObject["RestoreData"] = _restoreSystem.testEntityData;
            _storgaeDataWrapper.DataToTestFile(testFilePath, targetJObject);
#endif
#endif


#if Lab_Mode
            //保存文件到实验室管理平台
            JObject jo = labInterSystem.SetRequestInfo();
            jo.Add("initScript",targetJObject.ToString());
            labInterSystem.LabRequest(LabInterType.uploadRepay, jo.ToString());
#endif


#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

        /// <summary>
        /// 将数据加载到内存中
        /// </summary>
        public void LoadStorageData()
        {
#if Local_Mode
#if UNITY_STANDALONE_WIN
            ReadStorageFileCallback();
#endif
#if UNITY_WEBGL
            _webApiService.ReadFileFromLocal("StorageSystem", "ReadStorageFileCallback");
#endif
#endif
#if Lab_Mode
            JObject jObject = labInterSystem.SetRequestInfo();
            labInterSystem.LabRequest(LabInterType.downloadReplay, jObject.ToString());
            labInterSystem.RequestCallBack = ReadStorageFileCallback;
#endif
        }

        /// <summary>
        /// 将回放数据写入对应结构中
        /// </summary>
        /// <param name="content"></param>
        public void ReadStorageFileCallback(string content = "")
        {
            RecordSystem.Instance.chunkData.Clear();
            string[] stroageData=new string[2];
             
#if Local_Mode

#if UNITY_STANDALONE_WIN
                stroageData = _storgaeDataWrapper.FileToString(filePath);
#elif UNITY_WEBGL
             stroageData = _storgaeDataWrapper.FileToString(content);
#endif
#endif

#if Lab_Mode
             stroageData = _storgaeDataWrapper.FileToString(content);
#endif
            RecordSystem.Instance.StringToChunk(stroageData[0]);
            _restoreSystem.StringToData(stroageData[1]);
        }

        /// <summary>
        /// 开始回放
        /// </summary>
        public void BeginReplay(System.Action action)
        {
            GameObject.FindObjectOfType<MemoryPlayer>().StartPlay(action);
        }

        /// <summary>
        /// 场景恢复
        /// </summary>
        public void RestoreScene()
        {

            //先处理场景问题，还原场景管理DataModel的entity
            ReplayManager replayLoader = GetComponent<ReplayManager>();
            _restoreSystem.Load(replayLoader.DataEntity);

            //判断是否是当前场景
            ReplayEntity sceneEntity = (ReplayEntity)replayLoader.DataEntity;

            //加载场景
            StartCoroutine(LoadScene(sceneEntity.sceneName));
        }

        /// <summary>
        /// 如果有场景变换，采用异步等待方式还原数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        System.Collections.IEnumerator LoadScene(string name)
        {
            
            if (!UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals(name))
            {
                AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
                asyncOperation.allowSceneActivation = false;
                while (asyncOperation.isDone)
                {
                    yield return null;
                }                
                asyncOperation.allowSceneActivation = true;
                //等待1秒，初始化结束（场景物体）
                yield return new WaitForSeconds(1);
            }
            //将所有物体设置为激活状态，随后在还原
            RestoreSystem.ClearDataModel();
            var allDataModels = Resources.FindObjectsOfTypeAll<DataModelBehaviour>();
            foreach (var item in allDataModels)
            {
                if (item.hideFlags != (HideFlags.NotEditable | HideFlags.HideInHierarchy))
                {
                    RestoreSystem.AddDataModel(item.GetComponent<UniqueID>().UniqueId, item);
                    item.gameObject.SetActive(true);
                }
            }
            //等待1秒，初始化结束（DataModel脚本）
            yield return new WaitForSeconds(1);
            //执行数据写入，设置自身状态
            _restoreSystem.LoadStorageData();
            StartCoroutine(RestoreSceneCallBack());            
        }

        /// <summary>
        /// 场景恢复结束回调
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator RestoreSceneCallBack()
        {
            yield return 0;
            _restoreSystem.OnFireAllEvent();
        }

#endregion
    }
}
