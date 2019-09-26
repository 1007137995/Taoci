/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: GetUserInformation.cs
  Author:张辰       Version :1.0          Date: 2019-8-15
  Description:调用JsLib脚本中的_GetUserInfo方法
************************************************************/
using System.Runtime.InteropServices;

public class GetUserInformation {


    /// <summary>
    /// jsLib中的GetUserInfo函数见：Assets\Plugins\WebCommunicationForNormalPlatform\LanInterApi.jslib
    /// </summary>
    /// <param name="str"></param>
    [DllImport("__Internal")]
    private static extern void _GetUserInfo();

    /// <summary>
    /// 获取用户信息
    /// </summary>
    public static void GetUserInfo() {
        _GetUserInfo();
    }
}
