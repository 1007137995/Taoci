/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ServiceExperiment
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：实验单例服务
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using Com.Rainier.BusKit.Unity.Modules.DataWatch;
using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 实验单例服务
    /// </summary>
    public class ServiceExperiment : IServiceExperiment
    {
        /// <summary>
        /// 实验用到的所有器件
        /// </summary>
        WatchableList<PartDataModel> ExperimentParts = new WatchableList<PartDataModel>();

        /// <summary>
        /// 注册器件
        /// </summary>
        /// <param name="model"></param>
        public void RegisterPart(PartDataModel model)
        {
            ExperimentParts.Add(model);
        }

        /// <summary>
        /// 删除器件
        /// </summary>
        /// <param name="model"></param>
        public void UnregisterPart(PartDataModel model)
        {
            ExperimentParts.Remove(model);
        }

        /// <summary>
        /// 搜索所有器件的数据模型
        /// </summary>
        /// <returns></returns>
        public PartDataModel[] FindPartDataModels()
        {
            PartDataModel[] models = GameObject.FindObjectsOfType<PartDataModel>();
            return models;
        }

        /// <summary>
        /// 搜索所有器件的数据模型实体
        /// </summary>
        /// <returns></returns>
        public PartEntity[] FindPartDataEntities()
        {
            PartDataModel[] models = FindPartDataModels();
            List<PartEntity> entities = new List<PartEntity>();
            foreach(PartDataModel model in models)
            {
                entities.Add((PartEntity)model.DataEntity);
            }
            return entities.ToArray();
        }

        /// <summary>
        /// 通过UUID搜索模型
        /// </summary>
        /// <param name="objectId"></param>
        public DataModelBehaviour FindDataModelByEntityUuid(int objectId)
        {
            PartDataModel[] models = FindPartDataModels();
            foreach (PartDataModel model in models)
            {
                if (((BaseDataModelEntity)(model.DataEntity)).objectID == objectId)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 通过UUID搜索模型实体
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public BaseDataModelEntity FindEntityByUuid(int objectId)
        {
            PartDataModel[] models = FindPartDataModels();
            foreach (PartDataModel model in models)
            {
                if (((BaseDataModelEntity)(model.DataEntity)).objectID == objectId)
                {
                    return (BaseDataModelEntity)model.DataEntity;
                }
            }
            return null;
        }

        /// <summary>
        /// 初始化实验服务
        /// </summary>
        public void Initialize()
        {
            //注册服务单利
            if (InjectService.Get<IServiceExperiment>() == null)
            {
                InjectService.RegisterSingleton<IServiceExperiment, ServiceExperiment>(this);
            }
        }
    }
}


