﻿using MyPage.Domain.Exceptions;

public record Name {
    public string Value { get; }

    public Name(string value) {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new EmptyNameExeption();
        }

        Value = value;
    }

    public static implicit operator string(Name name)
        => name.Value;

    public static implicit operator Name(string name)
        => new(name);
}