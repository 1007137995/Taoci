/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：DropDownModel
* 创建日期：2019-01-22 9:30:17
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 功能描述：
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

namespace Com.Rainier.Buskit3D.UI
{
    /// <summary>
    /// 事件分发器类
    /// </summary>
    public class DropDownModel : UGUIDataModel
    { 
        /// <summary>
        /// 还原基本信息
        /// </summary>
        public override void LoadStorageData()
        {
            base.LoadStorageData();            
            UGUIDataEntity data = (UGUIDataEntity)DataEntity;
            GetComponent<DropdownRainier>().value = data.DropDownValue;
        }
    }
}
