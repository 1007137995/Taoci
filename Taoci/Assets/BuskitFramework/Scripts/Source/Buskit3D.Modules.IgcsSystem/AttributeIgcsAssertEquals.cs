/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：AttributeIgcsEquals
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：要求智能批改系统做全等判断，完全等于才正确
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using System.Xml;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 要求智能批改系统做全等判断，完全等于才正确
    /// </summary>
    public class IgcsAssertEquals : IgcsAttribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IgcsAssertEquals() : base()
        {
            this.Way = CorrectionWay.AssertEquals;
        }
    }
}
