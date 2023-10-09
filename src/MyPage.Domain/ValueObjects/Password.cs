using MyPage.Domain.Exceptions;

namespace MyPage.Domain.ValueObjects;

public record Password { 
public string Value { get; }

    public Password(string value) {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new EmptyNameExeption();
        }

        Value = value;
    }

    public static implicit operator string(Password name)
        => name.Value;

    public static implicit operator Password(string name)
        => new(name);
}
