namespace ReNet.Routing
{
    public interface INavigationAction : IAction
    {
    }

    public class NavigationInitialAction : INavigationAction
    {
        public INavigation Navigation { get; }

        public NavigationInitialAction(INavigation navigation)
        {
            Navigation = navigation;
        }
    }

    public class NavigationAction : INavigationAction
    {
        public string Name { get; }

        public NavigationAction(string name)
        {
            Name = name;
        }
    }

    public class NavigationGoBackAction : INavigationAction
    {
        public int Count { get; }

        public NavigationGoBackAction(int count = 1)
        {
            Count = count;
        }
    }
}