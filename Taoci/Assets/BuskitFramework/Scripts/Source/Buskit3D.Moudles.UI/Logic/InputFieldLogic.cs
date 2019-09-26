/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIController
* 创建日期：2019-01-21 11:30:17
* 作者名称：黎特为
* CLR 版本：4.0.30319.42000
* 功能描述：重写InputField组件(业务逻辑)
* 修改记录：
* 日期 描述：
* 
******************************************************************************/
using Com.Rainier.Buskit.Unity.Architecture.Aop;
namespace Com.Rainier.Buskit3D.UI
{
    /// <summary>
    /// 逻辑处理
    /// </summary>
    public class InputFieldLogic : LogicBehaviour
    {
        private WebGLInputFieldRainier inputField;
        private void Start()
        {
            inputField = transform.gameObject.GetComponent<WebGLInputFieldRainier>();
        }
        public override void ProcessLogic(PropertyMessage evt)
        {
            if (evt.PropertyName.Equals("Inputfile"))
            {
                    inputField.text = (string)evt.NewValue;            
            }
        }
    }
}