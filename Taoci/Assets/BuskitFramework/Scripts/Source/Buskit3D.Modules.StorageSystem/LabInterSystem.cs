
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： LabInterSystem
* 创建日期：2019-03-29 13:38:31
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 与实验室管理系统的请求类型
    /// </summary>
    public enum LabInterType
    {
        //登录
        login,
        //上传智能批改信息
        uploadIgcs,
        //上传实验数据
        uploadRepay,
        //下载实验数据
        downloadReplay

    }

    /// <summary>
    /// 从实验室获取的相关信息
    /// </summary>
    public class LabInfoParams
    {
        /// <summary>
        /// 角色信息
        /// </summary>
        public string role;
        /// <summary>
        /// 学号或者工号
        /// </summary>
        public string numberId;
        /// <summary>
        /// 姓名
        /// </summary>
        public string name;
        /// <summary>
        /// 实验id，预约id
        /// </summary>
        public string eid;
        /// <summary>
        /// pc版资源id
        /// </summary>
        public string esid;
    }

    /// <summary>
    /// 实验室管理平台交互接口
    /// </summary>
	public class LabInterSystem : MonoBehaviour 
	{
        /// <summary>
        /// 请求数据及对应的url
        /// </summary>
        private  Dictionary<LabInterType, string> _labInterUrl = new Dictionary<LabInterType, string>();

        /// <summary>
        /// 序列化工具
        /// </summary>
        [Inject]
        private IServiceSerializer _serviceSerializer;

        /// <summary>
        /// 请求回调
        /// </summary>
        public System.Action<string> RequestCallBack;

        /// <summary>
        /// web接口
        /// </summary>
        [Inject]
        private IWebGlWebAPIService _webGlWebAPIService;

        /// <summary>
        /// ILab接口
        /// </summary>
        [Inject]
        private ILabInterApiService _iLabInterApiService;

        /// <summary>
        /// 当前请求类型
        /// </summary>
        private LabInterType requestInterType;

        /// <summary>
        /// 实验室数据信息
        /// </summary>
        public  LabInfoParams labInfoParams=new LabInfoParams();
       

        /// <summary>
        /// 初始化接口系统
        /// </summary>
        public static void Init()
        {
            if (GameObject.FindObjectOfType<LabInterSystem>() == null)
            {
                GameObject labInterObj = new GameObject("LabInterSystem");
                labInterObj.AddComponent<LabInterSystem>();
                GameObject storageObj = GameObject.Find("Subsystem");
                if (storageObj == null)
                {
                    return; 
                }
                else
                {
                    labInterObj.transform.SetParent(storageObj.transform);
                }
            }
        }

        public void Awake()
        {
            if (InjectService.Get<LabInterSystem>() == null)
            {
                InjectService.RegisterSingleton(this);
            }
            //注入ILabInterApi接口
            if (InjectService.Get<ILabInterApiService>() == null)
            {
                LabInterApiService service = new LabInterApiService();
                service.Initialize();
            }
        }

        private void Start()
        {
            InjectService.InjectInto(this);
            ExperimentInfoSettings ExpInfoSettings = (ExperimentInfoSettings)Resources.Load("ExperimentInfoSettings", typeof(ExperimentInfoSettings));
            _labInterUrl.Add(LabInterType.login, ExpInfoSettings.loginUrl);
            _labInterUrl.Add(LabInterType.uploadIgcs, ExpInfoSettings.uploadIgcsUrl);
            _labInterUrl.Add(LabInterType.uploadRepay, ExpInfoSettings.uploadReplayUrl);
            _labInterUrl.Add(LabInterType.downloadReplay, ExpInfoSettings.downloadReplayUrl);


            //调用接口，获取登录用户信息
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _iLabInterApiService.GetLabUserInfo();
            }
        }

        /// <summary>
        /// 调用接口
        /// </summary>
        /// <param name="labInterType"></param>
        /// <param name="requsetData"></param>
        /// <returns></returns>
        public  void LabRequest(LabInterType labInterType, string  requsetData="")
        {

            //显示遮罩
            ScreenMask.ShowMask(new Color(1, 1, 1, 0.7f), MaskType.BigSpinner);

            requestInterType = labInterType;
            //设置请求json格式
            byte[] postBtye =System.Text.Encoding.UTF8.GetBytes(requsetData);
            string postData = System.Convert.ToBase64String(postBtye);
            StartCoroutine(ExcuteRequest(_labInterUrl[labInterType], postData));
        }

        /// <summary>
        /// 执行http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        IEnumerator ExcuteRequest(string url,string data)
        {
            Debug.Log(url);
#if !UNITY_WEBPLAYER
            // string data64 = System.Convert.ToBase64String(data);
            Dictionary<string, string> postdata = new Dictionary<string, string>();
            postdata.Add("param", data);
            UnityWebRequest request = UnityWebRequest.Post(url, postdata);

            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
         
            yield return request.SendWebRequest();

            //回调函数
            WebRequestCallBack(request.responseCode, request.downloadHandler.text);

#else 
            //webplayer
            WWWForm pdata = new WWWForm();
            pdata.AddField("param", data);
            pdata.headers.Add("Content-Type", "application/x-www-form-urlencoded");
            WWW www = new WWW(url, pdata);
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
             //回调函数
            WebRequestCallBack(1, www.text);
#endif
        }

        /// <summary>
        /// 请求消息固定前缀
        /// </summary>
        /// <returns></returns>
        public  JObject SetRequestInfo()
        {
            JObject jo = new JObject();
            jo.Add("role", new JValue( labInfoParams.role));
            jo.Add("numberId", new JValue( labInfoParams.numberId));
            jo.Add("name", new JValue( labInfoParams.name));
            jo.Add("eid", new JValue( labInfoParams.eid));
            Debug.Log("当前请求数据头：["+jo.ToString()+"]");
            return jo;
        }

        /// <summary>
        /// 填充实验室相关数据
        /// </summary>
        public void SetLabInfoParams(string infoParam)
        {
            Debug.Log(infoParam);
            JObject jObject = _serviceSerializer.DeSerializerObject<JObject>(infoParam);
#if UNITY_WEBGL || UNITY_WEBPLAYER
            //调用jslib返回数据
            labInfoParams.role = jObject["role"].ToString();
            labInfoParams.numberId = jObject["numberId"].ToString();
            labInfoParams.name = jObject["name"].ToString();
            labInfoParams.eid = jObject["eid"].ToString();
#elif UNITY_STANDALONE_WIN || UNITY_5
            //发送http请求接收数据

            labInfoParams.role = jObject["role"].ToString();
            labInfoParams.numberId = jObject["numberId"].ToString();
            labInfoParams.name = jObject["name"].ToString();
            //eid在登录模块中设置
#endif
           
        }

        /// <summary>
        /// 请求回调，包含状态码和返回数据
        /// </summary>
        /// <param name="responseCode"></param>
        /// <param name="data"></param>
        protected void WebRequestCallBack(long responseCode,string data)
        {
            byte[] data64 = System.Convert.FromBase64String(data);
            string result = System.Text.Encoding.UTF8.GetString(data64);

            JObject jObject = _serviceSerializer.DeSerializerObject<JObject>(result);
            if (jObject["status"].ToString().Equals("101"))
            {
                Debug.Log(requestInterType + "服务器返回异常" + result);
                return;
            }
            switch (requestInterType)
            {
                case LabInterType.login:
                    SetLabInfoParams(result);
                    if (RequestCallBack != null)
                    {
                        RequestCallBack(result);
                    }
                    break;
                case LabInterType.uploadIgcs:
                    Debug.Log("上传智能批改数据请求返回信息：[" + result + "]");
                    break;
                case LabInterType.uploadRepay:
                    Debug.Log("上传实验数据请求返回信息：[" + result + "]");
                    break;
                case LabInterType.downloadReplay:
                    Debug.Log("下载实验数据请求返回信息：[" + result + "]");
                    RequestCallBack(jObject["initScript"].ToString());
                    break;
                default:
                    break;
            }

            //关闭遮罩
            ScreenMask.HideMask();
        }
         
        private void OnDisable()
        {
            InjectService.Unregister<LabInterSystem>();
        }


    }
}

