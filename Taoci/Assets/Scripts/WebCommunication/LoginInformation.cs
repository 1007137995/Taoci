/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v2.0.0
* 类 名 称： LoginInformation
* 创建日期：2019-08-06 18:50:39
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：v2.0.0 添加了简易平台用户信息
* 描述：用户登录信息存储，登陆成功后数据自动填充其中
******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
	public static class LoginInformation
    {
        private static string status = string.Empty;

        /// <summary>
        /// 状态码
        /// </summary>
        public static string Status {
            get { return status; }
            set { status = value; }
        }

        private static string eId = string.Empty;

        /// <summary>
        /// 学生实验数据唯一标识
        /// </summary>
        public static string EId {
            get { return eId; }
            set { eId = value; }
        }

        private static string userId = string.Empty;

        /// <summary>
        /// 学生id
        /// </summary>
        public static string UserId {
            get { return userId; }
            set { userId = value; }
        }

        private static string name = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public static string Name {
            get { return name; }
            set { name = value; }
        }

        private static string numberId = string.Empty;

        /// <summary>
        /// 学生学号
        /// </summary>
        public static string NumberId {
            get { return numberId; }
            set { numberId = value; }
        }

        private static string groupName = string.Empty;

        /// <summary>
        /// 班级
        /// </summary>
        public static string GroupName {
            get { return groupName; }
            set { groupName = value; }
        }

        private static string role = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public static string Role {
            get { return role; }
            set { role = value; }
        }


        private static string uploadScoreURLKey = string.Empty;

        /// <summary>
        /// 简易平台用上传分数地址
        /// </summary>
        public static string UpLoadScoreURLKey
        {
            get { return uploadScoreURLKey; }
            set { uploadScoreURLKey = value; }
        }


        private static string expId = string.Empty;

        /// <summary>
        /// 简易平台用实验唯一ID
        /// </summary>
        public static string ExpId
        {
            get { return expId; }
            set { expId = value; }
        }
    }
}

