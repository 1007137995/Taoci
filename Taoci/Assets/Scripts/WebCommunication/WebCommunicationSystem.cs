/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v2.0.0
* 类 名 称： WebCommunicationSystem
* 创建日期：2019-08-06 18:44:14
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：v1.1.0修复了一些无关紧要的，不影响正常使用的问题。添加了一些代码注释。
*           v2.0.0简化通用平台接口地址输入，现在只需输入Host即可。
*                 简化简易平台接口地址输入，如果用云渲染，现在只需输入Host和id即可。如果不用可以不输入。
*                 整合了通用平台与简易平台的代码。
*                 两个平台都支持PC WebGL webPlayer  unity5.3.6及以上的版本。
*                 两个平台云渲染调用“LoginForCloud”即可，注：整个实验只调用登陆一次，不能重复调用。
*                 两个平台上传分数调用“UpLoadScore"即可
*                 上传表格需要产品做好表格模板发给平台，平台定好上传格式后程序加，所以无法封装需要自己写。注：简易平台没有上传表格的功能
*                 *简易平台WebGL和WebPlayer不需要登陆，但是要在打包出来的index.html中加上此脚本最下方的JS代码才能生效，务必注意！
* 描述：（此脚本挂在“LabInterSystem”名字的物体上）
******************************************************************************/

using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
#if UNITY_WEBPLAYER
using UnityEngine.Experimental.Networking;
#endif

namespace Com.Rainier.ZC_Frame
{
    public enum PlatformSelect {
        /// <summary>
        /// 通用平台
        /// </summary>
        NormalPlatform = 0,
        /// <summary>
        /// 简易平台
        /// </summary>
        SimplePlatform 
    }


    public enum WebInterType {
        /// <summary>
        /// PC客户端登陆
        /// </summary>
        PCClientLogin = 0,
        /// <summary>
        /// 云渲染登陆
        /// </summary>
        CloudLogin,
        /// <summary>
        /// 上传分数
        /// </summary>
        UpLoadScore,
        /// <summary>
        /// 上传表格
        /// </summary>
        UpLoadTable
        //如需其他接口在此扩展
    }

    /// <summary>
    /// 与平台通信中心
    /// </summary>
	public class WebCommunicationSystem : MonoBehaviour 
	{

        private static WebCommunicationSystem instance;

        public static WebCommunicationSystem GetInstance() {
            return instance;
        }

        /// <summary>
        /// 本实验所用平台（通用平台或者简易平台，一旦选择好不要在实验运行中再改）
        /// </summary>
        public PlatformSelect platform = PlatformSelect.NormalPlatform;

        /// <summary>
        /// 本实验所用平台（通用平台或者简易平台）
        /// </summary>
        public PlatformSelect Platform {
            get { return platform; }
        }

        /// <summary>
        /// 本实验的平台主页(通用平台)（默认值为通用测试平台地址）
        /// </summary>
        public string normalPlatformHostURL = "http://sfx.owvlab.net/virexp";

        /// <summary>
        /// 本实验的平台主页(简易平台)（默认值为简易测试平台地址）
        /// </summary>
        public string simplePlatformHostURL = "http://yunce.owvlab.net";

        /// <summary>
        /// 本实验的平台id(简易平台)（默认值为简易测试平台id）
        /// </summary>
        public string simplePlatformHostID = "45074294-ebc0-467e-b8d9-f1bf683c3c2f";

        /// <summary>
        /// 云渲染验证码
        /// </summary>
        private string cloudKeyCode = string.Empty;

        /// <summary>
        /// 接口地址
        /// </summary>
        public Dictionary<WebInterType, string> webInterURLs= new Dictionary<WebInterType, string>();

        /// <summary>
        /// 回调
        /// </summary>
        public UnityAction<string> webCallBack;

        /// <summary>
        /// 请求类型
        /// </summary>
        private WebInterType requestType;

