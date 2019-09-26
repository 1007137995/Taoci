﻿/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：WorkflowLogic
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：业务逻辑处理器
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 业务逻辑处理器
    /// </summary>
    public class WorkflowLogic : LogicBehaviour
    {

        public string WorkflowTagName = "";

        /// <summary>
        /// 处理业务逻辑进入
        /// </summary>
        public virtual void OnEnter()
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        public virtual void Execute()
        {

        }

        /// <summary>
        /// 处理业务逻辑退出
        /// </summary>
        public virtual void OnExit()
        {

        }
    }
}
