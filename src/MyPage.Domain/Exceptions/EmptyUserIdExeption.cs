using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Domain.Exceptions;
internal class EmptyUserIdException : MyPageException {
    public EmptyUserIdException() : base(message: $"User's Id cannot be epmty.") {

    }
}