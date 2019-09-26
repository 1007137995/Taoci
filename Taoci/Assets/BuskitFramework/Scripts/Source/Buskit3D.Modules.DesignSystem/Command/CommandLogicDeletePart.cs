/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：CommandLogicDeletePart
* 创建日期：2018/11/29  
* 作者名称：王志远
* 功能描述：命令系统业务逻辑处理(删除器件)
* 修改记录：
* 2018/11/29 添加备注
* 
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Aop;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 命令系统业务逻辑处理
    /// </summary>
    public class CommandLogicDeletePart : LogicBehaviour
    {
        /// <summary>
        /// 注入命令系统
        /// </summary>
        [Inject]
        IServiceCommand _CommandService;

        /// <summary>
        /// 注入Experiment实例
        /// </summary>
        [Inject]
        IServiceExperiment _Experiment;

        /// <summary>
        /// 执行注入，启动器件表UI更新
        /// </summary>
        private void Start()
        {
            InjectService.InjectInto(this);
        }

        /// <summary>
        /// 处理命令系统业务逻辑
        /// </summary>
        /// <param name="evt"></param>
        public override void ProcessLogic(PropertyMessage evt)
        {
            //处理删除物体业务逻辑
            if (evt.PropertyName.Equals("CommandArgs"))
            {
                ICommandArgs _args = (ICommandArgs)evt.NewValue;
                if (!_args.GetCommandName().ToLower().Equals("delete"))
                {
                    return;
                }

                //获取创建参数执行删除命令
                DeleteCommandArgs args = (DeleteCommandArgs)evt.NewValue;
                CommandPartDelete cmd = new CommandPartDelete();
                cmd.TargetPartObjectId = args.PartObjectId;
                _CommandService.GetCommandStack().Execute(cmd);
                return;
            }
        }
    }
}
