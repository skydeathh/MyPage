using MyPage.Shared.Abstractions.Exceptions;

namespace MyPage.Domain.Exceptions;
internal class EmptyNameExeption : MyPageException {
    public EmptyNameExeption() : base(message: $"User's Name cannot be epmty.") {

    }
}
