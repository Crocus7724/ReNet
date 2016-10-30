using ReNet.Helpers;

namespace ReNet.Routing
{
    public class NavigationReducer<TState> where TState : IRoutableState
    {
        [Reducer]
        public static TState Invoke(IAction action, TState state)
        {
            var navigationAction = action as INavigationAction;

            if (navigationAction == null) return state;

            if (action is NavigationAction)
            {
                state.Navigation.NavigateTo(((NavigationAction)action).Name);
            }
            else if(action is NavigationInitialAction)
            {
                state.Navigation=((NavigationInitialAction) action).Navigation;
            }

            return state;
        }
    }
}