using System;
using System.Collections.Generic;
using System.Text;

namespace LazySingleton
{
    internal class MyLazySingletonClass
    {
        static Lazy<MyLazySingletonClass> _getorCreateInstance = new Lazy<MyLazySingletonClass>(() => new MyLazySingletonClass());
        public Guid ID { get; set; }
        public MyLazySingletonClass()
        {
            ID = Guid.NewGuid();
        }

         public static MyLazySingletonClass Instance => _getorCreateInstance.Value;
    }
}
