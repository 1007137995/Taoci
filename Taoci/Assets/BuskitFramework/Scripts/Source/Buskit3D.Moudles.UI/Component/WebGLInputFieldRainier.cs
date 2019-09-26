/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIController
* 创建日期：2019-01-21 11:30:17
* 作者名称：黎特为
* CLR 版本：4.0.30319.42000
* 功能描述：重写UGUI InputField，实现UI回放(数据模型)
* 修改记录：
* 日期 描述：
* 
******************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using Com.Rainier.Buskit3D.UI;
using UnityEngine.EventSystems;

public class WebGLInputFieldRainier : WebGLInputField
{

    [HideInInspector]
    public InputField inputField;
    private UGUIDataEntity entity;
    protected override void Start()
    {
        //try
        //{
        //    entity = (UGUIDataEntity)GetComponent<InputFieldModel>().DataEntity;
        //}
        //catch (System.Exception) { }

        //inputField = transform.gameObject.GetComponent<InputField>();
        //if (inputField != null)
        //{
        //    inputField.onValueChanged.AddListener(ShowText);
        //}
        //else
        //    Debug.LogError("Not Found InputField Component!!!");
        //base.Start();
    }
    
    public void ShowText(string inputText)
    {
        entity.Inputfile = inputText;
    }
   
}