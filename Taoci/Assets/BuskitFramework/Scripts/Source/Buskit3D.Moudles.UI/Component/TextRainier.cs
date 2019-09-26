using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Com.Rainier.Buskit3D.UI
{
    /// <summary>
    /// 润尼尔文本框组件
    /// </summary>
    [RequireComponent(typeof(TextModel))]
    [RequireComponent(typeof(TextLogic))]
    public class TextRainier : Text
    {
        /// <summary>
        /// 动态监听频率
        /// </summary>
        public float listeningFrequency = 0.1f;
        /// <summary>
        /// 倒计时
        /// </summary>
        private float countdown;

        protected override void Start()
        {
            base.Start();
            countdown = listeningFrequency;
        }
        protected virtual void Update()
        {
            countdown -= Time.deltaTime;
            if (countdown < 0) {
                countdown = listeningFrequency;
                IsTextChang();
            }
        }
        /// <summary>
        /// 文本内筒是否发生变化
        /// </summary>
        private void IsTextChang()
        {
            UGUIDataEntity uGUIDataEntity = GetComponent<TextModel>().DataEntity as UGUIDataEntity;
            if (uGUIDataEntity == null) return;
            string textContext = uGUIDataEntity.TextContent.ToString();
            if (text.Equals(textContext))
            {
                return;
            }
            else
            {
                ((UGUIDataEntity)GetComponent<TextModel>().DataEntity).TextContent = text;
            }
        }
    }
}
