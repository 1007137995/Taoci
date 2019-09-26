/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.BusKit
* 类 名 称：EditorConfig
* 创建日期：2017/12/5 18:08:08
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：编辑器配置工具
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/


using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 名称空间定义：Buskit3D.ScriptHelper
/// </summary>
namespace Buskit3D.ScriptHelper
{

    /// <summary>
    /// 类 名 称：Buskit3D.ScriptHelper
    /// 类 工 能：
    /// 主要接口：
    /// </summary>
    public class EditorScriptsConfig  : ScriptableObject
	{
        /// <summary>
        /// 作者
        /// </summary>
        [Header("作者")]
        public  string Author = "Author";

        /// <summary>
        /// 命名空间
        /// </summary>
        [Header("名称空间")]
        public string NameSpace= "NameSpace.Author";

        /// <summary>
        /// 模板路径
        /// </summary>
        [Header("模板路劲")]
        public  string TemplatePath = "Assets/ScriptHelper/Template/";
  

        private const string EditorScriptsConfigFile = "EditorScriptsConfigFile.asset";

        private static string editorScriptsConfigCsPath;
        public static string EditorScriptsConfigCsPath
        {
            get
            {
                if (!string.IsNullOrEmpty(editorScriptsConfigCsPath))
                {
                    return editorScriptsConfigCsPath;
                }

                var result = Directory.GetFiles(Application.dataPath+"/ScriptHelper", "EditorScriptsConfig.cs", SearchOption.AllDirectories);
                if (result.Length >= 1)
                {
                    editorScriptsConfigCsPath = Path.GetDirectoryName(result[0]);
                    editorScriptsConfigCsPath = editorScriptsConfigCsPath.Replace('\\', '/');
                    editorScriptsConfigCsPath = editorScriptsConfigCsPath.Replace(Application.dataPath, "Assets");

                    editorScriptsConfigCsPath = editorScriptsConfigCsPath + "/" + EditorScriptsConfigFile;
                }

                return editorScriptsConfigCsPath;
            }
        }

        private static EditorScriptsConfig instanceField;
        public static EditorScriptsConfig Instance
        {
            get
            {
                if (instanceField != null)
                {
                    return instanceField;
                }

                instanceField = (EditorScriptsConfig)AssetDatabase.LoadAssetAtPath(EditorScriptsConfigCsPath, typeof(EditorScriptsConfig));
                if (instanceField == null)
                {
                    instanceField = ScriptableObject.CreateInstance<EditorScriptsConfig>();
                    AssetDatabase.CreateAsset(instanceField, EditorScriptsConfigCsPath);
                }

                return instanceField;
            }
        }

    }
}

