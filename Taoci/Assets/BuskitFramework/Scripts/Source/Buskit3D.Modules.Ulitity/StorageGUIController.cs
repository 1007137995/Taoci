/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：GUIController
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：json序列化接口
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif
using Com.Rainier.Buskit3D.UI;
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// gui测试工具
    /// </summary>
    public class StorageGUIController : MonoBehaviour
    {
        int menuState = 1;
        private static  string playButton = "PlayButton";
        private  static string pauseButton = "PauseButton";
        private static string buttonState = "Play";
        private bool isPlaying = false;
        private bool IsPlaying { get { return isPlaying; }
            set {
                isPlaying = value;
                if (isPlaying)
                {

#if UNITY_EDITOR
                    playButton = "PlayButton On";
#else 
                    buttonState = "Playing";
#endif 
                }
                else
                {
#if UNITY_EDITOR
                    playButton = "PlayButton";
#else 
                    buttonState = "Play";
#endif 
                    
                }

            }
        }
        private bool isPause=false;
        private bool IsPause {
            get { return isPause; }
            set {

                isPause = value;
                if (isPause)
                {
#if UNITY_EDITOR
                    playButton = "PauseButton On";

#else 
                    buttonState =  "Pause";
#endif
                    Time.timeScale = 0;
                }
                else
                {
#if UNITY_EDITOR
                    playButton = "PlayButton On";

#else 
                    buttonState =  "Playing";
#endif

                }

            }
        }
        private int selectSpeed=0;
        public int SelectSpeed { get { return selectSpeed; }
            set {
                selectSpeed = value;
                if (IsPlaying&&!IsPause)
                    Time.timeScale = value + 1;
            }
        }

        StorageSystem _storageSystem;
        private void Start()
        {
            _storageSystem = GameObject.FindObjectOfType<StorageSystem>();
        }
        
        private void OnGUI()
        {

            if (menuState==1&& GUILayout.Button("StorageToSave"))
            {
                _storageSystem.SaveStorageData();
            }
            if (menuState == 1 && GUILayout.Button("IgcsXmlToSave"))
            {
                _storageSystem.SaveIgcsData();
            }
            if (menuState == 1 && GUILayout.Button("StorageToLoad"))
            {                
                _storageSystem.LoadStorageData();
                menuState = 2;
            }
            if (menuState == 2)
            {
                if (GUILayout.Button("ReplayScene"))
                {
                    menuState = 3;

                }
                if (GUILayout.Button("ReBackScene"))
                {
                    _storageSystem.RestoreScene();
                    ScreenMask.ShowMask(Color.black, 3, MaskType.BigBar);
                }
                if (GUILayout.Button("Back"))
                {
                    menuState = 1;
                }
            }
            if (menuState == 3)
            {
                GUILayout.BeginHorizontal();
#if UNITY_EDITOR
                if (GUILayout.Button(EditorGUIUtility.FindTexture(playButton)))
                {
                    if (!IsPlaying)
                    {

                        IsPlaying = true;
                        _storageSystem.BeginReplay(() => {
                            IsPlaying = false;
                            Time.timeScale = 1;
                        });
                    }
                    else
                    {
                        IsPause = !IsPause;
                    }
                }
#else
             if (GUILayout.Button(buttonState))
             {
                 if (!IsPlaying)
                    {
                        IsPlaying = true;
                        _storageSystem.BeginReplay(()=>IsPlaying=false);
                    }
                    else
                    {
                        IsPause = !IsPause;
                    }
            }

#endif

                SelectSpeed = GUILayout.Toolbar(SelectSpeed, new string[] { "1.0", "2.0", "3.0" });
                GUILayout.EndHorizontal();
                GUILayout.HorizontalSlider(MemoryPlayer.Percent,0f, 1.00f);
                if (GUILayout.Button("Back"))
                {
                    menuState = 2;
                }
            }
        }
    }
}

