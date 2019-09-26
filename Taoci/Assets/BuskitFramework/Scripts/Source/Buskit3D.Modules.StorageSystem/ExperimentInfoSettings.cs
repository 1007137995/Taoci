
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ExperimentInfo
* 创建日期：2019-04-17 15:44:07
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
	public class ExperimentInfoSettings : ScriptableObject
    {
        [Header("当前实验名称与平台一致")]
        public string experimentName = "实验名称";

        [Header("pc版登录平台的esid")]
        public string experimentEsid = "实验esid";

        #region 交互URL
        [Header("Pc版登录Url")]
        public  string loginUrl = "http://sfx.owvlab.net/virexp/outer/login";

        [Header("智能批改数据上传Url")]
        public  string uploadIgcsUrl = "http://sfx.owvlab.net/virexp/outer/intelligent/!guidance";

        [Header("实验数据上传Url")]
        public  string uploadReplayUrl = "http://sfx.owvlab.net/virexp/outer/playback/!submit";

        [Header("实验数据下载Url")]
        public  string downloadReplayUrl = "http://sfx.owvlab.net/virexp/outer/playback/!obtain";

        [Header("实验成绩上传接口Url")]
        public string uploadScoreUrl = "http://sfx.owvlab.net/virexp/outer/intelligent/!expScoreSave";

        [Header("实验报告生成接口Url")]
        public string uploadWordUrl= "http://sfx.owvlab.net/virexp/outer/report/!reportEdit";
        #endregion


    }
}
