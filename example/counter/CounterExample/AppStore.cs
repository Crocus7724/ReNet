using System;
using System.Collections.Generic;
using ReNet;

namespace CounterExample
{
    public class AppStore : Store<AppState>
    {
        public AppStore(Reducer<AppState> reducer, AppState initialState = null, params IMiddleware[] middleware)
            : base(reducer, initialState, middleware)
        {
        }
    }
}