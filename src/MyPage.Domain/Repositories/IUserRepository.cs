using MyPage.Domain.Entities;

namespace MyPage.Domain.Repositories;

public interface IUserRepository : IMyPageRepository<User> {
    Task<User> GetUserByEmail(string email);
}