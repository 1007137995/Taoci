/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IgcsAssertFalse
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：值为False断言，只有值为False时裁判的为正确
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using System.Xml;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 值为False断言，只有值为False时裁判的为正确
    /// </summary>
    public class IgcsAssertFalse : IgcsAttribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IgcsAssertFalse() : base()
        {
            this.Way = CorrectionWay.AssertFalse;
            this.AssertValue = false;
        }

        /// <summary>
        /// 填充XML属性
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="ele"></param>
        public override void FillXmlElement(XmlDocument doc, XmlElement ele)
        {
            base.FillXmlElement(doc, ele);
        }
    }
}