        private void Awake()
        {
            instance = this;
            switch (platform)
            {
                case PlatformSelect.NormalPlatform:
                    webInterURLs.Add(WebInterType.PCClientLogin, normalPlatformHostURL + "/outer/login");
                    webInterURLs.Add(WebInterType.CloudLogin, normalPlatformHostURL + "/outer/getMessageByToken");
                    webInterURLs.Add(WebInterType.UpLoadScore, normalPlatformHostURL + "/outer/intelligent/!expScoreSave");
                    webInterURLs.Add(WebInterType.UpLoadTable, normalPlatformHostURL + "/outer/report/!reportEdit");
                    break;
                case PlatformSelect.SimplePlatform:
                    webInterURLs.Add(WebInterType.CloudLogin, simplePlatformHostURL + "/" + "openapi/" + simplePlatformHostID);
                    break;
                default:
                    break;
            }

#if UNITY_STANDALONE
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                switch (platform)
                {
                    case PlatformSelect.NormalPlatform:
                        if (args[i].StartsWith("token"))
                        {
                            cloudKeyCode = args[i].Split('=')[1];
                        }
                        break;
                    case PlatformSelect.SimplePlatform:
                        if (args[i].StartsWith("sequenceCode"))
                        {
                            cloudKeyCode = args[i].Split('=')[1];
                        }
                        break;
                    default:
                        break;
                }
            }
#endif
        }

        private void Start()
        {

            switch (platform)
            {
                case PlatformSelect.NormalPlatform:
#if UNITY_WEBPLAYER
            if (Application.platform == RuntimePlatform.WindowsWebPlayer) //WebPlayer版本
            {
                Application.ExternalCall("getUserInfoForWebPlayer");
            }
#elif UNITY_WEBGL
            if (Application.platform == RuntimePlatform.WebGLPlayer)  //WebGL版本
            {
                GetUserInformation.GetUserInfo();
            }
#endif
                    break;
                default:
                    break;
            }
        }

        #region 与平台交互逻辑

        /// <summary>
        /// 请求消息固定前缀
        /// </summary>
        /// <returns></returns>
        public JObject SetRequestInfo()
        {
            JObject jo = new JObject();
            jo.Add("role", new JValue(LoginInformation.Role));
            jo.Add("numberId", new JValue(LoginInformation.NumberId));
            jo.Add("name", new JValue(LoginInformation.Name));
            jo.Add("eid", new JValue(LoginInformation.EId));
            Debug.Log("当前请求数据头：[" + jo.ToString() + "]");
            return jo;
        }

        /// <summary>
        /// 请求回调，包含状态码和返回数据
        /// </summary>
        /// <param name="responseCode"></param>
        /// <param name="data"></param>
        protected void WebRequestCallBack(long responseCode, string data)
        {
            string result = data;
            if (webCallBack != null)
            {
                webCallBack(result);
            }
        }

        /// <summary>
        /// 填充实验室相关数据(获取登陆信息时JS会自动调用此方法传入登陆信息)
        /// </summary>
        public void SetLabInfoParams(string infoParams)
        {
            //调用jslib返回数据
#if UNITY_WEBGL
            JObject jObject = JsonConvert.DeserializeObject<JObject>(infoParams);
            LoginInformation.Role = jObject["role"].ToString();
            LoginInformation.NumberId = jObject["numberId"].ToString();
            LoginInformation.Name = jObject["name"].ToString();
            LoginInformation.EId = jObject["eid"].ToString();
            Debug.Log(jObject.ToString());
#endif

        }

        /// <summary>
        /// 填充实验室相关数据(webPlayer专用)
        /// </summary>
        /// <param name="infoParams"></param>
        public void getUserInfoForWebPlayer(string infoParams) {
            JObject jObject = JsonConvert.DeserializeObject<JObject>(infoParams);
            LoginInformation.Role = jObject["role"].ToString();
            LoginInformation.NumberId = jObject["numberId"].ToString();
            LoginInformation.Name = jObject["name"].ToString();
            LoginInformation.EId = jObject["eid"].ToString();
            Debug.Log(jObject.ToString());
        }

