/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：压疮
* 类 名 称：ObjectBase
* 创建日期：2018-08-06 09:13:36
* 作者名称：zjw
* CLR 版本：4.0.30319.42000
* 功能描述：物品基类
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TaoCi
{
    public class ObjectBase : MonoBehaviour
    {

        public virtual void OnMouseLeftClick() { }
        public virtual void OnMouseOver() { }
        public virtual void OnMouseExit() { }
    }
}