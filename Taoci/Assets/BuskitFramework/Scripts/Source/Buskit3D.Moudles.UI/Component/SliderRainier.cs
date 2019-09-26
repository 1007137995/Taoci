/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：UIController
* 创建日期：2019-01-21 11:30:17
* 作者名称：黎特为
* CLR 版本：4.0.30319.42000
* 功能描述：重写Slider组件
* 修改记录：
* 日期 描述：
* 
******************************************************************************/
using UnityEngine;
using UnityEngine.UI;
namespace Com.Rainier.Buskit3D.UI
{
    [RequireComponent(typeof(SliderModel))]
    [RequireComponent(typeof(SliderLogic))]
    public class SliderRainier : Slider
    {
        private UGUIDataEntity entity;
        
        protected override void Start()
        {
            try
            {
                entity = (UGUIDataEntity)GetComponent<SliderModel>().DataEntity;
            }
            catch (System.Exception){   }
            
        }
        public override float value
        {
            get
            {
                if (wholeNumbers)
                    return Mathf.Round(m_Value);
                return m_Value;
            }
            set
            {
                Set(value);
            }
        }
        void Set(float input)
        {          
            Set(input,true);
            entity.SliderValue = m_Value;
        }
    }
}

