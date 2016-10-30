using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(storyboardIdentifier))
            {
                throw new ArgumentNullException(name == null ? nameof(name) : nameof(storyboardIdentifier));
            }

            if (Items.ContainsKey(name)) throw new InvalidOperationException($"{name} is already used.");

            Items.Add(name, new NavigationConfigItem(storyboardName, storyboardIdentifier));

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
            var attributes = loadTargets.SelectMany(x => x.GetTypes())
                .Where(x => x.GetCustomAttribute<RoutingAttribute>() != null)
                .Select(x => x.GetCustomAttribute<RoutingAttribute>());

            foreach (var attribute in attributes)
            {
                RegisterView(attribute.Name, attribute.StoryboardName, attribute.StoryboardIdentifier);
            }

            return this;
        }

        private NavigationConfig RegisterView(Type viewType)
        {
            var attribute = viewType.GetCustomAttribute<RoutingAttribute>();

            RegisterView(attribute.Name, attribute.StoryboardName, attribute.StoryboardIdentifier);

            return this;
        }
    }
}