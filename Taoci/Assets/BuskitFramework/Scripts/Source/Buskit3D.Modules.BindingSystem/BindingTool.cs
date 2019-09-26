/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：BindingTool
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：DataModelBehaviour绑定工具
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// DataModelBehaviour绑定工具
    /// </summary>
    public class BindingTool
    {
        /// <summary>
        /// 绑定工具单利对象
        /// </summary>
        private static BindingTool _instance = null;

        /// <summary>
        /// 获取单利
        /// </summary>
        /// <returns></returns>
        public static BindingTool GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BindingTool();
            }
            return _instance;
        }

        /// <summary>
        /// 绑定物体，本函数中自动获取gameObject的DataModelBehaviour对象，
        /// 如果不能获取，则抛出异常；
        /// </summary>
        /// <param name="goObserver"></param>
        /// <param name="goSubject"></param>
        public void Binding(GameObject goObserver, GameObject goSubject)
        {
            DataModelBehaviour observer = null;
            DataModelBehaviour subject  = null;

            observer = goObserver.GetComponent<DataModelBehaviour>();
            subject = goSubject.GetComponent<DataModelBehaviour>();

            if(observer != null && subject != null)
            {
                observer.Watch(subject);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }

        /// <summary>
        /// 绑定物体DataModelBehaviour的数据实体，
        /// 如果不能获取，则抛出异常；
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="subject"></param>
        public void Binding(DataModelBehaviour observer,DataModelBehaviour subject)
        {
            if (observer != null && subject != null)
            {
                observer.Watch(subject);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }

        /// <summary>
        /// 绑定物体DataModelBehaviour的数据实体，如果不能获取，则抛出异常；
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="subject"></param>
        public void Binding(DataModelBehaviour observer, BaseDataModelEntity subject)
        {
            if (observer != null && subject != null)
            {
                observer.Watch(subject);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }

        /// <summary>
        /// 取消绑定物体，本函数中自动获取gameObject的DataModelBehaviour对象，
        /// 如果不能获取，则抛出异常；
        /// </summary>
        /// <param name="goObserver"></param>
        /// <param name="goSubject"></param>
        public void Unbinding(DataModelBehaviour observer, BaseDataModelEntity subject)
        {
            if (observer != null && subject != null)
            {
                observer.Unwatch(subject);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }

        /// <summary>
        /// 以subject（Entity）为主题，监视subject的特定属性
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="subject"></param>
        /// <param name="propertyPath"></param>
        public void Binding(DataModelBehaviour observer, BaseDataModelEntity subject,string propertyPath)
        {
            if (observer != null && subject != null)
            {
                observer.Watch(subject,propertyPath);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }

        /// <summary>
        /// 取消绑定物体，本函数中自动获取gameObject的DataModelBehaviour对象，
        /// 如果不能获取，则抛出异常；
        /// </summary>
        /// <param name="goObserver"></param>
        /// <param name="goSubject"></param>
        public void Unbinding(DataModelBehaviour observer, BaseDataModelEntity subject,string propertyPath)
        {
            if (observer != null && subject != null)
            {
                observer.Unwatch(subject,propertyPath);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }

        /// <summary>
        /// 取消绑定物体，本函数中自动获取gameObject的DataModelBehaviour对象，
        /// 如果不能获取，则抛出异常；
        /// </summary>
        /// <param name="goObserver"></param>
        /// <param name="goSubject"></param>
        public void Unbinding(DataModelBehaviour observer, DataModelBehaviour subject)
        {
            if (observer != null && subject != null)
            {
                observer.Unwatch(subject);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }

        /// <summary>
        /// 取消绑定物体，本函数中自动获取gameObject的DataModelBehaviour对象，
        /// 如果不能获取，则抛出异常；
        /// </summary>
        /// <param name="goObserver"></param>
        /// <param name="goSubject"></param>
        public void Unbinding(GameObject goObserver,GameObject goSubject)
        {
            DataModelBehaviour observer = null;
            DataModelBehaviour subject = null;

            observer = goObserver.GetComponent<DataModelBehaviour>();
            subject = goSubject.GetComponent<DataModelBehaviour>();

            if (observer != null && subject != null)
            {
                observer.Unwatch(subject);
            }
            else
            {
                throw new BindingException("observer or subject could not be found.");
            }
        }
    }
}
