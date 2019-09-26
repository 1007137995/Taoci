/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：RainierEventTriggerListener
* 创建日期：2018-04-07 10:58:17
* 作者名称：王冠南
* CLR 版本：4.0.30319.42000
* 功能描述：gameobject扩展方法，基于UGUI
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;
using Com.Rainier.Buskit3D;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 触发接听器（待完善）
    /// </summary>
    public class RainierEventTriggerListener : MonoBehaviour, 
        IPointerClickHandler, 
        IPointerDownHandler, 
        IPointerEnterHandler,
        IPointerExitHandler, 
        IPointerUpHandler, 
        IBeginDragHandler, 
        IEndDragHandler, 
        IDragHandler, 
        IScrollHandler, 
        IDropHandler, 
        IMoveHandler, 
        ISelectHandler, 
        IDeselectHandler, 
        IUpdateSelectedHandler, 
        ISubmitHandler, 
        ICancelHandler
    {
        /// <summary>
        /// 触发接听方法委托
        /// </summary>
        /// <param name="go"></param>
        public delegate void VoidDelegate(GameObject go);
        /// <summary>
        /// 左击鼠标委托
        /// </summary>
        public VoidDelegate onClickLeft;
        /// <summary>
        /// 右击鼠标委托
        /// </summary>
        public VoidDelegate onClickRight;
        /// <summary>
        /// 中击鼠标委托
        /// </summary>
        public VoidDelegate onClickMiddle;
        /// <summary>
        /// 左按鼠标委托
        /// </summary>
        public VoidDelegate onDownLeft;
        /// <summary>
        /// 右按鼠标委托
        /// </summary>
        public VoidDelegate onDownRight;
        /// <summary>
        /// 中按鼠标委托
        /// </summary>
        public VoidDelegate onDownMiddle;
        /// <summary>
        /// 左抬鼠标委托
        /// </summary>
        public VoidDelegate onUpLeft;
        /// <summary>
        /// 右抬鼠标委托
        /// </summary>
        public VoidDelegate onUpRight;
        /// <summary>
        /// 中抬鼠标委托
        /// </summary>
        public VoidDelegate onUpMiddle;
        /// <summary>
        /// 左双击鼠标委托
        /// </summary>
        public VoidDelegate onDoubleClickLeft;
        /// <summary>
        /// 右双击鼠标委托
        /// </summary>
        public VoidDelegate onDoubleClickRight;
        /// <summary>
        /// 中双击鼠标委托
        /// </summary>
        public VoidDelegate onDoubleClickMiddle;
        /// <summary>
        /// 鼠标进入委托
        /// </summary>
        public VoidDelegate onEnter;
        /// <summary>
        /// 鼠标离开委托
        /// </summary>
        public VoidDelegate onExit;
        /// <summary>
        /// 鼠标悬浮委托
        /// </summary>
        public VoidDelegate onHover;
        /// <summary>
        /// 开始拖拽委托
        /// </summary>
        public VoidDelegate onBeginDragLeft;
        /// <summary>
        /// 右键开始拖拽
        /// </summary>
        public VoidDelegate onBeginDragRight;
        /// <summary>
        /// 中键开始拖拽
        /// </summary>
        public VoidDelegate onBeginDragMiddle;
        /// <summary>
        /// 结束拖拽委托
        /// </summary>
        public VoidDelegate onEndDragLeft;
        /// <summary>
        /// 右键结束拖拽
        /// </summary>
        public VoidDelegate onEndDragRight;
        /// <summary>
        /// 中键结束拖拽
        /// </summary>
        public VoidDelegate onEndDragMiddle;
        /// <summary>
        /// 左拖拽委托
        /// </summary>
        public VoidDelegate onDragLeft;
        /// <summary>
        /// 右拖拽委托
        /// </summary>
        public VoidDelegate onDragRight;
        /// <summary>
        /// 中拖拽委托
        /// </summary>
        public VoidDelegate onDragMiddle;
        /// <summary>
        /// 鼠标滚轮委托
        /// </summary>
        public VoidDelegate onScroll;
        /// <summary>
        /// 鼠标松开委托
        /// </summary>
        public VoidDelegate onDrop;
        /// <summary>
        /// 鼠标移动委托
        /// </summary>
        public VoidDelegate onMove;
        /// <summary>
        /// 选中委托
        /// </summary>
        public VoidDelegate onSelect;
        /// <summary>
        /// 取消选中委托
        /// </summary>
        public VoidDelegate onDeselect;
        /// <summary>
        /// 选中委托
        /// </summary>
        public VoidDelegate onUpdateselect;
        /// <summary>
        /// 提交委托
        /// </summary>
        public VoidDelegate onSumit;
        /// <summary>
        /// 取消委托
        /// </summary>
        public VoidDelegate onCancel;
        /// <summary>
        /// 双击间隔
        /// </summary>
        public static float doubleClickTime = 0.3f;
        /// <summary>
        /// 计时器
        /// </summary>
        private  float clickTime = 0;
        /// <summary>
        /// 是否悬停
        /// </summary>
        private bool isHover = false;

        /// <summary>
        /// UnityMethod
        /// </summary>
        void Update()
        {
            if (!isHover) return;

            if (onHover != null)
                onHover.Invoke(gameObject);
        }

        /// <summary>
        /// 事件绑定
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static RainierEventTriggerListener Get(GameObject go)
        {
            RainierEventTriggerListener listener = go.GetComponent<RainierEventTriggerListener>();
            if (listener == null) listener = go.AddComponent<RainierEventTriggerListener>();
            return listener;
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    if (onClickLeft != null)
                        onClickLeft.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Right:
                    if (onClickRight != null)
                        onClickRight.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Middle:
                    if (onClickMiddle != null)
                        onClickMiddle.Invoke(gameObject);
                    break;
                default:
                    break;
            }
            if (Time.time - clickTime < doubleClickTime)
                switch (eventData.button)
                {
                    case PointerEventData.InputButton.Left:
                        if (onDoubleClickLeft != null)
                            onDoubleClickLeft.Invoke(gameObject);
                        break;
                    case PointerEventData.InputButton.Right:
                        if (onDoubleClickRight != null)
                            onDoubleClickRight.Invoke(gameObject);
                        break;
                    case PointerEventData.InputButton.Middle:
                        if (onDoubleClickMiddle != null)
                            onDoubleClickMiddle.Invoke(gameObject);
                        break;
                    default:
                        break;
                }
            clickTime = Time.time;
        }

        /// <summary>
        /// 按下事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    if (onDownLeft != null)
                        onDownLeft.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Right:
                    if (onDownRight != null)
                        onDownRight.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Middle:
                    if (onDownMiddle != null)
                        onDownMiddle.Invoke(gameObject);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 进入事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (onEnter != null)
                onEnter.Invoke(gameObject);
            isHover = true;

        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            if (onExit != null)
                onExit.Invoke(gameObject);
            isHover = false;
        }

        /// <summary>
        /// 抬起事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    if (onUpLeft != null)
                        onUpLeft.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Right:
                    if (onUpRight != null)
                        onUpRight.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Middle:
                    if (onUpMiddle != null)
                        onUpMiddle.Invoke(gameObject);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 开始拖拽
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    if (onBeginDragLeft != null)
                        onBeginDragLeft.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Right:
                    if (onBeginDragRight != null)
                        onBeginDragRight.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Middle:
                    if (onBeginDragMiddle != null)
                        onBeginDragMiddle.Invoke(gameObject);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 结束拖拽
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    if (onEndDragLeft != null)
                        onEndDragLeft.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Right:
                    if (onEndDragRight != null)
                        onEndDragRight.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Middle:
                    if (onEndDragMiddle != null)
                        onEndDragMiddle.Invoke(gameObject);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 拖拽
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    if (onDragLeft != null)
                        onDragLeft.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Right:
                    if (onDragRight != null)
                        onDragRight.Invoke(gameObject);
                    break;
                case PointerEventData.InputButton.Middle:
                    if (onDragMiddle != null)
                        onDragMiddle.Invoke(gameObject);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 滚轮事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnScroll(PointerEventData eventData)
        {
            if (onScroll != null)
                onScroll.Invoke(gameObject);
        }

        /// <summary>
        ///展开事件 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (onDrop != null)
                onDrop.Invoke(gameObject);
        }

        /// <summary>
        /// 移动事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnMove(AxisEventData eventData)
        {
            if (onMove != null)
                onMove.Invoke(gameObject);
        }

        /// <summary>
        /// 选中事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnSelect(BaseEventData eventData)
        {
            if (onSelect != null)
                onSelect.Invoke(gameObject);
        }

        /// <summary>
        /// 取消选中事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDeselect(BaseEventData eventData)
        {
            if (onDeselect != null)
                onDeselect.Invoke(gameObject);
        }

        /// <summary>
        /// 选中事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnUpdateSelected(BaseEventData eventData)
        {
            if (onUpdateselect != null)
                onUpdateselect.Invoke(gameObject);
        }

        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnSubmit(BaseEventData eventData)
        {
            if (onSumit != null)
                onSumit.Invoke(gameObject);
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnCancel(BaseEventData eventData)
        {
            if (onCancel != null)
                onCancel.Invoke(gameObject);
        }
    }

}

