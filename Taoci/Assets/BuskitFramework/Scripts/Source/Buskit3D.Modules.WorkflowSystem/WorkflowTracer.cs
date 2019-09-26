/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：WorkflowTracer
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：工作流追踪器
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Aop;
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 工作流追踪器
    /// </summary>
    public class WorkflowTracer : LogicBehaviour
    {
        /// <summary>
        /// 当前工作流业务逻辑
        /// </summary>
        public WorkflowLogic Current = null;

        /// <summary>
        /// 先前的工作流业务逻辑
        /// </summary>
        public WorkflowLogic Previous = null;

        /// <summary>
        /// 处理业务逻辑切换
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(PropertyMessage evt)
        {
            if (evt.PropertyName.Equals("SwitchToTargetWorkflow"))
            {
                Debug.Log(evt.NewValue);
                WorkflowLogic newLogic = GetWorkflowByName((string)evt.NewValue);
                if (newLogic != null)
                {
                    this.Previous = this.Current;
                    this.Current = newLogic;

                    if (this.Previous != null)
                    {
                        Previous.OnExit();
                    }
                    if (Current != null)
                    {
                        Current.OnEnter();
                    }
                }
                else
                {
                    throw new WorkflowException("The target work flow cloud't found.");
                }
            }
        }

        /// <summary>
        /// 执行当前业务逻辑操作
        /// </summary>
        public void Execute()
        {
            if(this.Current != null)
            {
                this.Current.Execute();
            }
        }

        /// <summary>
        /// 通过名称获取新工作流
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private WorkflowLogic GetWorkflowByName(string name)
        {
            WorkflowLogic[] logics = GetComponents<WorkflowLogic>();
            foreach(WorkflowLogic logic in logics)
            {
                if (logic.WorkflowTagName.Equals(name))
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
