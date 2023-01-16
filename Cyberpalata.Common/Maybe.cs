using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Common
{
    public class Maybe<T> where T : class
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                Contract.Requires(HasValue);

                return _value;
            }
        }
        public bool HasValue
        {
            get => _value != null;
        }

        private Maybe([AllowNull]T value)
        {
            _value = value;
        }

        public static implicit operator Maybe<T>([AllowNull]T value)
        {
            return new Maybe<T>(value);
        }
    }
}
