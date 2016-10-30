using ReNet;
using ReNet.Helpers;

namespace RoutingExample
{
    public static class Reducers
    {
        [Reducer]
        public static AppState Invoke(IAction action,AppState state)
        {
            var newState = state ?? new AppState();

            if (action is NextPageAction)
            {
                newState.PageNumber++;
            }
            else if(action is PreviousPageAction)
            {
                newState.PageNumber--;
            }

            return new AppState()
            {
                Navigation = newState.Navigation,
                PageNumber = newState.PageNumber,
            };
        }
    }
}