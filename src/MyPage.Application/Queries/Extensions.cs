using MyPage.Application.DTO;
using MyPage.Domain.Entities;

namespace MyPage.Application.Queries;
internal static class Extensions {
    public static AuthentificationResponse AsAuthentificationResponse(this User user)
        => new AuthentificationResponse() {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
        };
}