/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Com.Rainier.BusKit.Unity.ScriptHelper.Mvvm
* 类 名 称：MvvmInitEditor
* 创建日期：2017/12/5 18:08:08
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：Mvvm初始化编辑器
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

//includes for System
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

///includes for Unity
using UnityEngine;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;

/// <summary>
/// 名称空间定义：Buskit3D.ScriptHelper.Base
/// </summary>
namespace Buskit3D.ScriptHelper
{
    /// <summary>
    /// 类 名 称：#NameSpace#.#ScriptName#
    /// 类 功 能：
    /// 主要接口：
    /// </summary>
    public class CreateAssetAction
    {

        /// <summary>
        /// 添加Assets/Create/Rainier C#子菜单并创建MonoBehaviour脚本
        /// </summary>
        [MenuItem("Assets/Create/Rainier C#", false, 60)]
        public static void CreateNormalCS()
        {
           
            //参数为传递给CreateEventCSScriptAsset类action方法的参数  
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
               ScriptableObject.CreateInstance<CreateEventCSScriptAsset>(),
               GetSelectPathOrFallback() + "/NewScript.cs", EditorGUIUtility.FindTexture("cs Script Icon"),
              EditorScriptsConfig.Instance.TemplatePath+ "NewBehaviour.cs.txt");
            
        }

        /// <summary>
        /// 添加Assets/Create/Rainier Model C#子菜单并创建Model脚本
        /// </summary>
        [MenuItem("Assets/Create/Rainier DataModel C#", false, 60)]
        public static void CreateModelCS()
        {
            //参数为传递给CreateEventCSScriptAsset类action方法的参数  
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
               ScriptableObject.CreateInstance<CreateEventCSScriptAsset>(),
               GetSelectPathOrFallback() + "/NewDataModelScript.cs", EditorGUIUtility.FindTexture("cs Script Icon"),
               EditorScriptsConfig.Instance.TemplatePath+ "DataModelBehaviour.cs.txt");
        }

        /// <summary>
        /// 添加Assets/Create/Rainier ViewModel C#子菜单并创建ViewModel脚本
        /// </summary>
        [MenuItem("Assets/Create/Rainier LogicBehavior C#", false, 60)]
        public static void CreateViewModelCS()
        {
            //参数为传递给CreateEventCSScriptAsset类action方法的参数  
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
               ScriptableObject.CreateInstance<CreateEventCSScriptAsset>(),
               GetSelectPathOrFallback() + "/NewLogicScript.cs", EditorGUIUtility.FindTexture("cs Script Icon"),
               EditorScriptsConfig.Instance.TemplatePath + "LogicBehaviour.cs.txt");
        }

        [MenuItem("Assets/Create/Rainier Entity C#", false, 60)]
        public static void CreateEntity()
        {
            //参数为传递给CreateEventCSScriptAsset类action方法的参数  
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
               ScriptableObject.CreateInstance<CreateEventCSScriptAsset>(),
               GetSelectPathOrFallback() + "/NewDataModelEntityScript.cs", EditorGUIUtility.FindTexture("cs Script Icon"),
               EditorScriptsConfig.Instance.TemplatePath + "EntityBehaviour.cs.txt");
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetSelectPathOrFallback()
        {
            string path = "Assets";
            //遍历选中的资源以获得路径  
            //Selection.GetFiltered是过滤选择文件或文件夹下的物体，assets表示只返回选择对象本身  
            foreach (
                UnityEngine.Object obj in 
                Selection.GetFiltered(typeof(UnityEngine.Object), 
                SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }
            return path;
        }
    }

    //要创建模板文件必须继承EndNameEditAction，重写action方法  
    class CreateEventCSScriptAsset : EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            //创建资源  
            UnityEngine.Object obj = CreateScriptAssetFromTemplate(pathName, resourceFile);
            ProjectWindowUtil.ShowCreatedAsset(obj);//高亮显示资源  
        }

        internal static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
        {
            //获取要创建资源的绝对路径  
            string fullPath = Path.GetFullPath(pathName);

            //读取本地的模板文件  
            StreamReader streamReader = new StreamReader(resourceFile);
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            //获取文件名，不含扩展名  
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);

            //将模板类中的类名替换成你创建的文件名  
            text = Regex.Replace(text, "#ScriptName#", fileNameWithoutExtension);
            text = Regex.Replace(text, "#Author#", EditorScriptsConfig.Instance.Author);
            text = Regex.Replace(text, "#NameSpace#", EditorScriptsConfig.Instance.NameSpace);
            text = Regex.Replace(text, "#NowTime#", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //写入配置文件  
            bool encoderShouldEmitUTF8Identifier = true; //参数指定是否提供 Unicode 字节顺序标记  
            bool throwOnInvalidBytes = false;//是否在检测到无效的编码时引发异常  
            bool append = false;
            UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
            StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
            streamWriter.Write(text);
            streamWriter.Close();
            
            //刷新资源管理器  
            AssetDatabase.ImportAsset(pathName);
            AssetDatabase.Refresh();
            return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
        }
    }

}