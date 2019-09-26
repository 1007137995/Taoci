/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：CommandLogicCreatePart
* 创建日期：2018/11/29  
* 作者名称：王志远
* 功能描述：命令系统业务逻辑处理（创建器件）
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
    public class CommandLogicCreatePart : LogicBehaviour
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
            //处理创建物体业务逻辑
            if (evt.PropertyName.Equals("CommandArgs"))
            {
                ICommandArgs _args = (ICommandArgs)evt.NewValue;
                if (!_args.GetCommandName().ToLower().Equals("create"))
                {
                    return;
                }

                //获取创建参数
                CreateCommandArgs args = (CreateCommandArgs)evt.NewValue;
                if (args.prefabsPath == null || args.prefabsPath.Equals(""))
                {
                    return;
                }

                //新建创建命令并执行命令（注意命令执行方法是让命令堆栈执行Execute）
                CommandPartCreate cmd = new CommandPartCreate();
                cmd.Position = args.Position;
                cmd.PartPrefab = args.prefabsPath;
                _CommandService.GetCommandStack().Execute(cmd);
                return;
            }
        }
    }
}
