
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： Sequence
* 创建日期：2019-02-14 10:06:32
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：
******************************************************************************/

using System;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 定义DataModel还原时的执行顺序
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DataModelSequenceAttribute : Attribute 
	{
        /// <summary>
        /// 顺序编号
        /// </summary>
        public int number;

        public DataModelSequenceAttribute(int number)
        {
            this.number = number;
        }
	}
}

