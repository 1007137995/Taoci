
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： RainierMenu
* 创建日期：2019-02-20 15:51:39
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D
{
    //public class CNLanguage
    //{
    //    public string Save = "保存";
    //    public string Load = "加载";
    //    public string Restore = "场景还原";
    //    public string Replay = "实验回放";
    //    public string Back = "返回";
    //    public string Play = "播放";
    //    public string Playing = "播放中";
    //    public string Pause = "暂停";
    //}
    //public class EnLanguage
    //{
    //    public string Save = "Save";
    //    public string Load = "Load";
    //    public string Restore = "Restore";
    //    public string Replay = "Replay";
    //    public string Back = "Back";
    //    public string Play = "Play";
    //    public string Playing = "Playing";
    //    public string Pause = "Pause";
    //}

    /// <summary>
    /// 初始化菜单项  
    /// </summary>
	public class StorageSystemUGUI : MonoBehaviour 
	{
       
        public Transform playPanel;
        public Transform selectPanel;
        public Slider processSlider;
        public Transform maskTrans;

        private static string playButton = "PlayButton";
        private static string pauseButton = "PauseButton";
        private static string buttonState = "Play";

        private bool isPlaying = false;
        private bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
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
        private bool isPause = false;
        private bool IsPause
        {
            get { return isPause; }
            set
            {

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
                   Time.timeScale=SelectSpeed;
                }

            }
        }
        private int selectSpeed = 1;
        public int SelectSpeed
        {
            get { return selectSpeed; }
            set
            {
                selectSpeed = value;
                if (IsPlaying && !IsPause)
                    Time.timeScale = value;
            }
        }

        StorageSystem _storageSystem;

        /// <summary>
        /// 保存场景数据
        /// </summary>
        public void SaveScene()
        {
            _storageSystem.SaveStorageData();
        }

        /// <summary>
        /// 保存智能指导脚本
        /// </summary>
        public void SaveIgcs()
        {
            _storageSystem.SaveIgcsData();
        }

        /// <summary>
        /// 加载场景数据
        /// </summary>
        public void LoadScene()
        {
            _storageSystem.LoadStorageData();
            ShowMenu(2);
        }
        /// <summary>
        /// 场景还原
        /// </summary>
        public void RestoreScene()
        {
            _storageSystem.RestoreScene();
            ScreenMask.ShowMask(Color.black, 3, MaskType.BigBar);
        }

        /// <summary>
        /// 场景回放
        /// </summary>
        public void ReplayScene()
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                _storageSystem.BeginReplay(ReplayOverCallBack);
                maskTrans.gameObject.SetActive(true);
            }
            else
            {
                IsPause = !IsPause;
            }
        }

        /// <summary>
        /// 设置播放速度
        /// </summary>
        /// <param name="speed"></param>
        public void SetPlaySpeed(int speed)
        {
            SelectSpeed = speed;
        }

        /// <summary>
        /// 回放结束回调
        /// </summary>
        public void ReplayOverCallBack()
        {
            IsPlaying = false;
            ShowMenu(1);
            Time.timeScale = 1;
            maskTrans.gameObject.SetActive(false);
        }

        /// <summary>
        /// 设置菜单显示隐藏
        /// </summary>
        /// <param name="level"></param>
        public void ShowMenu(int level)
        {
            switch (level)
            {
                case 1:
                    playPanel.gameObject.SetActive(false);
                    selectPanel.gameObject.SetActive(true);
                    selectPanel.Find("FirstBtns").gameObject.SetActive(true);
                    selectPanel.Find("SecondBtns").gameObject.SetActive(false);
                    break;
                   
                case 2:
                    selectPanel.gameObject.SetActive(true);
                    selectPanel.Find("FirstBtns").gameObject.SetActive(false);
                    selectPanel.Find("SecondBtns").gameObject.SetActive(true);
                    break;
                case 3:
                    selectPanel.gameObject.SetActive(false);
                    playPanel.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Unity Method
        /// </summary>
        void Start () 
		{
            _storageSystem = GameObject.FindObjectOfType<StorageSystem>();
            selectPanel.Find("FirstBtns/Save").gameObject.SetClick(p=>SaveScene());
            selectPanel.Find("FirstBtns/SaveIgcs").gameObject.SetClick(p => SaveIgcs());
            selectPanel.Find("FirstBtns/Load").gameObject.SetClick(p =>LoadScene());
            selectPanel.Find("SecondBtns/Restore").gameObject.SetClick(p => RestoreScene());
            selectPanel.Find("SecondBtns/Replay").gameObject.SetClick(p => ShowMenu(3));
            selectPanel.Find("SecondBtns/Back").gameObject.SetClick(p => ShowMenu(1));

            playPanel.Find("Play").gameObject.SetClick(p => ReplayScene());
            playPanel.Find("1x").gameObject.SetClick(p => SetPlaySpeed(1));
            playPanel.Find("2x").gameObject.SetClick(p => SetPlaySpeed(2));
            playPanel.Find("3x").gameObject.SetClick(p => SetPlaySpeed(3));
            processSlider = playPanel.Find("processSlider").GetComponent<Slider>();
           
        }

        /// <summary>
        /// Unity Method
        /// </summary>
        void Update ()
		{
            if (IsPlaying)
            {
                processSlider.value = MemoryPlayer.Percent;
               
            }
        }
    }
}

