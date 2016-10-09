using System;

namespace ConsoleApplication
{
    public struct Option<T>
    {
        private readonly T _value;

        public Option(T val)
        {
            _value = val;
            IsSome = val != null;
        }

        public bool IsSome { get; }

        public T Value
        {
            get
            {
                if (!IsSome)
                {
                    throw new Exception("Accessing Value without checking IsSome is prohibited !");
                }

                return _value;
            }
        }

        public static Option<T> Some(T val)
        {
            return new Option<T>(val);
        }

        public static Option<T> None()
        {
            return new Option<T>();
        }

        public override string ToString()
        {
            if (!IsSome)
            {
                return "None";
            }

            return string.Format("Some({0})", _value);
        }

        public Option<U> Map<U>(Func<T, U> map)
        {
            return Bind(x => Option<U>.Some(map(x)));
        }

        public Option<U> Bind<U>(Func<T, Option<U>> bind)
        {
            if (IsSome)
            {
                return bind(Value);
            }

            return Option<U>.None();
        }
    }
}