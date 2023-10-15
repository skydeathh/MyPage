using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Application.Exceptions;

internal class WrongPasswordException : MyPageException {
    public WrongPasswordException() : base(message: $"Wrong password") {
    }
}