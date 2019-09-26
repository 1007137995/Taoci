/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：RainierUlitity
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：通用工具类
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/
using UnityEngine;
namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 通用工具类
    /// </summary>
    public class RainierUlitity
    {
        
        #region UI Anchor
        /// <summary>
        /// 左下位置，left，bottom代表离指定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="left"></param>
        /// <param name="bottom"></param>
        public static void SetAnchorOfLeftBottom(RectTransform rt, float left, float bottom)
        {
            Vector2 size = rt.rect.size;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, left, size.x);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottom, size.y);
        }

        /// <summary>
        ///左上位置，left，top代表离指定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public static void SetAnchorOfLeftTop(RectTransform rt, float left, float top)
        {
            Vector2 size = rt.rect.size;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, left, size.x);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, top, size.y);
        }

        /// <summary>
        /// 右下，right,bottom代表离指定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public static void SetAnchorOfRightBottom(RectTransform rt, float right, float bottom)
        {
            Vector2 size = rt.rect.size;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, right, size.x);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottom, size.y);
        }

        /// <summary>
        /// 右上,right,top代表离指定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        public static void SetAnchorOfRightTop(RectTransform rt, float right, float top)
        {
            Vector2 size = rt.rect.size;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, right, size.x);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, top, size.y);
        }

        /// <summary>
        /// 中心，x,y代表离指定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetAnchorOfCenter(RectTransform rt, float x, float y)
        {
            Vector2 size = rt.rect.size;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
            rt.localPosition = new Vector2(x, y);
        }

        /// <summary>
        /// 左边，x代表离指定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="x"></param>
        public static void SetAnchorOfLeft(RectTransform rt, float x)
        {
            Vector2 size = rt.rect.size;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
            rt.localPosition = Vector2.zero;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, x, size.x);
        }

        /// <summary>
        /// 右边，x代表指离定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="x"></param>
        public static void SetAnchorOfRight(RectTransform rt, float x)
        {
            Vector2 size = rt.rect.size;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
            rt.localPosition = Vector2.zero;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, x, size.x);
        }

        /// <summary>
        /// 上边 ，y代表指离定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="y"></param>
        public static void SetAnchorOfTop(RectTransform rt, float y)
        {
            Vector2 size = rt.rect.size;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
            rt.localPosition = Vector2.zero;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, y, size.y);
        }

        /// <summary>
        /// 下边，y代表离指定边的距离
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="y"></param>
        public static void SetAnchorOfBottom(RectTransform rt, float y)
        {
            Vector2 size = rt.rect.size;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
            rt.localPosition = Vector2.zero;
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, y, size.y);
        }
        #endregion
    }
}

