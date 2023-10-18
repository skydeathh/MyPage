using MyPage.Application.DTO;
using MyPage.Domain.Entities;

namespace MyPage.Application.Queries;
public static class Extensions {
    public static AuthentificationResponse AsAuthentificationResponse(this User user)
        => new AuthentificationResponse() {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
        };
}