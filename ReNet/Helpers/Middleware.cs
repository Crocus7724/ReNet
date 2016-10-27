using System;

namespace ReNet.Helpers
{
    public class Middleware:IMiddleware
    {
        private readonly Func<IAction, IAction> _action;

        public Middleware(Func<IAction, IAction> action)
        {
            _action = action;
        }

        public IAction Invoke(IAction action)
            => _action.Invoke(action);
    }
}