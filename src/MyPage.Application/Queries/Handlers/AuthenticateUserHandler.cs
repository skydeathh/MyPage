using Microsoft.AspNetCore.Identity;
using MyPage.Application.DTO;
using MyPage.Domain.Entities;
using MyPage.Shared.Abstractions.Queries;

namespace MyPage.Application.Queries.Handlers;

internal class AuthenticateUserHandler : IQueryHandler<AuthentificateUser, AuthentificationResponse> {
    private readonly UserManager<User> _userManager;

    public AuthenticateUserHandler(UserManager<User> userManager) {
        _userManager = userManager;
    }

    public Task<AuthentificationResponse> HandleAsync(AuthentificateUser command) {

     //   _userManager.
        throw new NotImplementedException();
    }
}