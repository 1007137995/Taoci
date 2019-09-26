
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： ScreenMask
* 创建日期：2019-03-22 08:46:51
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// loading动画类型
    /// </summary>
    public enum MaskType
    {
        SimpleBar,
        BigBar,
        Basic,
        SimpleSpinner,
        MediumSpinner,
        BigSpinner,
    }
    /// <summary>
    /// 遮罩控制类
    /// </summary>
    public class ScreenMask 
	{
        private static GameObject _canvas;
        static Dictionary<MaskType, string> maskDic = new Dictionary<MaskType, string>();
        /// <summary>
        /// 构造函数
        /// </summary>
        static ScreenMask()
        {
            maskDic.Add(MaskType.Basic, "LoadingPrefabs/Basic");
            maskDic.Add(MaskType.SimpleBar, "LoadingPrefabs/SimpleBar");
            maskDic.Add(MaskType.BigBar, "LoadingPrefabs/BigBar");
            maskDic.Add(MaskType.SimpleSpinner, "LoadingPrefabs/SimpleSpinner");
            maskDic.Add(MaskType.MediumSpinner, "LoadingPrefabs/MediumSpinner");
            maskDic.Add(MaskType.BigSpinner, "LoadingPrefabs/BigSpinner");
        }

        /// <summary>
        /// 显示遮罩
        /// </summary>
        /// <param name="bgSprite"></param>
        /// <param name="keepTime"></param>
        public static void ShowMask(Sprite bgSprite,int keepTime)
        {
            GameObject canvas = new GameObject("MaskCanvas");
            Canvas _cavas = canvas.AddComponent<Canvas>();
            _cavas.renderMode = RenderMode.ScreenSpaceOverlay;
            _cavas.sortingOrder = 10000;
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<DondestoryOnLoad>();
            GameObject mask = new GameObject("Mask");
            mask.transform.SetParent(canvas.transform);
            Image bgImage = mask.AddComponent<Image>();
            if (bgSprite != null)
            {
                bgImage.sprite = bgSprite;
            }
            RectTransform rect = bgImage.GetComponent<RectTransform>();           
            rect.sizeDelta = Vector2.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            RainierUlitity.SetAnchorOfCenter(rect,0,0);
            GameObject text = new GameObject("Title");
            Text title = text.AddComponent<Text>();
            title.font = Font.CreateDynamicFontFromOSFont("simhei", 15);
            title.text = "数据加载中...";
            text.transform.SetParent(rect);
            RainierUlitity.SetAnchorOfCenter(text.GetComponent<RectTransform>(), 0, 0);
            canvas.transform.SetAsLastSibling();
            Object.Destroy(canvas, keepTime);
        }

        /// <summary>
        /// 显示遮罩
        /// </summary>
        /// <param name="bgColor"></param>
        /// <param name="keepTime"></param>
        public static void ShowMask(Color bgColor, int keepTime)
        {

            GameObject canvas = new GameObject("MaskCanvas");
            Canvas _cavas = canvas.AddComponent<Canvas>();
            _cavas.renderMode = RenderMode.ScreenSpaceOverlay;
            _cavas.sortingOrder = 10000;
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<DondestoryOnLoad>();
            GameObject mask = new GameObject("Mask");
            mask.transform.SetParent(canvas.transform);
            Image bgImage = mask.AddComponent<Image>();
            bgImage.color = bgColor;
            RectTransform rect = bgImage.GetComponent<RectTransform>();

            rect.sizeDelta = Vector2.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            RainierUlitity.SetAnchorOfCenter(rect, 0, 0);
            GameObject text = new GameObject("Title");
            Text title = text.AddComponent<Text>();
            title.font = Font.CreateDynamicFontFromOSFont("simhei",15);
            title.text = "数据加载中...";
            text.transform.SetParent(rect);
            RainierUlitity.SetAnchorOfCenter(text.GetComponent<RectTransform>(), 0, 0);

            canvas.transform.SetAsLastSibling();
            Object.Destroy(canvas, keepTime);
        }

        /// <summary>
        /// 显示遮罩（加载loading动画）
        /// </summary>
        /// <param name="bgColor"></param>
        /// <param name="keepTime"></param>
        /// <param name="typePrefabName"></param>
        public static void ShowMask(Color bgColor, int keepTime,MaskType type)
        {
            GameObject canvas = new GameObject("MaskCanvas");
            Canvas _cavas = canvas.AddComponent<Canvas>();
            _cavas.renderMode = RenderMode.ScreenSpaceOverlay;
            _cavas.sortingOrder = 10000;
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<DondestoryOnLoad>();
            GameObject mask = new GameObject("Mask");
            mask.transform.SetParent(canvas.transform);
            Image bgImage = mask.AddComponent<Image>();
            bgImage.color = bgColor;
            RectTransform rect = bgImage.GetComponent<RectTransform>();
            rect.sizeDelta = Vector2.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            RainierUlitity.SetAnchorOfCenter(rect, 0, 0);
            GameObject typePrefab = (GameObject)Resources.Load(maskDic[type]);            
            GameObject typeMask = MonoBehaviour.Instantiate<GameObject>(typePrefab);
            typeMask.transform.SetParent(rect.transform);
            RainierUlitity.SetAnchorOfCenter(typeMask.GetComponent<RectTransform>(), 0, 0);
            Object.Destroy(canvas, keepTime);
        }

        /// <summary>
        /// 显示遮罩（加载loading动画）
        /// </summary>
        /// <param name="bgColor"></param>
        /// <param name="keepTime"></param>
        /// <param name="typePrefabName"></param>
        public static void ShowMask(Color bgColor, MaskType type)
        {
            GameObject canvas = new GameObject("MaskCanvas");
            canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<DondestoryOnLoad>();
            GameObject mask = new GameObject("Mask");
            mask.transform.SetParent(canvas.transform);
            Image bgImage = mask.AddComponent<Image>();
            bgImage.color = bgColor;
            RectTransform rect = bgImage.GetComponent<RectTransform>();
            rect.sizeDelta = Vector2.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            RainierUlitity.SetAnchorOfCenter(rect, 0, 0);
            GameObject typePrefab = (GameObject)Resources.Load(maskDic[type]);

            GameObject typeMask = MonoBehaviour.Instantiate<GameObject>(typePrefab);
            typeMask.transform.SetParent(rect.transform);
            RainierUlitity.SetAnchorOfCenter(typeMask.GetComponent<RectTransform>(), 0, 0);
            _canvas = canvas;
        }

        public static void HideMask()
        {
            Object.DestroyImmediate(_canvas);
        }

    }
}

