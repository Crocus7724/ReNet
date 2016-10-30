using UIKit;

namespace ReNet.iOS.Routing
{
    internal class NavigationConfigItem
    {
        public string StoryboardName { get; }
        public string StoryboardIdentifier { get; }

        public NavigationConfigItem(string storyboardName, string storyboardIdentifier)
        {
            StoryboardName = storyboardName;
            StoryboardIdentifier = storyboardIdentifier;
        }
    }
}