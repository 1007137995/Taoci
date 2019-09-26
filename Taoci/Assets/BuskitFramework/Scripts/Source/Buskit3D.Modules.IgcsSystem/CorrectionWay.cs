/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIController
* 创建日期：2019-03-14 11:30:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 智能指导和智能批改属性标签
    /// </summary>
    public enum CorrectionWay
    {
        /// <summary>
        /// 没有任何判断方法，无论如何都正确
        /// </summary>
        Nothing,

        /// <summary>
        /// 等于判断，等于才正确
        /// </summary>
        AssertEquals,

        /// <summary>
        /// 不等于判断，不等于才正确
        /// </summary>
        AssertNotEquals,

        /// <summary>
        /// 单选判断，选项中的一个且正确的选项才正确
        /// </summary>
        AssertOption,

        /// <summary>
        /// 数值区间，在指定区间的数据值才正确
        /// </summary>
        AssertInterval,

        /// <summary>
        /// 断言值为True，只有值为True时才正确
        /// </summary>
        AssertTrue,

        /// <summary>
        /// 断言值为False，只有值为Flase时才正确
        /// </summary>
        AssertFalse,

        /// <summary>
        /// 大于断言，只有值大于时才算正确
        /// </summary>
        AssertGreater,

        /// <summary>
        /// 大于等于断言，只有值大于等于是才算正确
        /// </summary>
        AssertGreaterOrEquals,

        /// <summary>
        /// 小于断言，只有值小于时才算正确
        /// </summary>
        AssertLess,

        /// <summary>
        /// 小于等于断言，只有值小于等于时才算正确
        /// </summary>
        AssertLessOrEquals

    }
}