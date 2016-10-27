using System;
using System.Collections.Generic;
using System.Linq;

namespace ReNet.Helpers
{
    public sealed class CombineReducer<TState> where TState : IState
    {
        private readonly IEnumerable<Reducer<TState>> _reducers;

        public CombineReducer(params Reducer<TState>[] reducers)
        {
            _reducers = reducers;
        }

        public TState Invoke(IAction action, TState state)
            => _reducers.Aggregate(state, (current, reducer) => reducer.Invoke(action, current));

        public static explicit operator Reducer<TState>(CombineReducer<TState> reducer)
            => reducer.Invoke;
    }
}