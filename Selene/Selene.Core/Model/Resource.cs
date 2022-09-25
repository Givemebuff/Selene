using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Core
{
    public interface IResource : IDisposable
    {
        string Key { get; }
    }

    public interface IResource<T> : IResource
    {
        T Value { get; }

        event ValueChangedEvent<T> ValueChanged;
    }

    public interface IEnumerableResource<T> : IResource<IEnumerable<T>>
    {

    }

    public abstract class ResourceBase : DisposeableObject, IResource
    {
        public ResourceBase(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public string Key { get; }
    }



    public class ResourceBase<T> : ResourceBase, IResource<T>
    {
        public ResourceBase(string key) : base(key)
        {

        }

        private T val;

        public T Value
        {
            get => val;
            protected set
            {
                var old = val;
                val = Value;
                RaiseValueChanged(old, val);
            }
        }

        public event ValueChangedEvent<T> ValueChanged;

        protected void RaiseValueChanged(T old, T newValue)
        {
            ValueChanged?.Invoke(this, new ValueChangedEventArgs<T>(old, newValue));
        }
    }

    public abstract class EnumerableResourceBase<T> : ResourceBase<IEnumerable<T>>, IEnumerableResource<T>
    {
        public EnumerableResourceBase(string key) : base(key)
        {
        }

        public abstract IEnumerable<T> Items { get; }
    }
}
