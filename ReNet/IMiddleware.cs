namespace ReNet
{
    public interface IMiddleware
    {
        IAction Invoke(IAction action);
    }
}