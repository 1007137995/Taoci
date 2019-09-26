/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IgcsXmlGenerator
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：国标XML生成器
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using System.Xml;
using System.Text;
using System.Reflection;
using System.IO;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 国标XML脚本生成器
    /// </summary>
    public class IgcsXmlGenerator
    {
        /// <summary>
        /// 保存的完整XML字符串
        /// </summary>
        public static string SavedXml = "";

        /// <summary>
        /// 输出为字符串格式
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static void SaveXmlDocument(XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;
            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 1;
                xtw.IndentChar = '\t';
                doc.WriteTo(xtw);
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
            }
            SavedXml = sb.ToString();
        }

        /// <summary>
        /// 系列化实验
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static XmlElement SerializeExprimentInfo(XmlDocument doc,ScriptBaseInfo baseInfo,ExperimentInfo expInfo)
        {
            XmlElement expElement = doc.CreateElement("Experiment");
            XmlAttribute attrScriptVersion  = doc.CreateAttribute("ScriptVersion");
            XmlAttribute attrCopyright      = doc.CreateAttribute("Copyright");
            XmlAttribute attrAuthor         = doc.CreateAttribute("Author");
            XmlAttribute attrLastModify     = doc.CreateAttribute("LastModifyTime");

            attrScriptVersion.Value = "GB-T-2019.03.14";
            attrCopyright.Value = baseInfo.copyright;
            attrAuthor.Value = baseInfo.author;
            attrLastModify.Value = baseInfo.lastModifyTime;

            expElement.Attributes.Append(attrScriptVersion);
            expElement.Attributes.Append(attrLastModify);
            expElement.Attributes.Append(attrCopyright);
            expElement.Attributes.Append(attrAuthor);

            XmlElement expInfoElement = doc.CreateElement("ExperimentInformation");
            XmlAttribute attrName     = doc.CreateAttribute("Name");
            XmlAttribute attrUuid     = doc.CreateAttribute("Uuid");
            XmlAttribute attrSubject  = doc.CreateAttribute("Subject");
            XmlAttribute attrCourse   = doc.CreateAttribute("Course");

            attrName.Value = expInfo.name;
            attrUuid.Value = expInfo.uuid;
            attrSubject.Value = expInfo.subject;
            attrCourse.Value = expInfo.course;
            expInfoElement.Attributes.Append(attrName);
            expInfoElement.Attributes.Append(attrUuid);
            expInfoElement.Attributes.Append(attrSubject);
            expInfoElement.Attributes.Append(attrCourse);
            expElement.AppendChild(expInfoElement);

            return expElement;
        }

        /// <summary>
        /// 生成 SceneObjects XML脚本
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static XmlElement SerializeSceneState(XmlDocument doc,object[] entities)
        {
            XmlElement expSceneState = doc.CreateElement("ExperimentSceneState");
            XmlElement sceneObjectsElement = doc.CreateElement("SceneObjects");
            expSceneState.AppendChild(sceneObjectsElement);

            foreach (object obj in entities)
            {
                XmlElement entityElement = SerializeEntity(doc, obj);
                sceneObjectsElement.AppendChild(entityElement);
            }

            XmlAttribute attrCount = doc.CreateAttribute("SceneObjectCount");
            attrCount.Value = entities.Length.ToString();
            sceneObjectsElement.Attributes.Append(attrCount);

            return expSceneState;
        }

        /// <summary>
        /// 生成 LogicModelProperties 和 GuiProperties XML脚本
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="entity"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static XmlElement SerializeProperty(XmlDocument doc, object entity, PropertyInfo info)
        {
            IgcsAttribute igcsTag = info.GetCustomAttribute<IgcsAttribute>();
            if (igcsTag == null)
            {
                return null;
            }

            XmlElement propertyNode = doc.CreateElement("LogicModelProperty");

            XmlAttribute attrName = doc.CreateAttribute("Name");
            attrName.Value = info.Name;
            propertyNode.Attributes.Append(attrName);

            if (info.GetValue(entity) != null)
            {
                XmlAttribute attrValue = doc.CreateAttribute("Value");
                attrValue.Value = info.GetValue(entity).ToString();
                propertyNode.Attributes.Append(attrValue);
            }

            igcsTag.FillXmlElement(doc, propertyNode);

            return propertyNode;
        }

        /// <summary>
        /// 生成 LogicModelProperties 和 GuiProperties XML脚本
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="entity"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static XmlElement SerializeField(XmlDocument doc, object entity, FieldInfo info)
        {
            IgcsAttribute igcsTag = info.GetCustomAttribute<IgcsAttribute>();
            if (igcsTag == null)
            {
                return null;
            }

            XmlElement propertyNode = doc.CreateElement("LogicModelProperty");

            XmlAttribute attrName = doc.CreateAttribute("Name");
            attrName.Value = info.Name;
            propertyNode.Attributes.Append(attrName);

            if (info.GetValue(entity) != null)
            {
                XmlAttribute attrValue = doc.CreateAttribute("Value");
                attrValue.Value = info.GetValue(entity).ToString();
                propertyNode.Attributes.Append(attrValue);
            }

            igcsTag.FillXmlElement(doc, propertyNode);

            return propertyNode;
        }


        /// <summary>
        /// 生成 SceneObject XML脚本
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XmlElement SerializeEntity(XmlDocument doc, object entity)
        {
            XmlElement objectNode = doc.CreateElement("SceneObject");
            XmlElement modelPropertiesNode = doc.CreateElement("LogicModelProperties");
            XmlElement guiPropertiesNode = doc.CreateElement("GuiProperties");

            XmlAttribute attrObjectName       = doc.CreateAttribute("Name");
            XmlAttribute attrObjectId         = doc.CreateAttribute("Uuid");
            XmlAttribute attrObjectTargetType = doc.CreateAttribute("TargetType");

            if (entity.GetType().GetField("igcsName") != null)
            {
                FieldInfo infoName = entity.GetType().GetField("igcsName");
                string strName = (string)infoName.GetValue(entity);
                attrObjectName.Value = strName;
            }
            else
            {
                attrObjectName.Value = "null";
            }

            if (entity.GetType().GetField("objectID") != null)
            {
                FieldInfo infoId = entity.GetType().GetField("objectID");
                string strId = (infoId.GetValue(entity)).ToString();
                attrObjectId.Value = strId;
            }
            else
            {
                attrObjectId.Value = "null";
            }

            attrObjectTargetType.Value = entity.GetType().ToString();

            objectNode.Attributes.Append(attrObjectName);
            objectNode.Attributes.Append(attrObjectId);
            objectNode.Attributes.Append(attrObjectTargetType);


            PropertyInfo[] properties = entity.GetType().GetProperties();
            FieldInfo[]    fields     = entity.GetType().GetFields();

            int propertyCount = 0;

            foreach(PropertyInfo info in properties)
            {
                XmlElement ele = SerializeProperty(doc, entity, info);
                if(ele != null)
                {
                    propertyCount++;
                    modelPropertiesNode.AppendChild(ele);
                }
            }

            foreach(FieldInfo info in fields)
            {
                XmlElement ele = SerializeField(doc, entity, info);
                if (ele != null)
                {
                    propertyCount++;
                    modelPropertiesNode.AppendChild(ele);
                }
            }

            XmlAttribute attrCount = doc.CreateAttribute("PropertyCount");
            attrCount.Value = propertyCount.ToString();
            modelPropertiesNode.Attributes.Append(attrCount);

            objectNode.AppendChild(guiPropertiesNode);
            objectNode.AppendChild(modelPropertiesNode);

            return objectNode;
        }
    }
}
