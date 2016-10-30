using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UIKit;

namespace ReNet.iOS.Routing
{
    public class NavigationConfig
    {
        internal IDictionary<string, NavigationConfigItem> Items { get; }
        = new Dictionary<string, NavigationConfigItem>();

        public NavigationConfig()
        {
        }

        public NavigationConfig RegisterView(string name, string storyboardName, string storyboardIdentifier)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (Items.ContainsKey(name)) throw new InvalidOperationException($"{name} is already used.");

            Items.Add(name, new NavigationConfigItem(storyboardName, storyboardIdentifier));

            return this;
        }

        public NavigationConfig RegisterView(string name,Type viewControllerType)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(Items.ContainsKey(name))throw new InvalidOperationException($"{name} is already used.");

            Items.Add(name,new NavigationConfigItem(viewControllerType));

            return this;
        }

        public NavigationConfig RegisterViews(params Type[] viewTypes)
        {
            foreach (var type in viewTypes)
            {
                RegisterView(type);
            }

            return this;
        }

        public NavigationConfig RegisterViews(params Assembly[] loadTargets)
        {
            var types = loadTargets.SelectMany(x => x.GetTypes())
                .Where(x => x.GetCustomAttribute<RouteAttribute>() != null);

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<RouteAttribute>();
                if (attribute.UseXib)
                {
                    RegisterView(attribute.Name, type);
                    break;
                }

                RegisterView(attribute.Name, attribute.StoryboardName, attribute.StoryboardIdentifier);
            }

            return this;
        }

        private void RegisterView(Type viewType)
        {
            var attribute = viewType.GetCustomAttribute<RouteAttribute>();

            if (attribute.UseXib)
            {
                RegisterView(attribute.Name, viewType);
                return;
            }

            RegisterView(attribute.Name, attribute.StoryboardName, attribute.StoryboardIdentifier);
        }
    }
}