/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：CommandEntity
* 创建日期：2018/11/29  
* 作者名称：王志远
* 功能描述：命令系统数据模型实体
* 修改记录：
* 2018/11/29 添加备注
* 
******************************************************************************/

using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 命令执行参数
    /// </summary>
    public interface ICommandArgs
    {
        string GetCommandName();
    }

    /// <summary>
    /// 创建物体命令参数
    /// </summary>
    public struct CreateCommandArgs : ICommandArgs
    {
        public string prefabsPath;

        public Vector3 Position;

        public string GetCommandName()
        {
            return "Create";
        }
    }

    /// <summary>
    /// 删除物体命令参数
    /// </summary>
    public struct DeleteCommandArgs : ICommandArgs
    {
        /// <summary>
        /// 器件的UUID
        /// </summary>
        public int PartObjectId;

        public string GetCommandName()
        {
            return "Delete";
        }
    }

    /// <summary>
    /// 移动物体命令参数
    /// </summary>
    public struct MoveCommandArgs : ICommandArgs
    {
        /// <summary>
        /// 器件UUID
        /// </summary>
        public int PartObjectId;

        /// <summary>
        /// 物体原始位置
        /// </summary>
        public Vector3 OldPosition;

        /// <summary>
        /// 物体新位置
        /// </summary>
        public Vector3 NewPosition;

        public string GetCommandName()
        {
            return "Move";
        }
    }

    /// <summary>
    /// Undo命令参数
    /// </summary>
    public struct UndoCommandArgs : ICommandArgs
    {
        public string GetCommandName()
        {
            return "Undo";
        }
    }

    /// <summary>
    /// Redo命令参数
    /// </summary>
    public struct RedoCommandArgs : ICommandArgs
    {
        public string GetCommandName()
        {
            return "Redo";
        }
    }

    /// <summary>
    /// 命令系统数据模型实体
    /// </summary>
    public class CommandEntity : BaseDataModelEntity
    {
        /// <summary>
        /// 命令参数
        /// </summary>
        public ICommandArgs CommandArgs = null;
    }
}

