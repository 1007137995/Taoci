/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：BindingTable、BindingItem
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：Mvvm中数据绑定表和数据绑定条目
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using System.Collections.Generic;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 数据绑定条目
    /// </summary>
    public struct BindingItem
    {
        /// <summary>
        /// 实体对象
        /// </summary>
        public object BindedEntity;

        /// <summary>
        /// 实体对象对应的View对象
        /// </summary>
        public object BindedView;

        /// <summary>
        /// 实体对象属性
        /// </summary>
        public string BindedEntityProperty;

        /// <summary>
        /// 实体对象属性绑定的View属性
        /// </summary>
        public string BindedViewProperty;
    }

    /// <summary>
    /// 数据绑定对照表
    /// </summary>
    public class BindingTable
    {
        /// <summary>
        /// 数据绑定条目列表
        /// </summary>
        private List<BindingItem> _items = new List<BindingItem>();

        /// <summary>
        /// 获取绑定表
        /// </summary>
        /// <returns></returns>
        public List<BindingItem> GetItems()
        {
            return _items;
        }

        /// <summary>
        /// 添加绑定记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityProperty"></param>
        /// <param name="view"></param>
        /// <param name="viewProperty"></param>
        public void AddItem(
            object entity,
            string entityProperty,
            object view,
            string viewProperty)
        {
            BindingItem item = new BindingItem();
            item.BindedEntity = entity;
            item.BindedEntityProperty = entityProperty;
            item.BindedView = view;
            item.BindedViewProperty = viewProperty;

            _items.Add(item);
        }

        /// <summary>
        /// 通过实体对象的属性名称搜索绑定条目
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public BindingItem FindItemByEntityProperty(object entity,string propertyName)
        {
            BindingItem empty = new BindingItem();
            empty.BindedEntity = null;
            empty.BindedEntityProperty = "";
            empty.BindedView = null;
            empty.BindedViewProperty = null;

            foreach (BindingItem item in _items)
            {
                if (item.BindedEntityProperty.Equals(propertyName) && entity.Equals(item.BindedEntity))
                {
                    return item;
                }
            }
            return empty;
        }

        /// <summary>
        /// 通过视图对象搜索绑定条目
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public BindingItem FindItemByViewProperty(object view ,string propertyName)
        {
            BindingItem empty = new BindingItem();
            empty.BindedEntity = null;
            empty.BindedEntityProperty = "";
            empty.BindedView = null;
            empty.BindedViewProperty = null;

            foreach (BindingItem item in _items)
            {
                if (item.BindedViewProperty.Equals(propertyName) && item.BindedView.Equals(view))
                {
                    return item;
                }
            }
            return empty;
        }

        /// <summary>
        /// 重置绑定表
        /// </summary>
        public void Reset()
        {
            _items.Clear();
        }
    }
}
