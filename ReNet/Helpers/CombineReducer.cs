using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReNet.Helpers
{
    public sealed class CombineReducer<TState> where TState : IState
    {
        private readonly IEnumerable<Reducer<TState>> _reducers;

        public CombineReducer(params Reducer<TState>[] reducers)
        {
            _reducers = reducers;
        }

        public CombineReducer(params Type[] types) : this(types
            .SelectMany(x => x.GetRuntimeMethods())
            .Where(x => x.GetCustomAttribute<ReducerAttribute>() != null)
            .Select(x => (Reducer<TState>) x.CreateDelegate(typeof(Reducer<TState>)))
            .ToArray())
        {
        }

        public TState Invoke(IAction action, TState state)
            => _reducers.Aggregate(state, (current, reducer) => reducer.Invoke(action, current));

        public static implicit operator Reducer<TState>(CombineReducer<TState> reducer)
            => reducer.Invoke;
    }
}