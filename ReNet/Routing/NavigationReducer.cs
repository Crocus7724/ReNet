using ReNet.Helpers;

namespace ReNet.Routing
{
    public class NavigationReducer<TState> where TState : IRoutableState
    {
        [Reducer]
        public static TState Invoke(IAction action, TState state)
        {
            var navigationAction = action as NavigationAction;

            if (navigationAction != null)
            {
                state.Navigation.NavigateTo(navigationAction.Name);
            }

            return state;
        }
    }
}