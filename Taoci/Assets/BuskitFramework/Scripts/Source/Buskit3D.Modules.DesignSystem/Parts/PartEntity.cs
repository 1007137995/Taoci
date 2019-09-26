/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：PartDataModel
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：器件实体
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/
using UnityEngine;
using Com.Rainier.BusKit.Unity.Modules.DataWatch;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 属性定义
    /// </summary>
    public struct Property
    {
        public string Name;
        public string Value;
        public string Description;
    }

    /// <summary>
    /// 器件实体
    /// </summary>
    public class PartEntity : BaseDataModelEntity
    {
        /// <summary>
        /// 器件名称
        /// </summary>
        public string PartName = "";

        /// <summary>
        /// 是否处于选中状态
        /// </summary>
        public bool IsSelected=false;

        /// <summary>
        /// 位置
        /// </summary>
        public Vector3 Position = Vector3.zero;

        /// <summary>
        /// 属性列表
        /// </summary>
        public WatchableList<Property> Properties = new WatchableList<Property>();
    }
}

