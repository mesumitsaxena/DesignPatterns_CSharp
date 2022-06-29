using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Singleton
{
    // From this method, check if(instance==null) twice, so that after lock if T1 creates the object, 
    // t2 will be notified that instance is not null so dont create another object
    internal class SingletonDoubleCheckLock
    {
        private static SingletonDoubleCheckLock instance;
        private static readonly object _lock = new object();
        private SingletonDoubleCheckLock() { }
        public static SingletonDoubleCheckLock getInstance()
        {
            if(instance == null)
            {
                lock(_lock)
                {
                    // If T2 was waiting outside and just got in, it should know some other thread has already created
                    // the instance, so do not create a new one.
                    if (instance == null)
                    {
                        instance = new SingletonDoubleCheckLock();
                    }
                }
            }
            return instance;
        }
        // This is a best working solution
    }
    
}
