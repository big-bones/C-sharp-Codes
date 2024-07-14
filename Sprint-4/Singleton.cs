using System;
using System.Threading;

namespace Singleton
{

    class SingletonClass
    {
        private SingletonClass() { }
        private static SingletonClass _instance = null;
        private static object _instanceLock = new object();
        public static SingletonClass GetInstance()
        {
            if( _instance == null)
            {
                lock( _instanceLock )
                {
                    if(_instance == null)
                    {
                        _instance = new SingletonClass();
                    }
                }
            }
              return _instance;
        }

        public void SomeLogic()
        {
            // Some buisness Logic is written here
        }

    }

    class Program
    {
        static void Main(string[] args) {
            Thread a = new Thread(() => {
                Console.WriteLine(SingletonClass.GetInstance().GetHashCode());
            });
            Thread b = new Thread(() => {
                Console.WriteLine(SingletonClass.GetInstance().GetHashCode());
            });
            a.Start(); 
            b.Start();
            Thread.Sleep(2000);
        }
    }
}