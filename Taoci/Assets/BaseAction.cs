using System.Collections.Generic;

namespace Common.Action
{
    public abstract class BaseAction
    {
        /// <summary>
        /// 标识，查找用
        /// </summary>
        public string ID { set; get; }

        /// <summary>
        /// 事件列表，顺序存储
        /// </summary>
        private List<BaseAction> _children = new List<BaseAction>();

        private BaseAction parent;//记录上一层事件
        private bool isRoot;//是否是根事件
        private int currentIndex;//当前指向的子事件索引

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseAction(string id, bool isRoot = false)
        {
            ID = id;
            if (isRoot)
            {

            }
            this.isRoot = isRoot;
        }

        /// <summary>
        /// 获取指定子事件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseAction GetSubAction(string id)
        {
            foreach (var sub in _children)
            {
                if (sub.ID == id)
                {
                    return sub;
                }
                else if (sub._children.Count > 0)
                {
                    BaseAction temp = sub.GetSubAction(id);
                    if (temp != null)
                        return temp;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return ID;
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="action"></param>
        public void RegisterAction(BaseAction action)
        {
            _children.Add(action);
            action.parent = this;
        }

        /// <summary>
        /// 进入事件
        /// </summary>
        public virtual void Enter()
        {
            currentIndex = -1;
            Execute();
        }

        /// <summary>
        /// 执行事件，执行当前并执行子事件
        /// </summary>
        private void Execute()
        {
            //执行自己的事件
            ExecuteSelf();

            ////顺序执行子事件
            //foreach (BaseAction action in _children)
            //{
            //    action.Execute();
            //}

            //Exit();
        }

        /// <summary>
        /// 执行自己的事件
        /// </summary>
        protected abstract void ExecuteSelf();

        /// <summary>
        /// 执行当前指向的子事件
        /// </summary>
        protected void ExecuteChild()
        {
            _children[currentIndex].Enter();
        }

        /// <summary>
        /// 进行下一步
        /// </summary>
        protected void Next()
        {
            if (currentIndex < _children.Count - 1)
            {
                currentIndex++;
                ExecuteChild();
            }
            else
            {
                Exit();
            }
        }

        /// <summary>
        /// 退出事件
        /// </summary>
        public virtual void Exit()
        {
            if (!isRoot)
                parent.Next();
        }
    }
}