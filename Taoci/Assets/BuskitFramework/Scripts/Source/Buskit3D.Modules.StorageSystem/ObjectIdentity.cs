/*******************************************************************************
* 版权声明：北京润尼尔网络科技有限公司，保留所有版权
* 版本声明：v1.0.0
* 项目名称：Buskit3D_Example_005_StorageSystem
* 类 名 称：ObjectShapeModel
* 创建日期：2019-03-18 10:58:17
* 作者名称：王庚
* CLR 版本：4.0.30319.42000
* 功能描述：数据载体
* 修改记录：
* 日期 描述 更新功能
* 
******************************************************************************/
using System;
using System.Collections.Generic;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// 生成唯一ID
    /// </summary>
    [Serializable]
    public sealed class ObjectIdentity : IEquatable<ObjectIdentity>
    {
        /// <summary>
        /// 作为运行时动态编号
        /// </summary>
        private static short runtimeIdBase = 1110;

        /// <summary>
        /// 字节长度
        /// </summary>
        public static readonly int byteSize = 2;
        
        /// <summary>
        /// 唯一ID
        /// </summary>
        public  short id;

        /// <summary>
        /// 最大尝试次数
        /// </summary>
        internal const int maxGenerateAttempts = 0x200;

        /// <summary>
        /// 默认未定义的ID
        /// </summary>
        internal const int unassignedID = -1;

        /// <summary>
        /// 所有已生成的ID
        /// </summary>
        private static List<ObjectIdentity> usedIds = new List<ObjectIdentity>();

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ObjectIdentity()
        {
            usedIds.Clear();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ObjectIdentity()
        {
            this.id = -1;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ObjectIdentity(short id)
        {
            this.id = -1;
            this.id = id;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ObjectIdentity(int id)
        {
            this.id = -1;
            this.id = (short)id;
        }

        /// <summary>
        /// 重载函数
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (!ReferenceEquals(this, obj))
            {
                return false;
            }
            return Equals((ObjectIdentity)obj);
        }

        /// <summary>
        /// 接口函数
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ObjectIdentity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (!ReferenceEquals(this, other))
            {
                return false;
            }
            return (this.id == other.id);
        }

        /// <summary>
        /// 生成唯一ID
        /// </summary>
        /// <param name="idenity"></param>
        private static void Generate(ObjectIdentity idenity)
        {
            short num = -1;
            short num2 = 0;
            byte[] buffer = new byte[2];
            System.Random random = new System.Random((int)DateTime.Now.Ticks);
            do
            {
                if (num2 > 0x200)
                {
                    throw new OperationCanceledException("Attempting to find unique replay id took too long ,the operation was canceled to prevent a long or infinite loop");
                }
                random.NextBytes(buffer);
                num = (short)((buffer[0] << 8) | buffer[1]);
                num2 = (short)(num2 + 1);
            } while ((num == -1) || !IsValueUnique(num));
            idenity.id = num;
        }

        /// <summary>
        /// 生成一个唯一ID好
        /// </summary>
        /// <returns></returns>
        public static ObjectIdentity GenerateRuntimeId()
        {
            ObjectIdentity id = new ObjectIdentity();
            id.id = runtimeIdBase++;
            return id;
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        /// <summary>
        /// 判断是否唯一
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        private static bool IsUnique(ObjectIdentity identity)
        {
            if (!identity.IsGenerated)
            {
                return false;
            }
            foreach (ObjectIdentity identity2 in usedIds)
            {
                if (!(identity2==identity)&&(identity2.id == identity.id))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断Id是否唯一
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsValueUnique(short value)
        {
            foreach (ObjectIdentity identity in usedIds)
            {
                if (identity.id == value)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(ObjectIdentity a, ObjectIdentity b)
        {
                if (ReferenceEquals(a, null))
                {
                    return false;
                }
                if (ReferenceEquals(b, null))
                {
                    return false;
                }
                if (!ReferenceEquals(a, b))
                {
                    return false;
                }
                return a.Equals(b);
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(ObjectIdentity a, ObjectIdentity b)
        {
                return !(a == b);
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="identity"></param>
        public static implicit operator short(ObjectIdentity identity)
        {
            return identity.id;
        }

        /// <summary>
        /// 注册唯一ID
        /// </summary>
        /// <param name="identity"></param>
        public static void RegisterIdentity(ObjectIdentity identity)
        {
            if (!IsUnique(identity))
            {
                Generate(identity);
            }
            if (!usedIds.Contains(identity))
            {
                usedIds.Add(identity);
            }
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ReplayIdentity({0})", this.id);
        }

        /// <summary>
        /// 删除已注册ID
        /// </summary>
        /// <param name="identity"></param>
        public static void UnregisterIdentity(ObjectIdentity identity)
        {
            if (usedIds.Contains(identity))
            {
                usedIds.Remove(identity);
            }
        }

        /// <summary>
        /// 判断是佛已生成ID
        /// </summary>
        private bool IsGenerated
        {
            get
            {
                return (this.id != -1);
            }
        }
    }
}