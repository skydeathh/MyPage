using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands;

public record RegisterUserCommand(string FirstName, string LastName, string Email, string Password) : ICommand;