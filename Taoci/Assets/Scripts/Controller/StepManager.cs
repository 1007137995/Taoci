/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：压疮
* 类 名 称：StepManager
* 创建日期：2018-08-06 09:56:55
* 作者名称：zjw
* CLR 版本：4.0.30319.42000
* 功能描述：步骤控制
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using UnityEngine;
using System.Collections;
using System;
using TinyTeam.UI;
using System.Collections.Generic;

namespace TaoCi
{
    public class StepManager : MonoBehaviour
    {
        
        /// <summary>
        /// 步骤切换事件
        /// </summary>
        public event EventHandler LocalStepChange;
        public delegate void StepHandler(int step);
        public event StepHandler StepChange;
        /// <summary>
        /// 设置步骤
        /// </summary>
        public int setStep;
        /// <summary>
        /// 当前步骤
        /// </summary>
        private int localStep;

        public int LocalStep
        {
            get { return localStep; }
            set
            {
                bool isChange = false;
                if (localStep != value)
                {
                    isChange = true;
                }
                localStep = value;
                if (isChange)
                {
                    this.OnStepChange(new EventArgs());
                    if (this.StepChange != null)
                    {
                        this.StepChange(localStep);
                    }
                }
            }
        }

        void Awake()
        {
            LocalStepChange += new EventHandler(DoThings);
            setStep = 1001000;
            LocalStep = setStep;
        }

        void Start()
        {
            
        }

        void Update()
        {
            //Debug.Log(LocalStep);
        }

        /// <summary>
        /// 重置步骤
        /// </summary>
        public void Reset()
        {
            LocalStep = setStep;
        }

        /// <summary>
        /// 下一步
        /// </summary>
        public void LocalStepAdd()
        {
            LocalStep++;
        }

        public void SetStep(int index)
        {
            LocalStep = index;
        }

        private void OnStepChange(EventArgs eventArgs)
        {
            if (this.LocalStepChange != null)
            {
                this.LocalStepChange(this, eventArgs);
            }
        }

        /// <summary>
        /// 处理该步骤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">事件</param>
        public virtual void DoThings(object sender, EventArgs e)
        {
            switch (LocalStep)
            {
                
                default:
                    break;
            }
        }
    }
}

