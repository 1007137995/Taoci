/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D
* 类 名 称：CreatePartCommand
* 创建日期：2018-04-07 10:58:17
* 作者名称：王志远
* CLR 版本：4.0.30319.42000
* 功能描述：创建器件命令
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/

using System;
using UnityEngine;
using Com.Rainier.Buskit.Unity.Architecture.Injector;
using Com.Rainier.BusKit.Unity.Modules.Command;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 创建器件命令
    /// </summary>
    public class CommandPartCreate : AbsCommand
    {
        [Inject]
        IServiceExperiment _Experiment = null;

        /// <summary>
        /// 预制体
        /// </summary>
        public string PartPrefab = "";

        /// <summary>
        /// 物体创建位置
        /// </summary>
        public Vector3 Position = Vector3.zero;

        /// <summary>
        /// 父亲物体
        /// </summary>
        public GameObject Parent = null;
        
        /// <summary>
        /// 加载的预制体
        /// </summary>
        GameObject loadedPrefab = null;

        /// <summary>
        /// 创建的新器件对象
        /// </summary>
        GameObject newObject = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommandPartCreate()
        {
            InjectService.InjectInto(this);
        }

        /// <summary>
        /// 执行添加操作
        /// </summary>
        public override void Execute()
        {
            GameObject objPrefab = (GameObject)Resources.Load(PartPrefab);

            if (objPrefab == null)
            {
                throw new Exception("加载[" + PartPrefab + "]失败");
            }

            loadedPrefab = objPrefab;
            newObject    = MonoBehaviour.Instantiate(loadedPrefab);
            if (Parent != null)
            {
                newObject.transform.parent = Parent.transform;
                newObject.transform.localPosition = Position;
            }
            _Experiment.RegisterPart(objPrefab.GetComponent<PartDataModel>());
        }

        /// <summary>
        /// 重做
        /// </summary>
        public override void Redo()
        {
            newObject.SetActive(true);
        }

        /// <summary>
        /// 取消
        /// </summary>
        public override void Undo()
        {
            if(newObject != null)
            {
                newObject.SetActive(false);
                _Experiment.UnregisterPart(newObject.GetComponent<PartDataModel>());
            }
        }
    }
}

