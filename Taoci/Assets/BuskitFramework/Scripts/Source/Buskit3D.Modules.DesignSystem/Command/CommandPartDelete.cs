/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：CreatePartCommand
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：执行器件删除操作
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
    /// 执行器件删除操作
    /// </summary>
    public class CommandPartDelete : AbsCommand
    {
        /// <summary>
        /// 注入实验对象服务
        /// </summary>
        [Inject]
        IServiceExperiment _Experiment = null;

        /// <summary>
        /// 被删除的GameObject
        /// </summary>
        GameObject _deletedGameObject = null;

        /// <summary>
        /// 目标物体ObjectId
        /// </summary>
        public int TargetPartObjectId = -1;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommandPartDelete()
        {

        }

        /// <summary>
        /// 执行删除操作
        /// </summary>
        public override void Execute()
        {
            //查找所有已经实例化的物体
            PartDataModel[] parts = GameObject.FindObjectsOfType<PartDataModel>();
            foreach (PartDataModel part in parts)
            {
                if (((BaseDataModelEntity)part.DataEntity).objectID == TargetPartObjectId)
                {
                    _deletedGameObject = part.gameObject;
                    part.gameObject.SetActive(false);
                    return;
                }
            }
        }

        /// <summary>
        /// 执行Redo操作
        /// </summary>
        public override void Redo()
        {
            Execute();
        }

        /// <summary>
        /// 执行Undo操作
        /// </summary>
        public override void Undo()
        {
            if (_deletedGameObject != null)
            {
                _deletedGameObject.SetActive(true);
            }
        }
    }
}
