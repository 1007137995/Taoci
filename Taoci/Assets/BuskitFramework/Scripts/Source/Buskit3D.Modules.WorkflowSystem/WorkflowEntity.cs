/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：WorkflowEntity
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：工作流实体对象
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.BusKit.Unity.Modules.DataWatch;
using System.Collections.Generic;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 工作流实体对象
    /// </summary>
    public class WorkflowEntity : BaseDataModelEntity
    {
        /// <summary>
        /// 切换到指定名称目标业务逻辑
        /// </summary>
        [RestoreFireLogic]
        public string SwitchToTargetWorkflow = "";

        /// <summary>
        /// 子流程实体
        /// </summary>
        public List<WorkflowEntity> Children = new List<WorkflowEntity>();
    }
}
