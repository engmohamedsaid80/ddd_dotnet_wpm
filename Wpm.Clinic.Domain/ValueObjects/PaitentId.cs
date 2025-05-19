using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Clinic.Domain.ValueObjects
{
    public record PaitentId
    {
        public Guid Value { get; init; }

        public PaitentId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("PaitentId cannot be empty.", nameof(value));
            Value = value;
        }

        public static implicit operator PaitentId(Guid value)
        {
            return new PaitentId(value);
        }
    }
}
