/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIController
* 创建日期：2019-01-22 9:30:17
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 功能描述：重写UGUI基本组件，实现UI回放(数据模型)
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

namespace Com.Rainier.Buskit3D.UI
{
    /// <summary>
    /// UI数据模型
    /// </summary>
    public class UGUIDataModel : DataModelBehaviour
    {
        /// <summary>
        /// 观察实体
        /// </summary>
        private void Awake()
        {
            this.DataEntity = new UGUIDataEntity();
            Watch(this);
        }
    }
}

