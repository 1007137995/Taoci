/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：NoStorage
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：表示某个属性发出的事件不用存储
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using System;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 表示某个属性发出的事件不用存储
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Field | AttributeTargets.Property,
        Inherited = true,
        AllowMultiple = false)
    ]
    public class NoStorage : Attribute
    {

    }
}
