/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ViewModelBehaviour
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：Mvvm的ViewModel
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using System;
using System.Reflection;
using System.Collections.Generic;
using Com.Rainier.Buskit.Unity.Architecture.Aop;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// ViewModel定义
    /// </summary>
    public class ViewModelBehaviour : DataModelBehaviour
    {
        /// <summary>
        /// 数据绑定表
        /// </summary>
        protected BindingTable _bindingTable = new BindingTable();

        /// <summary>
        /// View是否已经初始化
        /// </summary>
        bool isViewInitialized = false;

        /// <summary>
        /// 监听数据实体和视图组件
        /// </summary>
        protected virtual void Awake()
        {
            Rebinding(this.DataEntity);
        }

        /// <summary>
        /// 重新绑定实体对象
        /// </summary>
        /// <param name="entity"></param>
        public void Rebinding(BaseDataModelEntity entity)
        {
            //如果绑定对象为空则返回
            if (entity == null)
            {
                return;
            }

            //如果绑定对象为空实体则返回
            if(entity is EmptyEntity)
            {
                return;
            }

            //取消绑定、Watch、初始化状态
            RestoreSystem.RemoveDataModel(DataEntity.objectID);

            _bindingTable.Reset();
            isViewInitialized = false;

            //重新设置实体对象并监听实体对象
            this.DataEntity = entity;

            //当entity的ID为-1时表示对象为新创建对象，
            //此时需要生成一个ID
            if (entity.objectID == -1)
            {
                // this.DataEntity.objectID = ObjectIdentity.GenerateRuntimeId().id;
                //注册动态id，并添加到存储字典中
                DynamicIds.SetId(this);
            }

            //重监听
            ReWatch(this);

            //根据继承类属性和字段的Binding注解添加绑定条目
            PropertyInfo[] pInfos = this.GetType().GetProperties();
            FieldInfo[] fInfos = this.GetType().GetFields();
            //获取公有属性

            foreach (PropertyInfo info in pInfos)
            {
                Binding attr = info.GetCustomAttribute<Binding>();
                if (attr == null)
                {
                    continue;
                }
                _bindingTable.AddItem(this.DataEntity, attr.EntityPropertyName, info.GetValue(this), "Value");
            }
            //获取公有字段
            foreach (FieldInfo info in fInfos)
            {
                Binding attr = info.GetCustomAttribute<Binding>();
                if (attr == null)
                {
                    continue;
                }
                _bindingTable.AddItem(this.DataEntity, attr.EntityPropertyName, info.GetValue(this), "Value");
            }

            //执行绑定过程
            List<BindingItem> items = _bindingTable.GetItems();
            foreach (BindingItem item in items)
            {
                this.watchTable.Watch(item.BindedView, item.BindedViewProperty, OnViewValueChanged);
            }
        }

        /// <summary>
        /// 使用实体数据值，初始化View状态
        /// </summary>
        public void  FireInitializeEvent()
        {
            List<BindingItem> items = _bindingTable.GetItems();
            List<string> bindingProperty = new List<string>();
            foreach (BindingItem item in items)
            {
                watchTable.FireEvent(item.BindedEntity, item.BindedEntityProperty);
                bindingProperty.Add(item.BindedEntityProperty);
            }

            //其他非绑定属性初始化
            foreach (var item in watchTable.Items)
            {
                if (bindingProperty.Contains(item.Path))
                {
                    continue;
                }
                else if(ReferenceEquals(item.Target,this.DataEntity))
                {
                    watchTable.FireEvent(item.Target, item.Path);
                }
            }

            isViewInitialized = true;
        }

        /// <summary>
        /// 等待所有Start函数执行完成后，
        /// 对MVVM进行数据对准（初始化）
        /// </summary>
        public override void Update()
        {
            if (!isViewInitialized)
            {
                FireInitializeEvent();
                return;
            }
            base.Update();
        }

        /// <summary>
        /// 观察另外一个对象
        /// </summary>
        /// <param name="obj"></param>
        public override void Watch(DataModelBehaviour obj)
        {
            watchTable.Watch(obj.DataEntity, "*", OnModelValueChanged);
        }

        /// <summary>
        /// 通过泛型处理模型数据变化（仅仅支持基本数据类型）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        public void OnModelValueChangedStuff<T>(PropertyMessage msg)
        {
            //1、查表获取对应的view，如果没有对应条目则返回
            ViewBehaviour<T> _view = null;
            BindingItem item = _bindingTable.FindItemByEntityProperty(msg.TargetObject, msg.PropertyName);
            if (item.BindedEntity == null ||
                item.BindedEntityProperty.Equals("") ||
                item.BindedView == null ||
                item.BindedViewProperty.Equals(""))
            {

                return;
            }

            _view = (ViewBehaviour<T>)item.BindedView;

            //2、重置view状态
            if (_view.IsViewStateChanged)
            {
                _view.ResetViewState();
                return;
            }

            //3、更新界面显示
            if (!_view.Value.Equals((T)msg.NewValue))
            {
                _view.RefreshComponent((T)msg.NewValue);
            }
        }

        /// <summary>
        /// 当Model层数据变化时更新View显示并触发业务逻辑处理
        /// （仅仅支持基本数据类型）
        /// </summary>
        /// <param name="msg"></param>
        public virtual void OnModelValueChanged(PropertyMessage msg)
        {
            //1、广播事件
            OnEvent(msg);

            //2、根据数据类型更新View显示
            if (msg.NewValue is float)
            {
                OnModelValueChangedStuff<float>(msg);
            }
            else if (msg.NewValue is double)
            {
                OnModelValueChangedStuff<double>(msg);
            }
            else if (msg.NewValue is decimal)
            {
                OnModelValueChangedStuff<decimal>(msg);
            }
            else if (msg.NewValue is string)
            {
                OnModelValueChangedStuff<string>(msg);
            }
            else if (msg.NewValue is bool)
            {
                OnModelValueChangedStuff<bool>(msg);
            }
            else if (msg.NewValue is char)
            {
                OnModelValueChangedStuff<char>(msg);
            }
            else if (msg.NewValue is sbyte)
            {
                OnModelValueChangedStuff<sbyte>(msg);
            }
            else if (msg.NewValue is short)
            {
                OnModelValueChangedStuff<short>(msg);
            }
            else if (msg.NewValue is int)
            {
                OnModelValueChangedStuff<int>(msg);
            }
            else if (msg.NewValue is long)
            {
                OnModelValueChangedStuff<long>(msg);
            }
            else if (msg.NewValue is byte)
            {
                OnModelValueChangedStuff<byte>(msg);
            }
            else if (msg.NewValue is ushort)
            {
                OnModelValueChangedStuff<ushort>(msg);
            }
            else if (msg.NewValue is uint)
            {
                OnModelValueChangedStuff<uint>(msg);
            }
            else if (msg.NewValue is ulong)
            {
                OnModelValueChangedStuff<ulong>(msg);
            }
        }

        /// <summary>
        /// 在View数据变化时，对绑定的实体数据属性赋值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <param name="newValue"></param>
        private void OnViewValueChangedStuff<T>(object entity, string propertyName, T newValue)
        {
            Type type = entity.GetType();
            PropertyInfo pInfo = type.GetProperty(propertyName);

            FieldInfo fInfo = type.GetField(propertyName);

            if (pInfo != null)
            {
                pInfo.SetValue(entity, newValue);
                return;
            }

            if (fInfo != null)
            {
                fInfo.SetValue(entity, newValue);
                return;
            }
        }

        /// <summary>
        /// 当View层数据变化时仅仅更新模型层数据
        /// </summary>
        /// <param name="msg"></param>
        public void OnViewValueChanged(PropertyMessage msg)
        {
            //1、查找entity属性对应的view组件
            BindingItem item = _bindingTable.FindItemByViewProperty(msg.TargetObject, msg.PropertyName);
            if (item.BindedEntity == null ||
                item.BindedEntityProperty.Equals("") ||
                item.BindedView == null ||
                item.BindedViewProperty.Equals(""))
            {
                throw new BindingException("未能找到绑定记录");
            }

            //2、给entity赋值为组件值
            if (msg.NewValue is float)
            {
                OnViewValueChangedStuff<float>(this.DataEntity, item.BindedEntityProperty, (float)msg.NewValue);
            }
            else if (msg.NewValue is double)
            {
                OnViewValueChangedStuff<double>(this.DataEntity, item.BindedEntityProperty, (double)msg.NewValue);
            }
            else if (msg.NewValue is decimal)
            {
                OnViewValueChangedStuff<decimal>(this.DataEntity, item.BindedEntityProperty, (decimal)msg.NewValue);
            }
            else if (msg.NewValue is string)
            {
                OnViewValueChangedStuff<string>(this.DataEntity, item.BindedEntityProperty, (string)msg.NewValue);
            }
            else if (msg.NewValue is bool)
            {
                OnViewValueChangedStuff<bool>(this.DataEntity, item.BindedEntityProperty, (bool)msg.NewValue);
            }
            else if (msg.NewValue is char)
            {
                OnViewValueChangedStuff<char>(this.DataEntity, item.BindedEntityProperty, (char)msg.NewValue);
            }
            else if (msg.NewValue is sbyte)
            {
                OnViewValueChangedStuff<sbyte>(this.DataEntity, item.BindedEntityProperty, (sbyte)msg.NewValue);
            }
            else if (msg.NewValue is short)
            {
                OnViewValueChangedStuff<short>(this.DataEntity, item.BindedEntityProperty, (short)msg.NewValue);
            }
            else if (msg.NewValue is int)
            {
                OnViewValueChangedStuff<int>(this.DataEntity, item.BindedEntityProperty, (int)msg.NewValue);
            }
            else if (msg.NewValue is long)
            {
                OnViewValueChangedStuff<long>(this.DataEntity, item.BindedEntityProperty, (long)msg.NewValue);
            }
            else if (msg.NewValue is byte)
            {
                OnViewValueChangedStuff<byte>(this.DataEntity, item.BindedEntityProperty, (byte)msg.NewValue);
            }
            else if (msg.NewValue is ushort)
            {
                OnViewValueChangedStuff<ushort>(this.DataEntity, item.BindedEntityProperty, (ushort)msg.NewValue);
            }
            else if (msg.NewValue is uint)
            {
                OnViewValueChangedStuff<uint>(this.DataEntity, item.BindedEntityProperty, (uint)msg.NewValue);
            }
            else if (msg.NewValue is ulong)
            {
                OnViewValueChangedStuff<ulong>(this.DataEntity, item.BindedEntityProperty, (ulong)msg.NewValue);
            }
        }
    }
}

