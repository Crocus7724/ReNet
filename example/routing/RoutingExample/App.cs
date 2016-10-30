using ReNet.Helpers;
using ReNet.Routing;

namespace RoutingExample
{
    public class App
    {
        public static App Current { get; }=new App();

        public AppStore Store { get; }

        public App()
        {
            Store=new AppStore(new CombineReducer<AppState>(typeof(NavigationReducer<AppState>),typeof(Reducers)),new AppState());
        }
    }
}