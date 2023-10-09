namespace MyPage.Shared.Abstractions.Domain;

public abstract class AggregateRoot<T> {
    public T Id { get; protected set; }
}