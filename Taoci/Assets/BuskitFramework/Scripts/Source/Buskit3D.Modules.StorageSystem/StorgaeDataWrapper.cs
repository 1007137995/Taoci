/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：StorgaeDataWrapper
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using System.IO;
using Newtonsoft.Json.Linq;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 
    /// </summary>
    public  class StorgaeDataWrapper
    {
        /// <summary>
        /// 序列化工具实例
        /// </summary>
        [Inject]
        IServiceSerializer _serviceSerializer;


        /// <summary>
        /// 构造函数
        /// </summary>
        public StorgaeDataWrapper()
        {
            InjectService.InjectInto(this);
        }

        /// <summary>
        /// 将数据写入本地文本
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="json"></param>
        /// <param name="fileMode"></param>
        public void DataToFile(string filePath, string json,FileMode fileMode=FileMode.Create)
        {
            using (FileStream fs = new FileStream(filePath, fileMode, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(json);
                sw.Close();
            }
        }

        /// <summary>
        /// 生成测试文本
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jObject"></param>
        /// <param name="fileMode"></param>
        public void DataToTestFile(string filePath, JObject jObject, FileMode fileMode = FileMode.Create)
        {
#if UNITY_STANDALONE_WIN
            using (FileStream fs = new FileStream(filePath, fileMode, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("*********************************ReplayData**********************************");
                sw.Write(jObject["ReplayData"]);
                sw.WriteLine("*********************************RestoreData**********************************");
                sw.Write(jObject["RestoreData"]);
                sw.Close();
#if UNITY_EDITOR
                UnityEditor.AssetDatabase.Refresh();
#endif
            }
#endif
        }

        /// <summary>
        /// 从文件中读取数据到字符串数组中
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string[] FileToString(string filePath)
        {
            string[] data=null;
#if Local_Mode
#if UNITY_STANDALONE_WIN
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string allstr = sr.ReadToEnd();
                JObject jo = (JObject)_serviceSerializer.DeSerializerObject(allstr);
                data = new string[] { jo["ReplayData"].ToString(), jo["RestoreData"].ToString() };
                sr.Close();
            }
#endif
#if UNITY_WEBGL
            JObject jo = (JObject)_serviceSerializer.DeSerializerObject(filePath);
            data = new string[] { jo["ReplayData"].ToString(), jo["RestoreData"].ToString() };
#endif
#endif
#if Lab_Mode
            JObject jo = (JObject)_serviceSerializer.DeSerializerObject(filePath);
            data = new string[] { jo["ReplayData"].ToString(), jo["RestoreData"].ToString() };
#endif
            return data;
        }
    }
}
