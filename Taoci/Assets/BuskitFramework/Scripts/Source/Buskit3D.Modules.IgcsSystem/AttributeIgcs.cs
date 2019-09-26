/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IgcsAttribute
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：智能指导和智能批改属性标签
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using System;
using System.Xml;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 智能指导和智能批改属性标签
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Field | AttributeTargets.Property,
        Inherited = true,
        AllowMultiple = false)
    ]
    public class IgcsAttribute : Attribute
    {
        /// <summary>
        /// 含义描述
        /// </summary>
        public string Meaning = "";

        /// <summary>
        /// 智能批改方法,默认情况下无论如何都正确
        /// </summary>
        protected CorrectionWay Way = CorrectionWay.Nothing;

        /// <summary>
        /// 分值，默认情况下0.0f
        /// </summary>
        public float Score = 0.0f;

        /// <summary>
        /// 断言值（被判断的基准值）
        /// </summary>
        public object AssertValue = null;

        /// <summary>
        /// 填充XML属性
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="ele"></param>
        public virtual void FillXmlElement(XmlDocument doc,XmlElement ele)
        {
            //填充意义属性
            XmlAttribute attrMean = doc.CreateAttribute("Meaning");
            attrMean.Value = this.Meaning;
            ele.Attributes.Append(attrMean);

            //填充叛变方法属性
            XmlAttribute attrWay = doc.CreateAttribute("Way");
            attrWay.Value = Way.ToString();
            ele.Attributes.Append(attrWay);

            //断言值填充
            XmlAttribute attrAssertValue = doc.CreateAttribute("AssertValue");
            if(AssertValue == null)
            {
                attrAssertValue.Value = "null";
            }
            else
            {
                attrAssertValue.Value = this.AssertValue.ToString();
            }
            ele.Attributes.Append(attrAssertValue);
        }
    }
}


