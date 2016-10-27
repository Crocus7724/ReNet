using System;
using System.Reactive.Subjects;

namespace ReNet
{
    public delegate TState Reducer<TState>(IAction action, TState state) where TState : IState;

    public class Store<TState> : IObservable<TState> where TState : IState
    {
        private readonly object syncObject = new object();
        private readonly Func<IAction, IAction> _dispatcher;
        private readonly BehaviorSubject<TState> _subject;

        internal Reducer<TState> Reducer { get; }

        public MiddlewareCollection Middlewares { get; }

        public TState State { get; private set; }


        protected Store(Reducer<TState> reducer, TState initialState = default(TState),
            params IMiddleware[] middleware)
        {
            State = initialState;

            _subject = new BehaviorSubject<TState>(initialState);

            Middlewares = new MiddlewareCollection(middleware);
            _dispatcher = InvokeDispathAction;
            Reducer = reducer;
        }

        public IDisposable Subscribe(IObserver<TState> observer)
            => _subject.Subscribe(observer);

        public IAction Dispatch(IAction action) => _dispatcher.Invoke(action);

        private IAction InvokeDispathAction(IAction action)
        {
            action = Middlewares.Invoke(action);

            return InnerDispath(action);
        }

        private IAction InnerDispath(IAction action)
        {
            lock (syncObject)
            {
                State = Reducer.Invoke(action, State);
            }
            _subject.OnNext(State);
            return action;
        }
    }
}