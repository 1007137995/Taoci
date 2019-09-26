/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：BaseDataModelEntity
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：模型实体基类
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// Transform信息结构体
    /// 用于记录基本的
    /// </summary>
    public struct TransInfo
    {
        public  Vector3 positon;
        public  Vector3 eulerAngles; 
        public  Vector3 localScale;
        public bool isActive;
    }

    /// <summary>
    /// 数据模型实体基本类
    /// </summary>
    public class BaseDataModelEntity
    {
        /// <summary>
        ///实体唯一表示ID
        /// </summary>
        public int objectID = -1;

        /// <summary>
        /// 实体对应的GameObject位置信息
        /// </summary>
        public TransInfo transInfo;

        /// <summary>
        /// 实体名称
        /// </summary>
        public string igcsName = "";
    }
}