        /// <summary>
        /// 上传数据(Base64)
        /// </summary>
        /// <param name="interType">上传类型</param>
        /// <param name="data">数据</param>
        public void UpLoadForNormalPlatformWithBase64(WebInterType interType, string data) {
            requestType = interType;
            StartCoroutine(UpForNormalPlatform(webInterURLs[interType], data.StringToBase64()));
        }

        /// <summary>
        /// 上传数据(明文)
        /// </summary>
        /// <param name="interType">上传类型</param>
        /// <param name="data">数据</param>
        public void UpLoadForNormalPlatform(WebInterType interType,string data) {
            requestType = interType;
            StartCoroutine(UpForNormalPlatform(webInterURLs[interType], data));
        }

        private IEnumerator UpForNormalPlatform(string url,string data) {
#if UNITY_WEBGL

            Dictionary<string, string> postdata = new Dictionary<string, string>();
            postdata.Add("param", data);
            UnityWebRequest request = UnityWebRequest.Post(url, postdata);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return request.SendWebRequest();
            WebRequestCallBack(request.responseCode, request.downloadHandler.text);

#elif UNITY_WEBPLAYER

            WWWForm pdata = new WWWForm();
            pdata.AddField("param", data);
            if (!pdata.headers.ContainsKey("Content-Type"))
            {
                pdata.headers.Add("Content-Type", "application/x-www-form-urlencoded");
            }
            WWW www = new WWW(url, pdata);
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            { Debug.Log(www.error); }              //如这里报错跨域访问，把edit里的 projectsetting 里的host url改成自己实验的主页地址       
            WebRequestCallBack(1, www.text);

#endif

#if UNITY_STANDALONE && UNITY_5
            WWWForm pdata = new WWWForm();
            pdata.AddField("param", data);
            if (!pdata.headers.ContainsKey("Content-Type"))
            {
                pdata.headers.Add("Content-Type", "application/x-www-form-urlencoded");
            }
            WWW www = new WWW(url, pdata);
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            { Debug.Log(www.error); }              //如这里报错跨域访问，把edit里的 projectsetting 里的host url改成自己实验的主页地址       
            WebRequestCallBack(1, www.text);
#elif UNITY_STANDALONE && !UNITY_5
            Dictionary<string, string> postdata = new Dictionary<string, string>();
            postdata.Add("param", data);
            UnityWebRequest request = UnityWebRequest.Post(url, postdata);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return request.SendWebRequest();
            WebRequestCallBack(request.responseCode, request.downloadHandler.text);

#endif
        }

        /// <summary>
        /// 简易平台登陆
        /// </summary>
        /// <param name="data">登陆信息</param>
        private void LoginForSimplePlatform(string data) {
            StartCoroutine(LoginForSimplePlatform(webInterURLs[WebInterType.CloudLogin], data));
        }

        private IEnumerator LoginForSimplePlatform(string url, string data)
        {
#if UNITY_STANDALONE && UNITY_5
            WWWForm pdata = new WWWForm();
            pdata.AddField("sequenceCode", data);
            if (!pdata.headers.ContainsKey("Content-Type"))
            {
                pdata.headers.Add("Content-Type", "application/x-www-form-urlencoded");
            }
            WWW www = new WWW(url, pdata);
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            { Debug.Log(www.error); }              //如这里报错跨域访问，把edit里的 projectsetting 里的host url改成自己实验的主页地址       
            WebRequestCallBack(1, www.text);
#elif UNITY_STANDALONE && !UNITY_5
            Dictionary<string, string> postdata = new Dictionary<string, string>();
            postdata.Add("sequenceCode", data);
            UnityWebRequest request = UnityWebRequest.Post(url, postdata);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return request.SendWebRequest();
            WebRequestCallBack(request.responseCode, request.downloadHandler.text);
#else
            yield return null;
#endif
        }

        /// <summary>
        /// 简易平台上传分数
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="data">数据</param>
        public void UpLoadScoreForSimplePlatform(string url, string data)
        {
            StartCoroutine(UpForSimplePlatform(url, data));
        }

