/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：压疮
* 类 名 称：TTUIBind
* 创建日期：2018-08-06 08:58:39
* 作者名称：zjw
* CLR 版本：4.0.30319.42000
* 功能描述：UI约束
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TinyTeam.UI
{

    /// <summary>
    /// Bind Some Delegate Func For Yours.
    /// </summary>
    public class TTUIBind : MonoBehaviour
    {
        static bool isBind = false;

        public static void Bind()
        {
            if (!isBind)
            {
                isBind = true;
                //Debug.LogWarning("Bind For UI Framework.");

                //bind for your loader api to load UI.
                TTUIPage.delegateSyncLoadUI = Resources.Load;
                //TTUIPage.delegateAsyncLoadUI = UILoader.Load;

            }
        }
    }
}

