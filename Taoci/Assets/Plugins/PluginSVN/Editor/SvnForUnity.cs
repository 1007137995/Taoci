/***************************************************
* Filename: BuildHelper.cs
* Description: 
* Version: 1.0
* Created: 
* Author: GuanNanWang
***************************************************/


using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Diagnostics;


/// <summary>
/// SVN
/// </summary>
public class SvnForUnity
{

    static string SVN_BASE = Application.dataPath.Replace("/", "\\").Remove(Application.dataPath.Replace("/", "\\").Length - 6, 6);

    [InitializeOnLoadMethod]
    static void StartInitializeOnLoadMethod()
    {
        EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGUI;
    }

    static void ProjectWindowItemOnGUI(string instanceID, Rect selectionRect)
    {
        if (Event.current != null && Event.current.button == 1 && Event.current.type <= EventType.MouseUp && Event.current.control)
        {
            Vector2 mousePosition = Event.current.mousePosition;
            EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "SVN", null);
        }
    }

    /// <summary>
    /// SVN更新
    /// </summary>
    [MenuItem("SVN/Update %g", false, 1)]
    public static void SvnUpdate()
    {
        ProcessCommand("TortoiseProc.exe", "/command:update /path:\"" + SVN_BASE + "Assets" + "\"");
    }
    /// <summary>
    /// SVN提交
    /// </summary>
    [MenuItem("SVN/Commit", false, 2)]
    public static void SvnCommit()
    {
        ProcessCommand("TortoiseProc.exe", "/command:commit /path:\"" + SVN_BASE + "Assets" + "\"");
    }
    /// <summary>
    /// SVN选择并提交
    /// </summary>
    [MenuItem("SVN/CommitSelect", false, 3)]
    public static void SvnCommitSelect()
    {
        if (Selection.GetFiltered(typeof(object), SelectionMode.Assets).Length > 0)
        {
            string selectionPath = string.Empty;
            for (int i = 0; i < Selection.GetFiltered(typeof(object), SelectionMode.Assets).Length; i++)
            {
                if (i > 0)
                {
                    selectionPath = selectionPath + "*" + SVN_BASE + AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i]).Replace("/", "\\");
                    selectionPath = selectionPath + "*" + SVN_BASE + MetaFile(AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i])).Replace("/", "\\");
                }
                else
                {
                    selectionPath = SVN_BASE + AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i]).Replace("/", "\\");
                    selectionPath = selectionPath + "*" + SVN_BASE + MetaFile(AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i])).Replace("/", "\\");
                }
            }
            ProcessCommand("TortoiseProc.exe", "/command:commit /path:\"" + selectionPath + "\"");
        }
    }
    /// <summary>
    /// SVN显示信息
    /// </summary>
    [MenuItem("SVN/TortoiseSVN/Logs", false, 4)]
    public static void SvnLog()
    {
        ProcessCommand("TortoiseProc.exe", "/command:log /path:\"" + SVN_BASE + "\"");
    }
    /// <summary>
    /// SVN设置
    /// </summary>
    [MenuItem("SVN/TortoiseSVN/Settings", false, 5)]
    public static void SvnSetting()
    {
        ProcessCommand("TortoiseProc.exe", "/command:settings \"\"");
    }
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/TortoiseSVN/Rename", false, 6)]
    public static void SvnRename()
    {
        if (Selection.GetFiltered(typeof(object), SelectionMode.Assets).Length == 1)
        {
            string selectionPath = SVN_BASE + AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[0]).Replace("/", "\\");
            ProcessCommand("TortoiseProc.exe", "/command:rename /path:\"" + selectionPath + "\"");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/TortoiseSVN/Remove", false, 7)]
    public static void SvnRemove()
    {
        if (Selection.GetFiltered(typeof(object), SelectionMode.Assets).Length > 0)
        {
            string selectionPath = string.Empty;
            for (int i = 0; i < Selection.GetFiltered(typeof(object), SelectionMode.Assets).Length; i++)
            {
                if (i > 0)
                {
                    selectionPath = selectionPath + "*" + SVN_BASE + AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i]).Replace("/", "\\");
                    selectionPath = selectionPath + "*" + SVN_BASE + MetaFile(AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i])).Replace("/", "\\");
                }
                else
                {
                    selectionPath = SVN_BASE + AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i]).Replace("/", "\\");
                    selectionPath = selectionPath + "*" + SVN_BASE + MetaFile(AssetDatabase.GetAssetPath(Selection.GetFiltered(typeof(object), SelectionMode.Assets)[i])).Replace("/", "\\");
                }
            }
            ProcessCommand("TortoiseProc.exe", "/command:remove /path:\"" + selectionPath + "\"");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/TortoiseSVN/Merge", false, 8)]
    public static void SvnMerge()
    {
        ProcessCommand("TortoiseProc.exe", "/command:log /path:\"" + SVN_BASE + "\"");
    }
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/TortoiseSVN/Help", false, 9)]
    public static void SvnHelp()
    {
        ProcessCommand("TortoiseProc.exe", "/command:help \"\"");
    }
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/ProjectSettings/Update", false, 10)]
    public static void ProjectSettingsUpdate()
    {
        ProcessCommand("TortoiseProc.exe", "/command:update /path:\"" + SVN_BASE + "ProjectSettings" + "\"");
    }
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/ProjectSettings/Commit", false, 11)]
    public static void ProjectSettingsCommit()
    {
        ProcessCommand("TortoiseProc.exe", "/command:commit /path:\"" + SVN_BASE + "ProjectSettings" + "\"");
    }
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/VisualSVN Server", false, 12)]
    public static void SvnServer()
    {
        ProcessCommand("VisualSVN Server.msc", string.Empty);
    }
    //[MenuItem("SVN/AssetsFile", false, 10)]
    //public static void AssetsFile()
    //{
    //    processCommand("explorer.exe", SVN_BASE + "Assets");
    //}
    /// <summary>
    /// 
    /// </summary>
    [MenuItem("SVN/Relocate", false, 13)]
    public static void Relocate()
    {
        ProcessCommand("TortoiseProc.exe", "/command:relocate /path:\"" + SVN_BASE + "\"");
    }

    [MenuItem("SVN/FirstSetting", false, 14)]
    public static void SetEditor()
    {
        if (EditorSettings.serializationMode!= SerializationMode.ForceText)
        {
            EditorSettings.serializationMode = SerializationMode.ForceText;
            UnityEngine.Debug.Log("SerializationMode"+ "=>ForceText");
        }
        if (EditorSettings.externalVersionControl != "Visible Meta Files")
        {
            EditorSettings.externalVersionControl = "Visible Meta Files";
            UnityEngine.Debug.Log("externalVersionControl" + "=>Visible Meta Files");
        }
        UnityEngine.Debug.Log("SVN for Unity is OK");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="argument"></param>
    private static void ProcessCommand(string command, string argument)
    {
        ProcessStartInfo start = new ProcessStartInfo(command)
        {
            Arguments = argument,
            CreateNoWindow = false,
            ErrorDialog = true,
            UseShellExecute = true
        };

        if (start.UseShellExecute)
        {
            start.RedirectStandardOutput = false;
            start.RedirectStandardError = false;
            start.RedirectStandardInput = false;
        }
        else
        {
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.RedirectStandardInput = true;
            start.StandardOutputEncoding = System.Text.Encoding.UTF8;
            start.StandardErrorEncoding = System.Text.Encoding.UTF8;
        }

        Process p = Process.Start(start);
        
        p.WaitForExit();
        p.Close();
    }
    
    static string MetaFile(string str)
    {
        return str + ".meta";
    }

}
