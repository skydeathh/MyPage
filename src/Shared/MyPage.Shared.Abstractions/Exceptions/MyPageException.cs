namespace MyPage.Shared.Abstractions.Exceptions;

public abstract class MyPageException : Exception {
    protected MyPageException(string message) : base(message) { }
}