using Microsoft.EntityFrameworkCore;
using MyPage.Application.DTO;
using MyPage.Application.Exceptions;
using MyPage.Domain.Entities;
using MyPage.Infrastructure.EF.Contexts;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries.Handlers;

internal class AuthenticateUserHandler : IQueryHandler<AuthentificateUser, AuthentificationResponse> {
    private readonly DbSet<User> _users;

    public AuthenticateUserHandler(ApplicationDbContext context) {
        _users = context.Users;
    }

    public async Task<AuthentificationResponse> HandleAsync(AuthentificateUser command) {
        var user = await _users.SingleOrDefaultAsync(u => u.Email == command.Email);

        if (user == null) {
            throw new UserNotFoudException(command.Email);
        }
        
        // TODO USE HASH COMPARE INSTEAD OF
        if (user.Password != command.Password) {
            throw new WrongPasswordException();
        }

        return user.AsAuthentificationResponse();
    }
}