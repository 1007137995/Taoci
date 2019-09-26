/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：WorkflowDataModel
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：工作流抽象类
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 工作流抽象类
    /// </summary>
    [RequireComponent(typeof(WorkflowTracer))]
    public class WorkflowDataModel : DataModelBehaviour
    {
        /// <summary>
        /// 监视实体数据
        /// </summary>
        private void Awake()
        {
            this.DataEntity = new WorkflowEntity();
            Watch(this);
        }

        public override void LoadStorageData()
        {
            base.LoadStorageData();
            WorkflowEntity workflowEntity = (WorkflowEntity)DataEntity;
            Debug.Log(workflowEntity.SwitchToTargetWorkflow);
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Q)) {
                WorkflowEntity workflowEntity = (WorkflowEntity)DataEntity;
                Debug.Log(workflowEntity.SwitchToTargetWorkflow);
            }
        }
    }
}
