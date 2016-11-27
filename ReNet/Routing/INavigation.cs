namespace ReNet.Routing
{
    public interface INavigation
    {
        void NavigateTo(string name);
        void GoBack(int count = 1);
    }
}