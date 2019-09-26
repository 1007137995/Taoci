/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ScriptBaseInfo\ExperimentInfo
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：国标脚本基本信息和实验基本信息填充
* 修改记录：
* 日期 描述：
* 
******************************************************************************/


namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 脚本基本信息结构体
    /// </summary>
    public struct ScriptBaseInfo
    {
        /// <summary>
        /// 脚本遵循的标准及版本（以国标发布日期为准）
        /// </summary>
        public string scriptVersion;

        /// <summary>
        /// 脚本最后一次修改时间，使用（年/月/日-时:分:秒）格式
        /// </summary>
        public string lastModifyTime;

        /// <summary>
        /// 脚本发布单位版权声明
        /// </summary>
        public string copyright;

        /// <summary>
        /// 脚本发布者
        /// </summary>
        public string author;
    }

    /// <summary>
    /// 实验基本信息结构体
    /// </summary>
    public struct ExperimentInfo
    {
        /// <summary>
        /// 虚拟实验名称
        /// </summary>
        public string name;

        /// <summary>
        ///  虚拟实验唯一标识ID
        /// </summary>
        public string uuid;

        /// <summary>
        /// 虚拟实验所属专业
        /// </summary>
        public string subject;

        /// <summary>
        /// 虚拟实验所属课程
        /// </summary>
        public string course;
    }
}
