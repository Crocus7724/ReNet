using ReNet.Routing;

namespace RoutingExample
{
    public class AppState:IRoutableState
    {
        public INavigation Navigation { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}