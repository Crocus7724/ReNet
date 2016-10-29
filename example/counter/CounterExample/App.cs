using ReNet.Helpers;

namespace CounterExample
{
    public class App
    {
        public static App Current { get; } = new App();

        public AppStore Store { get; }

        public App()
        {
            Store=new AppStore(new CombineReducer<AppState>(typeof(Reducers)),new AppState());
        }
    }
}