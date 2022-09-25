using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Core
{
    public class Range<T> where T : struct, IComparable
    {
        public event ValueChangedEvent<T> MaximumChanged;
        public event ValueChangedEvent<T> MinimumChanged;

        public Range()
        {

        }

        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
            {
                throw new ArgumentException("Minimum is greater than Maximum");
            }

            minimum = min;
            maximum = max;
        }


        private T maximum;
        public T Maximum
        {
            get => maximum;
            set
            {
                if (maximum.CompareTo(value) == 0)
                {
                    return;
                }

                if (maximum.CompareTo(minimum) < 0)
                {
                    throw new ArgumentException(nameof(Maximum));
                }
                var old = maximum;
                maximum = value;
                HandleMaximumChanged(old, value);
            }
        }

        private T minimum;
        public T Minimum
        {
            get => minimum;
            set
            {
                if (minimum.CompareTo(value) == 0)
                {
                    return;
                }

                if (maximum.CompareTo(minimum) < 0)
                {
                    throw new ArgumentException(nameof(Minimum));
                }
                var old = minimum;
                minimum = value;
                HandleMinimumChanged(old, value);
            }
        }

        private void HandleMinimumChanged(T old, T value)
        {
            OnMinimumChanged(old, value);
            MinimumChanged?.Invoke(this, new ValueChangedEventArgs<T>(old, value));
        }

        private void HandleMaximumChanged(T old, T value)
        {
            OnMaximumChanged(old, value);
            MaximumChanged?.Invoke(this, new ValueChangedEventArgs<T>(old, value));
        }

        protected virtual void OnMaximumChanged(T old, T value)
        {

        }

        protected virtual void OnMinimumChanged(T old, T value)
        {

        }
    }

    public class RangeValue<T> : Range<T> where T : struct, IComparable
    {
        public RangeValue(T min, T max, T val) : base(min, max)
        {
            val = CoreValue(max, min, val);
        }

        public event ValueChangedEvent<T> ValueChanged;


        private T val;
        public T Value
        {
            get => val;
            set
            {
                T oldValue = val;
                val = CoreValue(Maximum, Minimum, value);
                ValueChanged?.Invoke(this, new ValueChangedEventArgs<T>(oldValue, val));
            }
        }

        protected override void OnMaximumChanged(T old, T value)
        {
            if (val.CompareTo(Maximum) >= 0)
            {
                Value = Maximum;
            }
        }

        protected override void OnMinimumChanged(T old, T value)
        {
            if (val.CompareTo(Minimum) <= 0)
            {
                Value = Minimum;
            }
        }

        public static T CoreValue(T max, T min, T input)
        {
            if (input.CompareTo(min) <= 0)
            {
                return min;
            }
            else if (input.CompareTo(max) >= 0)
            {
                return max;
            }
            else
            {
                return input;
            }
        }
    }
}
