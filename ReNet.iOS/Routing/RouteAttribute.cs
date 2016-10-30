using System;

namespace ReNet.iOS.Routing
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = false)]
    public class RouteAttribute:Attribute
    {
        public string Name { get; }
        public string StoryboardIdentifier { get; set; }
        public string StoryboardName { get; set; }
        public bool UseXib { get; set; }

        public RouteAttribute(string name)
        {
            Name = name;
        }
    }
}