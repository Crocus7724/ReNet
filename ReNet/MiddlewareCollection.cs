using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ReNet.Helpers;

namespace ReNet
{
    public class MiddlewareCollection : IList, IReadOnlyList<IMiddleware>, IMiddleware
    {
        private readonly IList<IMiddleware> _list;
        private readonly object _syncObject = new object();

        public MiddlewareCollection() : this(Enumerable.Empty<IMiddleware>())
        {
        }

        public MiddlewareCollection(IEnumerable<IMiddleware> source)
        {
            if (source != null) throw new ArgumentNullException(nameof(source));

            _list = new List<IMiddleware>(source);
        }

        public IEnumerator<IMiddleware> GetEnumerator()
            => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void CopyTo(Array array, int index)
            => _list.CopyTo(array.Cast<IMiddleware>().ToArray(), index);

        int ICollection.Count => _list.Count;

        public bool IsSynchronized { get; }
        public object SyncRoot { get; } = new object();

        public void Add(IMiddleware value)
            => InvokeLockAction(() => _list.Add(value));

        public void Add(Func<IAction, IAction> action)
            => Add(new Middleware(action));

        public int Add(object value)
        {
            Add((IMiddleware) value);
            return _list.Count - 1;
        }

        public void Clear() => InvokeLockAction(() => _list.Clear());

        public bool Contains(IMiddleware value) => _list.Contains(value);

        public bool Contains(object value) => Contains((IMiddleware) value);

        public int IndexOf(IMiddleware value) => _list.IndexOf(value);

        public int IndexOf(object value) => IndexOf((IMiddleware) value);

        public void Insert(int index, IMiddleware value)
            => InvokeLockAction(() => _list.Insert(index, value));

        public void Insert(int index, object value) => Insert(index, (IMiddleware) value);

        public void Remove(IMiddleware value) => InvokeLockAction(() => _list.Remove(value));

        public void Remove(object value) => Remove((IMiddleware) value);

        public void RemoveAt(int index) => InvokeLockAction(() => _list.RemoveAt(index));

        public bool IsFixedSize { get; } = false;
        public bool IsReadOnly => _list.IsReadOnly;

        object IList.this[int index]
        {
            get { return _list[index]; }
            set { this[index] = (IMiddleware) value; }
        }

        int IReadOnlyCollection<IMiddleware>.Count => _list.Count;

        public IMiddleware this[int index]
        {
            get { return _list[index]; }
            set { InvokeLockAction(() => _list[index] = value); }
        }

        public IAction Invoke(IAction action)
        {
            InvokeLockAction(()
                => action = this.Aggregate(action, (current, middleware) => middleware.Invoke(current)));

            return action;
        }

        private void InvokeLockAction(Action invokeAction)
        {
            lock (_syncObject)
            {
                invokeAction();
            }
        }
    }
}