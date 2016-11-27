using System;

namespace ReNet.Helpers
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Delegate,AllowMultiple = false,Inherited = false)]
    public class ReducerAttribute : Attribute
    {
    }
}