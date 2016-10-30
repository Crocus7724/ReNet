using ReNet;

namespace RoutingExample
{
    public class AppStore : Store<AppState>
    {
        public AppStore(Reducer<AppState> reducer, AppState initialState = null, params IMiddleware[] middleware)
            : base(reducer, initialState, middleware)
        {
        }
    }
}