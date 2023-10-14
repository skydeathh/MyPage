using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Application.Exceptions;

internal class UserAlreadyExistsException : MyPageException {
    public UserAlreadyExistsException(string email)
        : base(message: $"User with email '{email}' already exists") {
    }
}