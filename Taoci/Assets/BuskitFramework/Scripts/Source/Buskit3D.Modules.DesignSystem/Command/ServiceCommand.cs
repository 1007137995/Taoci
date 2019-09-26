/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ServiceCommand
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：命令系统服务
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.BusKit.Unity.Modules.Command;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 命令系统服务
    /// </summary>
    public class ServiceCommand : IServiceCommand
    {
        /// <summary>
        /// 命令系统上下文环境
        /// </summary>
        CommandContext ctx = new CommandContext();

        /// <summary>
        /// 获取命令堆栈
        /// </summary>
        /// <returns></returns>
        public ICommandStack GetCommandStack()
        {
            return ctx.GetCommandStack();
        }

        /// <summary>
        /// 获取命令系统上下文环境
        /// </summary>
        /// <returns></returns>
        public CommandContext GetContext()
        {
            return ctx;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            //注册服务单利
            if (InjectService.Get<IServiceCommand>() == null)
            {
                InjectService.RegisterSingleton<IServiceCommand, ServiceCommand>(this);
            }
        }
    }
}
