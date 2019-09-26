/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 类 名 称： UpLoadScoreForSPWebGL
* 创建日期：2019-09-23 17:19:31
* 作者名称：张辰
* CLR 版本：4.0.30319.42000
* 修改记录：
* 描述：简易平台WEBGL用，调用JSLIB上传成绩
******************************************************************************/
using System.Runtime.InteropServices;

namespace Com.Rainier.ZC_Frame
{
    /// <summary>
    /// 
    /// </summary>
	public class UpLoadScoreForSPWebGL
	{
        /// <summary>
        /// jsLib中的UpLoadScore函数见：Assets\Plugins\WebCommunicationForSimplePlatform\SimplePlatformApi.jslib
        /// </summary>
        /// <param name="str"></param>
        [DllImport("__Internal")]
        private static extern void upLoadScore(string str);

        /// <summary>
        /// 上传成绩
        /// </summary>
        /// <param name="score">成绩</param>
        public static void UpLoadScore(string score)
        {
            upLoadScore(score);
        }

    }
}

