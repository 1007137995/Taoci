/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IgcsAssertOption
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：要求智能批改系统做单项选择判断，值全等正确
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using System.Text;
using System.Xml;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 要求智能批改系统做单项选择判断，值全等正确
    /// </summary>
    public class IgcsAssertOption : IgcsAttribute
    {
        /// <summary>
        /// 选项
        /// </summary>
        public object[] Options = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public IgcsAssertOption() : base()
        {
            this.Way = CorrectionWay.AssertOption;
        }

        /// <summary>
        /// 填充XML属性
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="ele"></param>
        public override void FillXmlElement(XmlDocument doc, XmlElement ele)
        {
            base.FillXmlElement(doc, ele);

            XmlAttribute attrOptions = doc.CreateAttribute("Options");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Options.Length; i++)
            {
                object obj = this.Options[i];
                if (i < (this.Options.Length - 1))
                {
                    sb.Append(obj.ToString() + ",");
                }
                else
                {
                    sb.Append(obj.ToString());
                }
            }
            attrOptions.Value = sb.ToString();
            ele.Attributes.Append(attrOptions);
        }
    }
}
