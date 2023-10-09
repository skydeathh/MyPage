using MyPage.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Domain.ValueObjects {
    public record Surname {
        public string Value { get; }

        public Surname(string value) {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new EmptyNameExeption();
            }

            Value = value;
        }

        public static implicit operator string(Surname name)
            => name.Value;

        public static implicit operator Surname(string name)
            => new(name);
    }
}
