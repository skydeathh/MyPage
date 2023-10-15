using MyPage.Application.Exceptions;
using MyPage.Domain.Entities;
using MyPage.Domain.Repositories;
using MyPage.Shared.Abstractions.Commands;

namespace MyPage.Application.Commands.Handlers;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>{
    private readonly IUserRepository _repository;

    public RegisterUserCommandHandler(IUserRepository repository) {
        _repository = repository;
    }

    public async Task HandleAsync(RegisterUserCommand command) {
        var user = await _repository.GetUserByEmail(command.Email);

        if (user is not null) {
            throw new UserAlreadyExistsException(command.Email);
        }
        // TODO PUT HASH IN REPOSITORY INSTEAD OF USER'S PASSWORD                                    
        user = new User(command.FirstName, command.LastName, command.Email, command.Password);

        await _repository.AddAsync(user);
    }
}