        private IEnumerator UpForSimplePlatform(string url, string data)
        {

#if UNITY_5
            byte[] body = Encoding.UTF8.GetBytes(data);
            Dictionary<string, string> pdata = new Dictionary<string, string>();
            pdata.Add("Content-Type", "application/json;charset=UTF-8");
            WWW www = new WWW(url, body ,pdata);
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            { Debug.Log(www.error); }              //如这里报错跨域访问，把edit里的 projectsetting 里的host url改成自己实验的主页地址       
            WebRequestCallBack(1, www.text);
#elif !UNITY_5
            byte[] body = Encoding.UTF8.GetBytes(data);
            UnityWebRequest request = UnityWebRequest.Post(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(body);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json;charset=UTF-8");
            yield return request.SendWebRequest();
            WebRequestCallBack(request.responseCode, request.downloadHandler.text);
#else
            yield return null;
#endif
        }

        #endregion


        #region PC版两种登陆方式

        /// <summary>
        /// PC版登陆（仅用于通用平台PC客户端版实验登陆）
        /// </summary>
        /// <param name="username">用户名（问平台要）</param>
        /// <param name="password">密码（问平台要）</param>
        /// <param name="esid">esid（跟平台协商确定）</param>
        /// <param name="callback">回调</param>
        public void LoginForPC(string username, string password, string esid, UnityAction<string> callback)
        {
            JObject loginInfo = new JObject();
            loginInfo.Add("account", username);
            loginInfo.Add("password", password);
            loginInfo.Add("esid", esid);
            Debug.Log("当前用户登录信息：[" + loginInfo.ToString() + "]");
            UpLoadForNormalPlatformWithBase64(WebInterType.PCClientLogin, loginInfo.ToString());
            webCallBack = (str) => {
                try
                {
                    JObject jObject = JsonConvert.DeserializeObject<JObject>(str.Base64ToString());
                    IEnumerable<JToken> expList = jObject["expList"];
                    //Dictionary<string, string> expNameId = new Dictionary<string, string>();//实验历史记录
                    List<string> idList = new List<string>();//实验eid记录
                    foreach (var item in expList)
                    {
                        //expNameId.Add(item["name"].ToString(), item["id"].ToString());
                        idList.Add(item["id"].ToString());
                    }
                    LoginInformation.EId = idList[0];//实验记录里面最新的一条的id
                    LoginInformation.Role = jObject["role"].ToString();
                    LoginInformation.NumberId = jObject["numberId"].ToString();
                    LoginInformation.Name = jObject["name"].ToString();
                    callback(jObject["status"].ToString());
                }
                catch (System.Exception)
                {
                    Debug.LogError("登陆未成功，错误信息为：" + str);
                }
            };
        }

        /// <summary>
        /// 云渲染版本登陆（两个平台通用）
        /// </summary>
        public void LoginForCloud() {
            JObject jo = new JObject();
            switch (platform)
            {
                case PlatformSelect.NormalPlatform:
                    jo["token"] = cloudKeyCode;
                    UpLoadForNormalPlatformWithBase64(WebInterType.CloudLogin, jo.ToString());
                    webCallBack = (str) => {
                        try
                        {
                            JObject jObject = JsonConvert.DeserializeObject<JObject>(str.Base64ToString());
                            LoginInformation.EId = jObject["eId"].ToString() ;//eld
                            LoginInformation.Role = jObject["role"].ToString();
                            LoginInformation.NumberId = jObject["numberId"].ToString();
                            LoginInformation.Name = jObject["name"].ToString();
                            LoginInformation.GroupName = jObject["groupName"].ToString();
                            LoginInformation.UserId = jObject["userId"].ToString();
                        }
                        catch (Exception)
                        {

                            Debug.LogError("登陆失败，返回信息为："+ str.Base64ToString());
                        }
                    };
                    break;
                case PlatformSelect.SimplePlatform:
                    LoginForSimplePlatform(cloudKeyCode);
                    webCallBack = (str) => {
                        JObject jObject = JsonConvert.DeserializeObject<JObject>(str);
                        if (jObject["error"].ToString() == string.Empty)
                        {
                            IEnumerable<JToken> expList = jObject["expList"];
                            if (expList != null)
                            {
                                List<string> idList = new List<string>();//实验eid记录
                                foreach (var item in expList)
                                {
                                    idList.Add(item["expId"].ToString());
                                }
                                LoginInformation.ExpId = idList[0];//实验ID
                                LoginInformation.UpLoadScoreURLKey = jObject["urlDataPost"].ToString();//实验上传分数URLKey
                            }
                        }
                        else
                        {
                            Debug.LogError("登陆失败，返回信息为：" + str);
                        }
                    };
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 云渲染版本登陆（两个平台通用，带回调，测试用）
        /// </summary>
        /// <param name="callback">回调</param>
        public void LoginForCloud(UnityAction<string> callback)
        {
            JObject jo = new JObject();
            switch (platform)
            {
                case PlatformSelect.NormalPlatform:
                    jo["token"] = cloudKeyCode;
                    UpLoadForNormalPlatformWithBase64(WebInterType.CloudLogin, jo.ToString());
                    webCallBack = (str) => {
                        try
                        {
                            JObject jObject = JsonConvert.DeserializeObject<JObject>(str.Base64ToString());
                            LoginInformation.EId = jObject["eId"].ToString();//eld
                            LoginInformation.Role = jObject["role"].ToString();
                            LoginInformation.NumberId = jObject["numberId"].ToString();
                            LoginInformation.Name = jObject["name"].ToString();
                            LoginInformation.GroupName = jObject["groupName"].ToString();
                            LoginInformation.UserId = jObject["userId"].ToString();
                            callback(jObject["status"].ToString());
                        }
                        catch (Exception)
                        {
                            Debug.LogError("登陆失败，返回信息为：" + str.Base64ToString());
                            callback("登陆失败，返回信息为：" + str.Base64ToString());
                        }
                    };
                    break;
                case PlatformSelect.SimplePlatform:
                    LoginForSimplePlatform(cloudKeyCode);
                    webCallBack = (str) => {
                        JObject jObject = JsonConvert.DeserializeObject<JObject>(str);
                        if (jObject["error"].ToString() == string.Empty)
                        {
                            IEnumerable<JToken> expList = jObject["expList"];
                            if (expList != null)
                            {
                                List<string> idList = new List<string>();//实验eid记录
                                foreach (var item in expList)
                                {
                                    idList.Add(item["expId"].ToString());
                                }
                                LoginInformation.ExpId = idList[0];//实验ID
                                LoginInformation.UpLoadScoreURLKey = jObject["urlDataPost"].ToString();//实验上传分数URLKey
                                callback("登陆成功");
                            }
                            callback("无实验列表");
                        }
                        else
                        {
                            Debug.LogError("登陆失败，返回信息为：" + str);
                            callback("登陆失败，返回信息为：" + str);
                        }
                    };
                    break;
                default:
                    break;
            }
        }
        #endregion


        #region 上传数据 

        /// <summary>
        /// 上传分数(各版本都通用)
        /// </summary>
        /// <param name="score">分数</param>
        public void UpLoadScore(string score) {
            switch (platform)
            {
                case PlatformSelect.NormalPlatform:
                    JObject jo = new JObject();
                    jo.Add("numberId", new JValue(LoginInformation.NumberId));//学号
                    jo.Add("name", new JValue(LoginInformation.Name));//名字
                    jo.Add("eid", new JValue(LoginInformation.EId));//实验唯一数据标识
                    jo.Add("expScore", new JValue(score));//成绩分数
                    UpLoadForNormalPlatform(WebInterType.UpLoadScore, JsonConvert.SerializeObject(jo));
                    webCallBack = (str) => {
                        try
                        {
                            JObject jObject = JsonConvert.DeserializeObject<JObject>(str);
                            Debug.Log(jObject["status"].ToString());
                        }
                        catch (System.Exception)
                        {
                            Debug.LogError("上传分数未成功，错误信息为：" + str);
                        }
                    };
                    break;
                case PlatformSelect.SimplePlatform:
#if UNITY_STANDALONE
                    string upLoadScoreURL = simplePlatformHostURL + LoginInformation.UpLoadScoreURLKey + "/" + simplePlatformHostID + "/" + LoginInformation.ExpId;
                    JArray body = new JArray();
                    JObject obj = new JObject();
                    obj.Add("moduleFlag", "实验成绩");
                    obj.Add("questionNumber", 1);
                    obj.Add("questionStem", "学生操作成绩");
                    obj.Add("score", score);//成绩分数
                    obj.Add("trueOrFalse", "True");
                    body.Add(obj);
                    UpLoadScoreForSimplePlatform(upLoadScoreURL, JsonConvert.SerializeObject(body));
                    webCallBack = (str) => {
                        Debug.Log(str);
                    };
#elif UNITY_WEBGL
                    JObject scoreValue = new JObject();
                    scoreValue.Add("moduleFlag", "实验成绩");
                    scoreValue.Add("questionNumber", new JValue(1));
                    scoreValue.Add("questionStem", "学生实验操作成绩");
                    scoreValue.Add("scores", new JValue(score));
                    scoreValue.Add("isTrue", "True");
                    JArray value = new JArray();
                    value.Add(scoreValue);
                    UpLoadScoreForSPWebGL.UpLoadScore(JsonConvert.SerializeObject(value));
#elif UNITY_WEBPLAYER
                    JObject scoreValue = new JObject();
                    scoreValue.Add("moduleFlag", "实验成绩");
                    scoreValue.Add("questionNumber", new JValue(1));
                    scoreValue.Add("questionStem", "学生实验操作成绩");
                    scoreValue.Add("scores", new JValue(score));
                    scoreValue.Add("isTrue", "True");
                    JArray value = new JArray();
                    value.Add(scoreValue);
                    Application.ExternalCall("ReciveData", JsonConvert.SerializeObject(value));
#endif
        //***********如果使用简易平台上传分数，并且使用webGL或者webplayer版本，需要在打包出来的index.html里加入下面这段代码
        //            function GetQueryString(name)
        //            {
        //                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        //                var r = window.location.search.substr(1).match(reg);
        //                if (r != null) return unescape(r[2]); return null;
        //            }

        //            var domainUrl = window.location.protocol + "//" + window.location.host;

        //            var referer = document.referrer;
        //            if (referer)
        //            {
        //                if (referer.indexOf("http://") != -1)
        //                {
        //                    domainUrl = referer.substring(0, referer.indexOf("/", referer.indexOf("http://") + 7));
        //                }
        //                else if (referer.indexOf("https://") != -1)
        //                {
        //                    domainUrl = referer.substring(0, referer.indexOf("/", referer.indexOf("https://") + 8));
        //                }
        //            }


        //            var token = GetQueryString("token").split('_');
        //            var name = "";
        //            var tokenValue = "";
        //            var urlDataPost = "";
        //$.getJSON(domainUrl + "/openapi/" + token[0] + "/" + token[1], function(result) {
        //                name = result.name;
        //                tokenValue = result.token;
        //                urlDataPost = domainUrl + result.urlDataPost;
        //            });

        //            function ReciveData(str)
        //            {
        //    $.ajax({
        //                timeout: 20000,
        //        type: "POST",
        //        dataType: "JSON",
        //        contentType: 'application/json;charset=UTF-8',
        //        url: urlDataPost + "/" + token[0] + "/" + token[1],
        //        data: str,
        //        success: function(data) {
        //                        console.log("恭喜您已经完成实验学习！");
        //                    },
        //        error: function(jqXHR, textStatus, errorThrown) {
        //                        /*弹出jqXHR对象的信息*/
        //                        console.log(jqXHR.responseText);
        //                    }
        //                    //注意：这里不能加下面这行，否则数据会传不到后台
        //                    //contentType:'application/json;charset=UTF-8',
        //                });
        //    }

        //    window.addEventListener('message', function(event) {
        //    console.log(event.data);
        //        if (event.data.name != 'changePosition') {
        //    return;
        //}
        //        if (event.data.switch == true) {
        //    document.getElementById('unityPlayer').style = "position: static;";
        //} else {
        //    document.getElementById('unityPlayer').style = "position: absolute;left: -9999px;top: -9999px;";
        //}
        //}, false);
        //*****************************************************************************************************************************
                    break;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// 上传分数(各版本都通用，有回调，测试用)
        /// </summary>
        /// <param name="score">分数</param>
        public void UpLoadScore(string score, UnityAction<string> callback)
        {
            switch (platform)
            {
                case PlatformSelect.NormalPlatform:
                    JObject jo = new JObject();
                    jo.Add("numberId", new JValue(LoginInformation.NumberId));//学号
                    jo.Add("name", new JValue(LoginInformation.Name));//名字
                    jo.Add("eid", new JValue(LoginInformation.EId));//实验唯一数据标识
                    jo.Add("expScore", new JValue(score));//成绩分数
                    UpLoadForNormalPlatform(WebInterType.UpLoadScore, JsonConvert.SerializeObject(jo));
                    webCallBack = (str) => {
                        try
                        {
                            JObject jObject = JsonConvert.DeserializeObject<JObject>(str);
                            Debug.Log(jObject["status"].ToString());
                            callback(jObject["status"].ToString());
                        }
                        catch (System.Exception)
                        {
                            Debug.LogError("上传分数未成功，错误信息为：" + str);
                            callback("上传分数未成功，错误信息为：" + str);
                        }
                    };
                    break;
                case PlatformSelect.SimplePlatform:
#if UNITY_STANDALONE
                    string upLoadScoreURL = simplePlatformHostURL + LoginInformation.UpLoadScoreURLKey + "/" + simplePlatformHostID + "/" + LoginInformation.ExpId;
                    JArray body = new JArray();
                    JObject obj = new JObject();
                    obj.Add("moduleFlag", "实验成绩");
                    obj.Add("questionNumber", 1);
                    obj.Add("questionStem", "学生操作成绩");
                    obj.Add("score", score);//成绩分数
                    obj.Add("trueOrFalse", "True");
                    body.Add(obj);
                    UpLoadScoreForSimplePlatform(upLoadScoreURL, JsonConvert.SerializeObject(body));
                    webCallBack = (str) => {
                        Debug.Log(str);
                        callback(str);
                    };
#elif UNITY_WEBGL
                    JObject scoreValue = new JObject();
                    scoreValue.Add("moduleFlag", "实验成绩");
                    scoreValue.Add("questionNumber", new JValue(1));
                    scoreValue.Add("questionStem", "学生实验操作成绩");
                    scoreValue.Add("scores", new JValue(score));
                    scoreValue.Add("isTrue", "True");
                    JArray value = new JArray();
                    value.Add(scoreValue);
                    UpLoadScoreForSPWebGL.UpLoadScore(JsonConvert.SerializeObject(value));
                    callback("上传操作成功，请到平台上查看是否有成绩");
#elif UNITY_WEBPLAYER
                    JObject scoreValue = new JObject();
                    scoreValue.Add("moduleFlag", "实验成绩");
                    scoreValue.Add("questionNumber", new JValue(1));
                    scoreValue.Add("questionStem", "学生实验操作成绩");
                    scoreValue.Add("scores", new JValue(score));
                    scoreValue.Add("isTrue", "True");
                    JArray value = new JArray();
                    value.Add(scoreValue);
                    Application.ExternalCall("ReciveData", JsonConvert.SerializeObject(value));
                    callback("上传操作成功，请到平台上查看是否有成绩");
#endif
                    break;
                default:
                    break;
            }

        }

        //简易平台不支持上传表格（通用平台自行封装）
        //public void UpLoadTable() {
        //
        //}

        #endregion
    }
}

