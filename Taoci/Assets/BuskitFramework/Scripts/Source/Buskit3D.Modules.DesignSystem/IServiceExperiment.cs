/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：IService
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：实验单例服务
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 实验单例服务
    /// </summary>
    public interface IServiceExperiment : IService
    {
        /// <summary>
        /// 注册器件
        /// </summary>
        /// <param name="entity"></param>
        void RegisterPart(PartDataModel entity);

        /// <summary>
        /// 删除器件
        /// </summary>
        /// <param name="entity"></param>
        void UnregisterPart(PartDataModel entity);

        /// <summary>
        /// 搜索所有器件的数据模型
        /// </summary>
        /// <returns></returns>
        PartDataModel[] FindPartDataModels();

        /// <summary>
        /// 搜索所有器件的数据模型实体
        /// </summary>
        /// <returns></returns>
        PartEntity[] FindPartDataEntities();

        /// <summary>
        /// 通过objectId搜索模型
        /// </summary>
        /// <param name="objectId"></param>
        DataModelBehaviour FindDataModelByEntityUuid(int objectId);

        /// <summary>
        /// 通过objectId搜索模型实体
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        BaseDataModelEntity FindEntityByUuid(int objectId);
    }
}


