using ReNet.Routing;

namespace RoutingExample
{
    public class NextPageAction : NavigationAction
    {
        public NextPageAction(string name) : base(name)
        {
        }
    }

    public class PreviousPageAction : NavigationGoBackAction
    {
        public PreviousPageAction(int count = 1) : base(count)
        {
        }
    }
}