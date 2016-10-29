using ReNet;

namespace CounterExample
{
    public class Reducers
    {
        public static AppState Invoke(IAction action, AppState state)
        {
            var newState = state ?? new AppState();
            if (action is IncreaseAction)
            {
                newState.Counter++;
            }
            else if (action is DecreaseAction)
            {
                newState.Counter--;
            }

            return new AppState()
            {
                Counter = newState.Counter,
            };
        }
    }
}