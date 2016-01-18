using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    /// <summary>
    /// 单例工厂
    /// </summary>
    public abstract class SingletonFactory<T> where T : SingletonFactory<T>, new()
    {
        private static readonly object SyncRoot = new object();
        private static bool fromSingleton;
        protected SingletonFactory()
        {
            if (!fromSingleton)
                throw new InvalidOperationException("不允许直接手动调用实例化函数，请调用静态属性Singleton获取实例。");
        }
        private static T instance;
        public static T Singleton
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            fromSingleton = true;
                            return instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
