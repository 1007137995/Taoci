/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：王志远
* 创建日期：2018/11/29  
* 作者名称：王志远
* 功能描述：选择工具数据模型
* 修改记录：
* 
******************************************************************************/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 选择工具数据模型
    /// </summary>
    public class SelectionDataModel : DataModelBehaviour
    {
        private void Awake()
        {
            this.DataEntity = new SelectionEntity();
        }
    }
}
