/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IService
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：命令系统服务
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using Com.Rainier.BusKit.Unity.Modules.Command;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 命令系统服务
    /// </summary>
    public interface IServiceCommand : IService
    {
        /// <summary>
        /// 获取命令系统上下文环境
        /// </summary>
        /// <returns></returns>
        CommandContext GetContext();

        /// <summary>
        /// 获取命令系统堆栈
        /// </summary>
        /// <returns></returns>
        ICommandStack GetCommandStack();
    }
}
