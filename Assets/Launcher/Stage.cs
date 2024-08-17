using System;

namespace Launcher
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class Stage : Attribute
    {
        public string Name { get; }
        public int Order { get; }
        
        public Stage(Type type, int order = int.MaxValue)
        {
            Name = type.Name;
            Order = order;
        }
        
        public Stage(string name, int order = int.MaxValue)
        {
            Name = name;
            Order = order;
        }
    }
}