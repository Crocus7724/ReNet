using ReNet;
using ReNet.Helpers;
using ReNet.Routing;

namespace RoutingExample
{
    public static class Reducers
    {
        [Reducer]
        public static AppState Invoke(IAction action, AppState state)
        {
            var newState = state ?? new AppState();

            if (action is NextPageAction)
            {
                var name = ((NextPageAction) action).Name;
                newState.PageNumber++;
                newState.Navigation.NavigateTo(name);
            }
            else if (action is PreviousPageAction)
            {
                var count = ((PreviousPageAction) action).Count;
                newState.PageNumber -= count;
                newState.Navigation.GoBack(count);
            }
            else if (action is NavigationInitialAction)
            {
                var navigation = ((NavigationInitialAction) action).Navigation;
                newState.Navigation = navigation;
            }

            return new AppState()
            {
                Navigation = newState.Navigation,
                PageNumber = newState.PageNumber,
            };
        }
    }
}