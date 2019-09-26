/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ViewBehaviour
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：Mvvm的View
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// View对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewBehaviour<T> : MonoBehaviour
    {
        /// <summary>
        /// 标记View是否发生变化
        /// </summary>
        public bool IsViewStateChanged = false;

        /// <summary>
        /// View值
        /// </summary>
        public T Value;

        /// <summary>
        /// 重置View状态
        /// </summary>
        public void ResetViewState()
        {
            IsViewStateChanged = false;
        }

        /// <summary>
        /// 组件回调函数
        /// </summary>
        public virtual void ComponentCallback()
        {

        }

        /// <summary>
        /// 组件回调函数
        /// </summary>
        /// <param name="value"></param>
        public virtual void ComponentCallback(T value)
        {

        }

        /// <summary>
        /// 刷新UI组件
        /// </summary>
        /// <param name="value"></param>
        public virtual void RefreshComponent(T value)
        {

        }
    }
}
