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
    public interface IServiceCompress:IService
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] Compress(byte[] data);

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] DeCompress(byte[] data);
    }
}

