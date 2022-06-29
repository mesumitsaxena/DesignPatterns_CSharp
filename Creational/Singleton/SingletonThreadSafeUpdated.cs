using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Singleton
{
    // Here Instead of locking the whole method, just lock the portion of the code which is creating the new object
    internal class SingletonThreadSafeUpdated
    {
        private static SingletonThreadSafeUpdated instance;
        private static readonly object _lock = new object();
        private SingletonThreadSafeUpdated() { }
        public static SingletonThreadSafeUpdated getInstance()
        {
            if (instance == null)
            {
                //Take a lock only when instance is null
                lock (_lock)
                {
                    instance = new SingletonThreadSafeUpdated();
                }
            }
            return instance;
        }
    }
    // Issue with this is, if two thread T1 and T2 reach to line number 17 (instance==null) they will both get into the code block
    // and suppose T1 took a lock and created an instance, T2 was waiting outside, when T1 is finished T2 will also take a lock and create an another object
    // which will break our principle.
    // Solution is double check lock.
}
