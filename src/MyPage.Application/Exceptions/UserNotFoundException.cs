using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Application.Exceptions;

internal class UserNotFoudException : MyPageException {
    public UserNotFoudException(string email)
        : base(message: $"User with email '{email}' doesn't exist") {
    }

    public UserNotFoudException(int id)
    : base(message: $"User with Id '{id}' doesn't exist") {
    }
}