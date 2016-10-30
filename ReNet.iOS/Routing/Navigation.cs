using System;
using System.Linq;
using System.Reflection;
using Foundation;
using ReNet.Routing;
using UIKit;

namespace ReNet.iOS.Routing
{
    public class Navigation : INavigation
    {
        public UINavigationController NavigationController { get; }
        public NavigationConfig Config { get; }

        public Navigation(UINavigationController controller, NavigationConfig config)
        {
            NavigationController = controller;
            Config = config;
        }

        public void NavigateTo(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (NavigationController == null)
                throw new InvalidOperationException(
                    $"{nameof(NavigationController)} is null. Please call {nameof(NavigationInitialAction)}.");

            NavigationConfigItem item;
            if (!Config.Items.TryGetValue(name, out item))
                throw new ArgumentException($"{name} is not registered in config.");

            var controller = CreateViewController(item);

            NavigationController.PushViewController(controller, true);
        }

        public void GoBack(int count = 1)
        {
            var controllers = NavigationController.ViewControllers;

            if (controllers.Length == 1 || controllers.Length < count - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(NavigationController.ViewControllers));
            }

            var targetController = controllers[controllers.Length-count-1];

            NavigationController.PopToViewController(targetController, true);
        }

        private UIViewController CreateViewController(NavigationConfigItem item)
        {
            UIViewController controller;
            if (string.IsNullOrEmpty(item.StoryboardName))
            {
                try
                {
                    controller = NavigationController.Storyboard.InstantiateViewController(item.StoryboardIdentifier);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(
                        $"{item.StoryboardIdentifier} cannot create ViewController in this storyboard.");
                }

                return controller;
            }

            var storyboard = UIStoryboard.FromName(item.StoryboardName, null);

            try
            {
                controller = storyboard.InstantiateViewController(item.StoryboardIdentifier);
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    $"{item.StoryboardIdentifier} cannot create ViewController in {item.StoryboardName}.");
            }

            return controller;
        }
    }
}