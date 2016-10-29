namespace ReNet.Routing
{
    public class InitialAction
    {
        private INavigation Navigation { get; }

        public InitialAction(INavigation navigation)
        {
            Navigation = navigation;
        }
    }

    public class NavigationAction : IAction
    {
        public string Name { get; }

        public NavigationAction(string name)
        {
            Name = name;
        }
    }
}