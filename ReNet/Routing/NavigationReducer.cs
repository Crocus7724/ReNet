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

            var navigateToAction = action as NavigationAction;
            if (navigateToAction != null)
            {
                state.Navigation.NavigateTo(navigateToAction.Name);
                return state;
            }

            var goBackAction = action as NavigationGoBackAction;

            if (goBackAction != null)
            {
                state.Navigation.GoBack(goBackAction.Count);
                return state;
            }

            var initialAction = action as NavigationInitialAction;

            if (initialAction != null)
            {
                state.Navigation = ((NavigationInitialAction) action).Navigation;
            }

            return state;
        }
    }
}