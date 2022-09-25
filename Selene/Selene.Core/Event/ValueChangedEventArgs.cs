using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Core
{
    public delegate void ValueChangedEvent<T>(object sender, ValueChangedEventArgs<T> e);

    public class ValueChangedEventArgs<T> : EventArgs
    {
        public ValueChangedEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public T OldValue { get; }
        public T NewValue { get; }
    }
}
