using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;


namespace TaoCi
{
    public class DeviceBase : ObjectBase
    {
        public string introduction;
        public bool isShow;

        void Start()
        {

        }

        void Update()
        {

        }

        public override void OnMouseLeftClick() { }

        /// <summary>
        /// 绘制物品名称
        /// </summary>
        public void OnGUI()
        {
            if (isShow)
            {
                float groundWidth = 120;
                float groundHeight = 40;
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.white;
                style.fontSize = 15;
                style.fontStyle = FontStyle.Bold;
                style.alignment = TextAnchor.MiddleCenter;
                GUI.backgroundColor = new Color(0, 0, 0, 0);
                GUI.BeginGroup(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y - 40, groundWidth, groundHeight));
                GUI.DrawTexture(new Rect(0, 0, groundWidth, groundHeight), Resources.Load<Texture>("ZJW/UI/btnbg"));
                GUI.Box(new Rect(0, 0, groundWidth, groundHeight), introduction, style);
                GUI.EndGroup();
            }
        }
    }
}