/// <summary>
/// 触发接听器扩展方法
/// </summary>
public static class RainierEventTriggerListenerExpand
{
    #region Add方法
    /// <summary>
    /// 点击
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void AddClick(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onClickLeft += function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onClickRight += function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onClickMiddle += function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 双击
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void AddDoubleClick(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onDoubleClickLeft += function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onDoubleClickRight += function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onDoubleClickMiddle += function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 弹起
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void AddUp(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onUpLeft += function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onUpRight += function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onUpMiddle += function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 按下
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void AddDown(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onDownLeft += function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onDownRight += function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onDownMiddle += function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 鼠标浮上（Update）
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddHover(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onHover += function;
    }

    /// <summary>
    /// 鼠标进入
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddEnter(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onEnter += function;
    }

    /// <summary>
    /// 鼠标离开
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddExit(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onExit += function;
    }

    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void AddBeginDrag(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onBeginDragLeft += function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onBeginDragRight += function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onBeginDragMiddle += function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 结束拖拽
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void AddEndDrag(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onEndDragLeft += function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onEndDragRight += function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onEndDragMiddle += function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 拖拽
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void AddDrag(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onDragLeft += function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onDragRight += function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onDragMiddle += function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 中键在物体上滑动
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddScroll(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onScroll += function;
    }

    /// <summary>
    /// 拖拽另一个物体松开在本体上
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddDrop(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onDrop += function;
    }

    /// <summary>
    /// 当物体被选中且键盘使用移动键时
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddMove(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onMove += function;
    }

    /// <summary>
    /// 当物体被选择时
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddSelect(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onSelect += function;
    }

    /// <summary>
    /// 当物体不被选择时
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddDeselect(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onDeselect += function;
    }

    /// <summary>
    /// 当物体被选择（每帧）
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddUpdateselect(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onUpdateselect += function;
    }

    /// <summary>
    /// 当物体被选择时键盘提交
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddSumit(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onSumit += function;
    }

    /// <summary>
    /// 当物体被选择时键盘取消
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void AddCancel(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onCancel += function;
    }

    #endregion

    #region Set方法

    /// <summary>
    /// 点击
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void SetClick(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onClickLeft = function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onClickRight = function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onClickMiddle = function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 双击
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void SetDoubleClick(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onDoubleClickLeft = function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onDoubleClickRight = function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onDoubleClickMiddle = function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 抬起
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void SetUp(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onUpLeft = function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onUpRight = function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onUpMiddle = function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 按下
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void SetDown(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onDownLeft = function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onDownRight = function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onDownMiddle = function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 鼠标浮上（每帧）
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetHover(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onHover = function;
    }

    /// <summary>
    /// 鼠标进入
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetEnter(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onEnter = function;
    }

    /// <summary>
    /// 鼠标离开
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetExit(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onExit = function;
    }

    /// <summary>
    /// 鼠标开始拖拽
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void SetBeginDrag(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onBeginDragLeft = function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onBeginDragRight = function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onBeginDragMiddle = function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 结束拖拽
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void SetEndDrag(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onEndDragLeft = function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onEndDragRight = function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onEndDragMiddle = function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 正在拖拽
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    /// <param name="mouseInput"></param>
    public static void SetDrag(this GameObject go, RainierEventTriggerListener.VoidDelegate function, PointerEventData.InputButton mouseInput = PointerEventData.InputButton.Left)
    {
        switch (mouseInput)
        {
            case PointerEventData.InputButton.Left:
                RainierEventTriggerListener.Get(go).onDragLeft = function;
                break;
            case PointerEventData.InputButton.Right:
                RainierEventTriggerListener.Get(go).onDragRight = function;
                break;
            case PointerEventData.InputButton.Middle:
                RainierEventTriggerListener.Get(go).onDragMiddle = function;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 鼠标中键在该物体上滑动
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetScroll(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onScroll = function;
    }

    /// <summary>
    /// 拖拽另一个物体松开在本体上
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetDrop(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onDrop = function;
    }

    /// <summary>
    /// 当物体被选中且键盘使用移动键时
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetMove(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onMove = function;
    }

    /// <summary>
    /// 当物体被选择时
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetSelect(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onSelect = function;
    }

    /// <summary>
    /// 当物体不被选择时
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetDeselect(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onDeselect = function;
    }

    /// <summary>
    /// 当物体被选择（每帧）
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetUpdateselect(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onUpdateselect = function;
    }

    /// <summary>
    /// 当物体被选择时键盘提交
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetSumit(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onSumit = function;
    }

    /// <summary>
    /// 当物体被选择时键盘取消
    /// </summary>
    /// <param name="go"></param>
    /// <param name="function"></param>
    public static void SetCancel(this GameObject go, RainierEventTriggerListener.VoidDelegate function)
    {
        RainierEventTriggerListener.Get(go).onCancel = function;
    }
    #endregion
}