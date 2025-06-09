using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Clinic.Domain.ValueObjects
{
    public record Text
    {
        public string Value { get; init; }

        public Text(string value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Text cannot be empty or whitespace.", nameof(value));
            if (value.Length > 500)
                throw new ArgumentException("Text cannot be longer than 100 characters.", nameof(value));
        }

        public static implicit operator Text(string value)
        {
            return new Text(value);
        }
    }
}
