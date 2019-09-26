/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：ISerializerObject
* 创建日期：2018-04-07 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：json序列化接口
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/


namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// json序列化接口
    /// </summary>
    public interface IServiceSerializer : IService
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        string  SerializerObject(object o);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        object DeSerializerObject(string json);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        object DeSerializerObject(string json,System.Type type);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        T DeSerializerObject<T>(string json);
    }
}

