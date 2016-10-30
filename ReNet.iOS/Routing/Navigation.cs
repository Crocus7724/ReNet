using System;
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

            var targetController = controllers[controllers.Length - count - 1];

            NavigationController.PopToViewController(targetController, true);
        }

        private UIViewController CreateViewController(NavigationConfigItem item)
        {
            UIViewController controller;

            //xib
            if (item.ViewControllerType != null)
            {
                try
                {
                    controller = (UIViewController)Activator.CreateInstance(item.ViewControllerType);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"Cannot create instance for {item.ViewControllerType.Name}");
                }

                return controller;
            }

            //using storyboard
            if (string.IsNullOrEmpty(item.StoryboardName))
            {
                try
                {
                    controller = string.IsNullOrEmpty(item.StoryboardIdentifier)
                        ? NavigationController.Storyboard.InstantiateInitialViewController()
                        : NavigationController.Storyboard.InstantiateViewController(item.StoryboardIdentifier);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(
                        $"{item.StoryboardIdentifier ?? "Initial ViewController"} cannot create ViewController in this storyboard.");
                }

                return controller;
            }

            //other storyboard
            var storyboard = UIStoryboard.FromName(item.StoryboardName, null);

            try
            {
                controller = string.IsNullOrEmpty(item.StoryboardIdentifier)
                    ? storyboard.InstantiateInitialViewController()
                    : storyboard.InstantiateViewController(item.StoryboardIdentifier);
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    $"{item.StoryboardIdentifier ?? "Initial ViewController"} cannot create ViewController in {item.StoryboardName}.");
            }

            return controller;
        }
    }
}