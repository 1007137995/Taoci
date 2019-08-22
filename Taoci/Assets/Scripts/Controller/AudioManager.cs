using UnityEngine;
using System.Collections;

namespace TaoCi
{
    public class AudioManager : MonoBehaviour
    {
        /*******************************************************************************
        * 版权声明：北京润尼尔网络科技有限公司，保留所有版权
        * 版本声明：v1.0.0
        * 项目名称：中山大学压疮知识点
        * 类 名 称：AudioManager       
        * 创建日期：2018年8月     
        * 作者名称：邹袁
        * 功能描述：
        * 修改记录：
        * 日期 描述 更新功能
        * 
        ******************************************************************************/
        public static AudioManager instance;
        private AudioSource audioSource;
        // Use this for initialization
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            audioSource = gameObject.AddComponent<AudioSource>();
            gameObject.tag = "clip";
        }
        public void PlayAudio(AudioClip _clip)
        {
            if (audioSource.isPlaying) return;
            audioSource.PlayOneShot(_clip);
        }
        public void StopAudio()
        {
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
