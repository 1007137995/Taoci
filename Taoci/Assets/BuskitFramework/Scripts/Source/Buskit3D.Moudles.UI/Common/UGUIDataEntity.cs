/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIController
* 创建日期：2019-01-08 11:30:17
* 作者名称：高大旺
* CLR 版本：4.0.30319.42000
* 功能描述：数据实体
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

namespace Com.Rainier.Buskit3D.UI
{
    /// <summary>
    /// 实体类
    /// </summary>
    public class UGUIDataEntity : BaseDataModelEntity
    {
        #region Slider
        /// <summary>
        /// Slider的Value值
        /// </summary>
        public float SliderValue = 0;
        #endregion
        #region InputField
        /// <summary>
        /// InputField文本内容
        /// </summary>
        public string Inputfile = "";
        #endregion
        #region DropDown
        /// <summary>
        /// DropDownItem值
        /// </summary>
        public int DropDownValue = -1;
        /// <summary>
        /// 是否显示下拉菜单
        /// </summary>
        public bool DropDownIsShow = false;
        #endregion
        #region Toggle
        /// <summary>
        /// Toggle状态
        /// </summary>
        public bool ToggleIsOn = false;
        #endregion
        #region Text
        /// <summary>
        /// 文本框内容
        /// </summary>
        public string TextContent = "";
        #endregion
    }
}

