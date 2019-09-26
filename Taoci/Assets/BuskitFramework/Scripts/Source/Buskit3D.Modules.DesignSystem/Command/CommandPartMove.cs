/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：MovePartCommand
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：执行移动器件命令
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.BusKit.Unity.Modules.Command;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 移动器件命令
    /// </summary>
    public class CommandPartMove : AbsCommand
    {
        [Inject]
        IServiceExperiment _Experiment = null;

        public CommandPartMove()
        {
            InjectService.InjectInto(this);
        }
        /// <summary>
        /// 目标物体UUID
        /// </summary>
        public int TargetPartObjectId = -1;

        /// <summary>
        /// 老位置
        /// </summary>
        public Vector3 OldPosition;

        /// <summary>
        /// 新位置
        /// </summary>
        public Vector3 NewPostion;

        /// <summary>
        /// 执行回撤操作
        /// </summary>
        public override void Execute()
        {
            Redo();
        }

        /// <summary>
        /// 执行Redo操作
        /// </summary>
        public override void Redo()
        {
            PartDataModel[] parts = GameObject.FindObjectsOfType<PartDataModel>();
            foreach (PartDataModel part in parts)
            {
                PartEntity entity = (PartEntity)part.DataEntity;
                if (entity.objectID == TargetPartObjectId)
                {
                    entity.Position = NewPostion;
                }
            }
        }

        /// <summary>
        /// 执行Undo操作
        /// </summary>
        public override void Undo()
        {
            PartDataModel[] parts = GameObject.FindObjectsOfType<PartDataModel>();
            foreach (PartDataModel part in parts)
            {
                PartEntity entity = (PartEntity)part.DataEntity;
                if (entity.objectID == TargetPartObjectId)
                {
                    entity.Position = OldPosition;
                }
            }
        }
    }
}

