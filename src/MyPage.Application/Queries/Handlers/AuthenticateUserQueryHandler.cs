using Microsoft.EntityFrameworkCore;
using MyPage.Application.DTO;
using MyPage.Application.Exceptions;
using MyPage.Domain.Entities;
using MyPage.Infrastructure.EF.Contexts;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries.Handlers;

internal sealed class AuthenticateUserQueryHandler : IQueryHandler<AuthentificateUser, AuthentificationResponse> {
    private readonly DbSet<User> _users;

    public AuthenticateUserQueryHandler(ApplicationDbContext context) {
        _users = context.Users;
    }

    public async Task<AuthentificationResponse> HandleAsync(AuthentificateUser query) {
        var user = await _users.SingleOrDefaultAsync(u => u.Email == query.Email);

        if (user == null) {
            throw new UserNotFoudException(query.Email);
        }
        
        // TODO USE HASH COMPARE INSTEAD OF
        if (user.Password != query.Password) {
            throw new WrongPasswordException();
        }

        return user.AsAuthentificationResponse();
    }
}