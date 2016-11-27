using System;
using UIKit;

namespace ReNet.iOS.Routing
{
    internal class NavigationConfigItem
    {
        public string StoryboardName { get; }
        public string StoryboardIdentifier { get; }
        public Type ViewControllerType { get; }

        public NavigationConfigItem(string storyboardName, string storyboardIdentifier)
        {
            StoryboardName = storyboardName;
            StoryboardIdentifier = storyboardIdentifier;
        }

        public NavigationConfigItem(Type viewControllerType)
        {
            ViewControllerType = viewControllerType;
        }
    }
}