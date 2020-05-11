using System;
using System.Threading;

namespace WS.HTZF.Utilities.Helper
{
    public  class LazyFactory<T>
    {
        /// <summary>
        ///  懒加载模式
        /// </summary>
        private static Lazy<T> _factoryLazy = new Lazy<T>(
            () => (T)Activator.CreateInstance(typeof(T)),
            LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Instance
        /// </summary>
        public static T Instance
        {
            get
            {
                return _factoryLazy.Value;
            }
        }
    }
}