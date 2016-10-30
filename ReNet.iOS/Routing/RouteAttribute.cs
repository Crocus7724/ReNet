using System;

namespace ReNet.iOS.Routing
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = false)]
    public class RoutingAttribute:Attribute
    {
        public string Name { get; }
        public string StoryboardIdentifier { get; }
        public string StoryboardName { get; set; }

        public RoutingAttribute(string name, string storyboardIdentifier)
        {
            Name = name;
            StoryboardIdentifier = storyboardIdentifier;
        }
    }
}