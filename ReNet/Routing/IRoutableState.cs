namespace ReNet.Routing
{
    public interface IRoutableState:IState
    {
        INavigation Navigation { get; set; }
    }
}