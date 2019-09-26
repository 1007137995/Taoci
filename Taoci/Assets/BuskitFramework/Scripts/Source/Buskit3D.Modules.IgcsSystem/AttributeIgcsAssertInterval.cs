/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IgcsAssertInterval
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：要求只能批改系统做区间数值判断，落在区间内才正常
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using System.Xml;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 要求只能批改系统做多项选择判断，值包涵全部正确选项
    /// </summary>
    public class IgcsAssertInterval : IgcsAttribute
    {
        /// <summary>
        /// 区间最大值
        /// </summary>
        public float Max = 0.0f;

        /// <summary>
        /// 区间最小值
        /// </summary>
        public float Min = 0.0f;

        /// <summary>
        /// 构造函数
        /// </summary>
        public IgcsAssertInterval() : base()
        {
            this.Way = CorrectionWay.AssertInterval;
        }

        /// <summary>
        /// 填充XML属性
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="ele"></param>
        public override void FillXmlElement(XmlDocument doc, XmlElement ele)
        {
            base.FillXmlElement(doc, ele);

            XmlAttribute attrMaxValue = doc.CreateAttribute("Max");
            attrMaxValue.Value = Max.ToString();
            ele.Attributes.Append(attrMaxValue);

            XmlAttribute attrMinValue = doc.CreateAttribute("Min");
            attrMinValue.Value = Min.ToString();
            ele.Attributes.Append(attrMinValue);
        }
    }
}
