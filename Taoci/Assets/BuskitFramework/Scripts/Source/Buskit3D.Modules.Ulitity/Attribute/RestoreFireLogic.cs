
/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： Sequence
* 创建日期：2019-02-14 10:06:32
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：如果有此标签，场景还原的时候触发logic事件
******************************************************************************/

using System;

namespace Com.Rainier.Buskit3D
{   
    /// <summary>
    /// 场景还原的时候，是否触发对应的logic事件
    /// </summary>
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field,
        Inherited =true)]
    public class RestoreFireLogic : Attribute 
	{
        /// <summary>
        /// 触发状态，All=所有，Self=自身，Other=其他
        /// </summary>
        public string state = "All";

        public RestoreFireLogic(string state="All")
        {
            this.state = state;
        }
	}
}

